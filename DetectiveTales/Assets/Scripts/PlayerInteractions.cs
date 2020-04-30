using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    private const float maxInteractionDistance = 2.0f;
    private const string pickUpMessage = "Pick up ";

    //public CanvasManager canvasManager;
    public Button disable;

    private Transform cameraTransform;
    private Interactive currentInteractive;
    private bool hasRequirements;
    private List<Interactive> inventory;

    private AudioSource audioSource;

    public void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
        currentInteractive = null;
        inventory = new List<Interactive>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        CheckForInteractive();
        CheckForInteraction();
    }

    private void CheckForInteractive()
    {
        if (Physics.Raycast(cameraTransform.position,
            cameraTransform.forward,
            out RaycastHit hitInfo,
            maxInteractionDistance))
        {
            Interactive newInteractive = hitInfo.collider.GetComponent<Interactive>();

            if (newInteractive != null && newInteractive != currentInteractive)
                SetCurrentInteractive(newInteractive);
            else if (newInteractive == null)
                ClearCurrentInteractive();
        }
        else
            ClearCurrentInteractive();
    }

    private void SetCurrentInteractive(Interactive newInteractive)
    {
        currentInteractive = newInteractive;

        /*if (currentInteractive.type == Interactive.InteractiveType.pickable)
            canvasManager.ShowInteractionPanel(pickUpMessage + currentInteractive.inventoryName);
        else if (HasInteractionRequirements())
        {
            hasRequirements = true;
            canvasManager.ShowInteractionPanel(currentInteractive.interactionText);
        }
        else
        {
            hasRequirements = false;
            canvasManager.ShowInteractionPanel(currentInteractive.requirementText);
        }*/
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
        //canvasManager.HideInteractionPanel();
    }

    private void CheckForInteraction()
    {
        if (Input.GetMouseButtonDown(0) && currentInteractive != null)
        {
            if (currentInteractive.type == Interactive.InteractiveType.pickable)
                Pick();
            else
                Interact();
        }
    }

    private void Pick()
    {
        AddToInventory(currentInteractive);
        currentInteractive.gameObject.SetActive(false);
        //FindObjectOfType<AudioManager>().Play("PickUp");
    }

    private void Interact()
    {
        if (hasRequirements)
        {
            /*for (int i = 0; i < currentInteractive.inventoryRequirements.Length; ++i)
                RemoveFromInventory(currentInteractive.inventoryRequirements[i]);*/

            currentInteractive.Interact();
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
        /*canvasManager.ClearInventoryIcons();

        for (int i = 0; i < inventory.Count; i++)
            canvasManager.SetInventoryIcon(i, inventory[i].inventoryIcon);*/
    }
}
