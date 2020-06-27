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
    public Animator enemyKill;
    public Animator enemyKill2;
    public Animator enemyKill3;
    public Animator enemyKill4;
    public Animator enemyKill5;

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
            Destroy(hit.transform.gameObject, 5f);
            gun.Play();
            AudioManager.instance.PlayDeathSound();
            gunAnim.SetTrigger("Kill");
            enemyKill.SetTrigger("Dead");
            killCount++;
        }

        if (Physics.Raycast(transform.position, direction * rayDistance, out hit, rayDistance) && hit.transform.tag == "Enemy2" && Input.GetKeyDown("space"))
        {
            Destroy(hit.transform.gameObject, 5f);
            gun.Play();
            AudioManager.instance.PlayDeathSound();
            gunAnim.SetTrigger("Kill");
            enemyKill2.SetTrigger("Dead");
            killCount++;
        }

        if (Physics.Raycast(transform.position, direction * rayDistance, out hit, rayDistance) && hit.transform.tag == "Enemy3" && Input.GetKeyDown("space"))
        {
            Destroy(hit.transform.gameObject, 5f);
            gun.Play();
            AudioManager.instance.PlayDeathSound();
            gunAnim.SetTrigger("Kill");
            enemyKill3.SetTrigger("Dead");
            killCount++;
        }

        if (Physics.Raycast(transform.position, direction * rayDistance, out hit, rayDistance) && hit.transform.tag == "Enemy4" && Input.GetKeyDown("space"))
        {
            Destroy(hit.transform.gameObject, 5f);
            gun.Play();
            AudioManager.instance.PlayDeathSound();
            gunAnim.SetTrigger("Kill");
            enemyKill4.SetTrigger("Dead");
            killCount++;
        }

        if (Physics.Raycast(transform.position, direction * rayDistance, out hit, rayDistance) && hit.transform.tag == "Enemy5" && Input.GetKeyDown("space"))
        {
            Destroy(hit.transform.gameObject, 5f);
            gun.Play();
            AudioManager.instance.PlayDeathSound();
            gunAnim.SetTrigger("Kill");
            enemyKill5.SetTrigger("Dead");
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
