using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactive : MonoBehaviour
{
    public enum InteractiveType { pickable, interactOnce, interactMultiple, indirect };

    public GameObject objHide;
    public GameObject objShow;
    public bool isActive;
    public InteractiveType type;
    public string inventoryName;
    public Sprite inventoryIcon;
    public string requirementText;
    public string interactionText;
    public bool isFinal = false;
    public Interactive[] inventoryRequirements;
    public Interactive[] activationChain;
    public Interactive[] interactionChain;

    public Animator fadeAnimator;
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

        if (objHide != null)
            objHide.SetActive(false);

        if (objShow != null)
            objShow.SetActive(true);

        if (isFinal == true)
            fadeAnimator.SetTrigger("FadeOut");

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

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
