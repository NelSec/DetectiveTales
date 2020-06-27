using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ChaseMovement movement;

    public AudioSource crash;

    private Vector3 initialPos;

    public bool crashed = false;

    private static PlayerCollision _instance;

    public static PlayerCollision instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        _instance = this;
        initialPos = transform.position;
    }
    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            crashed = true;
            transform.position = initialPos;
            crash.Play();
            //movement.enabled = false;
            //FindObjectOfType<GameManager>().GameOver();
        }
        if (collisionInfo.collider.tag == "End")
        {
            movement.enabled = false;
            SceneController.instance.objetiveDone = true;
        }
    }
}
