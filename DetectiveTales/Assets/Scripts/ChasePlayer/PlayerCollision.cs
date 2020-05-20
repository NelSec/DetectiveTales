using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ChaseMovement movement; 

    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
        if (collisionInfo.collider.tag == "End")
        {
            movement.enabled = false;
            SceneController.instance.objetiveDone = true;
        }
    }
}
