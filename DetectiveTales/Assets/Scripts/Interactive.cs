using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactive : MonoBehaviour
{
    public enum InteractiveType { pickable, interactOnce, interactMultiple, indirect };

    public GameObject firstObjectHide;
    public GameObject secondObjectHide;
    public GameObject thirdObjectHide;
    public GameObject fourthObjectHide;
    public GameObject fifthObjectHide;
    public GameObject sixthObjectHide;
    public GameObject firstObjectShow;
    public GameObject secondObjectShow;
    public GameObject thirdObjectShow;
    public GameObject fourthObjectShow;
    public GameObject fifthObjectShow;
    public GameObject sixthObjectShow;

    public bool isEntering = false;
    public bool isActive;
    public InteractiveType type;
    public string inventoryName;
    public Sprite inventoryIcon;
    public string requirementText;
    public string interactionText;
    public Interactive[] inventoryRequirements;
    public Interactive[] activationChain;
    public Interactive[] interactionChain;

    private int sceneToLoad;

    public Animator fadeAnimator;
    private Animator animator;
    public AudioSource audioSource;

    public void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Interact()
    {
        if (animator != null && firstObjectHide == null)
        {
            animator.SetTrigger("Interact");
            //FindObjectOfType<AudioManager>().Play("DoorBeep");
        }
        else if (animator != null && firstObjectHide != null)
        {
            animator.SetTrigger("Interact");
        }

        if (isEntering == true)
            fadeAnimator.SetTrigger("FadeOut");

        if (fadeAnimator != null)
            isEntering = true;

        if (firstObjectHide != null)
            firstObjectHide.SetActive(false);

        if (secondObjectHide != null)
            secondObjectHide.SetActive(false);

        if (thirdObjectHide != null)
            thirdObjectHide.SetActive(false);

        if (fourthObjectHide != null)
            fourthObjectHide.SetActive(false);

        if (fifthObjectHide != null)
            fifthObjectHide.SetActive(false);

        if (sixthObjectHide != null)
            sixthObjectHide.SetActive(false);

        if (firstObjectShow != null)
            firstObjectShow.SetActive(true);

        if (secondObjectShow != null)
            secondObjectShow.SetActive(true);

        if (thirdObjectShow != null)
            thirdObjectShow.SetActive(true);

        if (fourthObjectShow != null)
            fourthObjectShow.SetActive(true);

        if (fifthObjectShow != null)
            fifthObjectShow.SetActive(true);

        if (sixthObjectShow != null)
            sixthObjectShow.SetActive(true);

        if (isActive)
        {
            ProcessActivationChain();
            ProcessInteractionChain();

            if (type == InteractiveType.interactOnce)
            {
                GetComponent<Collider>().enabled = false;
                audioSource.Play();
            }
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