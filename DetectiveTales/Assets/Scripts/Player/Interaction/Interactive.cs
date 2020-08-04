using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactive : MonoBehaviour
{
    public enum InteractiveType { pickable, interactOnce, interactMultiple, indirect };

    public GameObject firstObjHide;
    public GameObject secondObjHide;
    public GameObject thirdObjHide;
    public GameObject firstObjShow;
    public GameObject secondObjShow;
    public GameObject thirdObjShow;
    public GameObject transition;

    public AudioSource openDoor;

    public bool isActive;
    public InteractiveType type;
    public string inventoryName;
    public Sprite inventoryIcon;
    public string requirementText;
    public string interactionText;
    public bool isFinal = false;
    //public bool toTransition;
    public Interactive[] inventoryRequirements;
    public Interactive[] activationChain;
    public Interactive[] interactionChain;

    public Animator CharAnim;
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

        if (firstObjHide != null)
            firstObjHide.SetActive(false);

        if (secondObjHide != null)
            secondObjHide.SetActive(false);

        if (thirdObjHide != null)
            thirdObjHide.SetActive(false);

        if (firstObjShow != null)
            firstObjShow.SetActive(true);

        if (secondObjShow != null)
            secondObjShow.SetActive(true);

        if (thirdObjShow != null)
            thirdObjShow.SetActive(true);

        if (openDoor != null)
            openDoor.Play();

        if (isFinal == true)
            fadeAnimator.SetTrigger("FadeOut");

        if (isActive)
        {
            ProcessActivationChain();
            ProcessInteractionChain();
            //toTransition = true;
            //Invoke("SetBoolBack", 1);

            if (type == InteractiveType.interactOnce)
                GetComponent<Collider>().enabled = false;
        }
    }

    /*private void SetBoolBack()
    {
        toTransition = false;
    }*/

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

    private void OnTriggerEnter(Collider other)
    {
        CharAnim.SetBool("Reaching", true);
    }

    private void OnTriggerExit(Collider other)
    {
        CharAnim.SetBool("Reaching", false);
    }
}
