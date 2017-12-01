using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour {
    public CollisionRecorder rim1;
    public CollisionRecorder rim2;
    public CollisionRecorder throughTrigger;
    public Transform ball;
    public float passedRange;
    public float spawnRange;
    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;

    [HideInInspector]
    public int index;
    [HideInInspector]
    public int consecutiveCount = 1;

    private bool hasSpawned = false;
    private Hoop spawnHoop;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (ball.position.x > transform.position.x + passedRange)
        {
            GameManager.instance.isGameOver = true;
        }

        if (!hasSpawned && ball.position.x > transform.position.x + spawnRange)
        {
            GameObject spawn = Instantiate(gameObject);
            spawn.transform.position = new Vector3(transform.position.x + 5f, Random.Range(-2, 2), 0f);
            spawnHoop = spawn.GetComponent<Hoop>();
            spawnHoop.index = index + 1;
            spawn.name = "Spawn" + spawnHoop.index;
            hasSpawned = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (throughTrigger.GetHasCollided())
        {
            if (!rim1.GetHasCollided() && !rim2.GetHasCollided())
            {
                if (spawnHoop != null)
                    spawnHoop.consecutiveCount = consecutiveCount + 1;

                if (spawnHoop.consecutiveCount == 2)
                {
                    GameManager.instance.ChangeScore(4);
                    particle1.SetActive(true);
                    particle2.SetActive(false);
                    particle3.SetActive(false);
                }
                else if (spawnHoop.consecutiveCount == 3)
                {
                    GameManager.instance.ChangeScore(6);
                    particle1.SetActive(false);
                    particle2.SetActive(true);
                    particle3.SetActive(false);
                }
                else if (spawnHoop.consecutiveCount > 2)
                {
                    GameManager.instance.ChangeScore(8);
                    particle1.SetActive(false);
                    particle2.SetActive(false);
                    particle3.SetActive(true);
                }
            }
            else
            {
                if (spawnHoop != null)
                    spawnHoop.consecutiveCount = 1;
                GameManager.instance.ChangeScore(2);
                particle1.SetActive(false);
                particle2.SetActive(false);
                particle3.SetActive(false);
            }

        }
        else
        {
            GameManager.instance.isGameOver = true;
        }
        Destroy(gameObject);
    }
}
