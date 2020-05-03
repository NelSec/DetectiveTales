using UnityEngine;

public class Interactive : MonoBehaviour
{
    public enum InteractiveType { pickable, interactOnce, interactMultiple, indirect };

    public GameObject obj1;
    public GameObject obj2;
    public bool isActive;
    public InteractiveType type;
    public string inventoryName;
    public Sprite inventoryIcon;
    public string requirementText;
    public string interactionText;
    public Interactive[] inventoryRequirements;
    public Interactive[] activationChain;
    public Interactive[] interactionChain;

    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Interact()
    {
        if (animator != null)
            animator.SetTrigger("Interact");

        if (obj1 != null)
            obj1.SetActive(false);

        if (obj2 != null)
            obj2.SetActive(true);

        if (isActive)
        {
            ProcessActivationChain();
            ProcessInteractionChain();

            if (type == InteractiveType.interactOnce)
                GetComponent<Collider>().enabled = false;
        }
    }

    private void ProcessActivationChain()
    {
        if (activationChain != null)
        {
            for (int i = 0; i < activationChain.Length; ++i)
                activationChain[i].Activate();
        }
    }

    private void ProcessInteractionChain()
    {
        if (interactionChain != null)
        {
            for (int i = 0; i < interactionChain.Length; ++i)
                interactionChain[i].Interact();
        }
    }
}
