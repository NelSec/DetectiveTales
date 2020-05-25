using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ChaseMovement movement;

    public AudioSource crash;

    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }
    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
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
