using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Transform targetTransform;
    Vector3 direction;

    public AudioSource gun;

    private float rayDistance;
    public float timeLeft = 10f;
    [SerializeField]
    private int killCount;
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject enemyPrefab;

    public bool allKilled;

    public Animator gunAnim;

    RaycastHit hit;

    private static RayCast _instance;

    public static RayCast instance
    {
        get { return _instance; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        allKilled = false;
        rayDistance = 100f;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        direction = targetTransform.position - transform.position;

        Debug.DrawRay(transform.position, direction * rayDistance, Color.magenta);

        if (Physics.Raycast(transform.position, direction * rayDistance, out hit, rayDistance) && hit.transform.tag == "Enemy" && Input.GetKeyDown("space"))
        {
            Destroy(hit.transform.gameObject, 10f);
            gun.Play();
            AudioManager.instance.PlayDeathSound();
            gunAnim.SetTrigger("Kill");
            killCount++;
        }

        if (killCount == enemies.Length)
        {
            SceneController.instance.objetiveDone = true;
            allKilled = true;
        }
        else if(timeLeft <= 0)
        {
            foreach(GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            GameObject enemyInspector = GameObject.Find("Enemies1(Clone)");
            GameObject otherEnemyInspector = GameObject.Find("Enemies2(Clone)");
            Destroy(enemyInspector);
            Destroy(otherEnemyInspector);
            Instantiate(enemyPrefab);

            killCount = 0;
            timeLeft = 10f;
        }
            
    }
}
