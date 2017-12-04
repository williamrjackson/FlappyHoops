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
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;

    [HideInInspector]
    public int index;
    [HideInInspector]
    public int consecutiveCount = 1;

    private bool hasSpawned = false;
    private Hoop spawnHoop;

    // Update is called once per frame
    void Update () {
		if (ball.position.x > transform.position.x + passedRange)
        {
            GameManager.instance.SetGameOver();
        }

        if (!hasSpawned && ball.position.x > transform.position.x + spawnRange)
        {
            GameObject spawn = Instantiate(gameObject);
            spawn.GetComponent<PositionOnScreen>().enabled = false;
            spawn.transform.position = new Vector3(transform.position.x + 5f, Random.Range(-2, 2), 0f);
            spawnHoop = spawn.GetComponent<Hoop>();
            spawnHoop.index = index + 1;
            spawn.name = "Spawn" + spawnHoop.index;
            hasSpawned = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (throughTrigger.GetHasCollided() && spawnHoop != null)
        {
            if (!rim1.GetHasCollided() && !rim2.GetHasCollided())
            {
                spawnHoop.consecutiveCount = consecutiveCount + 1;

                if (spawnHoop.consecutiveCount == 2)
                {
                    GameManager.instance.ChangeScore(4);
                    particle1.Play();
                    particle2.Stop();
                    particle3.Stop();
                }
                else if (spawnHoop.consecutiveCount == 3)
                {
                    GameManager.instance.ChangeScore(6);
                    particle1.Stop();
                    particle2.Play();
                    particle3.Stop();
                }
                else if (spawnHoop.consecutiveCount > 2)
                {
                    GameManager.instance.ChangeScore(8);
                    particle1.Stop();
                    particle2.Stop();
                    particle3.Play();
                }
            }
            else
            {
                spawnHoop.consecutiveCount = 1;
                GameManager.instance.ChangeScore(2);
                particle1.Stop();
                particle2.Stop();
                particle3.Stop();
            }

        }
        else
        {
            GameManager.instance.SetGameOver();
        }
        Destroy(gameObject);
    }
}
