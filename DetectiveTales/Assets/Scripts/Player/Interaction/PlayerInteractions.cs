using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Dialog dialog;

    public GameObject player;

    private const float maxInteractionDistance = 70f;
    private const string pickUpMessage = "Pick up ";

    public CanvasManager canvasManager;

    private Transform cameraTransform;
    private Interactive currentInteractive;
    private bool hasRequirements;
    public bool isConversation = false;
    private List<Interactive> inventory;

    public AudioSource inRange;

    public void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
        currentInteractive = null;
        inventory = new List<Interactive>();
    }

    public void Update()
    {
        CheckForInteractive();
        CheckForInteraction();
        CheckForConversation();
    }

    private void CheckForConversation()
    {
        if (isConversation == true)
            TriggerDialog();
    }

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }

    private void CheckForInteractive()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward,
            out RaycastHit hitInfo, maxInteractionDistance))
        {
            Interactive newInteractive =
                hitInfo.collider.GetComponent<Interactive>();

            if (newInteractive != null && newInteractive != currentInteractive)
            {
                SetCurrentInteractive(newInteractive);
                inRange.Play();
            }               
            else if (newInteractive == null)
                ClearCurrentInteractive();
        }
        else
            ClearCurrentInteractive();
    }

    private void SetCurrentInteractive(Interactive newInteractive)
    {
        currentInteractive = newInteractive;

        if (currentInteractive.type == Interactive.InteractiveType.pickable)
            canvasManager.ShowInteractionPanel(
                pickUpMessage + currentInteractive.inventoryName);
        else if (HasInteractionRequirements())
        {
            hasRequirements = true;
            canvasManager.ShowInteractionPanel(
                currentInteractive.interactionText);
        }
        else
        {
            hasRequirements = false;
            canvasManager.ShowInteractionPanel(
                currentInteractive.requirementText);
        }
    }

    private bool HasInteractionRequirements()
    {
        if (currentInteractive.inventoryRequirements == null)
            return true;

        for (int i = 0; i < currentInteractive.inventoryRequirements.Length; ++i)
            if (!HasInInventory(currentInteractive.inventoryRequirements[i]))
                return false;

        return true;
    }

    private void ClearCurrentInteractive()
    {
        currentInteractive = null;
        canvasManager.HideInteractionPanels();
    }

    private void CheckForInteraction()
    {
        if (Input.GetKeyDown("space") && currentInteractive != null)
        {
            if (currentInteractive.type == Interactive.InteractiveType.pickable)
                Pick();
            else
                Interact();
            SceneController.instance.objetiveDone = true;
        }
    }

    private void Pick()
    {
        AddToInventory(currentInteractive);
        currentInteractive.gameObject.SetActive(false);
    }

    private void Interact()
    {
        if (hasRequirements)
        {
            for (int i = 0; i < currentInteractive.inventoryRequirements.Length; ++i)
                RemoveFromInventory(currentInteractive.inventoryRequirements[i]);

            currentInteractive.Interact();
            player.GetComponent<PlayerInteractions>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private void AddToInventory(Interactive item)
    {
        inventory.Add(item);
        UpdateInventoryIcons();
    }

    private void RemoveFromInventory(Interactive item)
    {
        inventory.Remove(item);
        UpdateInventoryIcons();
    }

    private bool HasInInventory(Interactive item)
    {
        return inventory.Contains(item);
    }

    private void UpdateInventoryIcons()
    {
        canvasManager.ClearInventoryIcons();

        for (int i = 0; i < inventory.Count; ++i)
            canvasManager.SetInventoryIcon(i, inventory[i].inventoryIcon);
    }
}
