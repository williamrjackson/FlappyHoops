using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRecorder : MonoBehaviour {
    private bool hasCollided = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasCollided = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasCollided = true;
    }

    public bool GetHasCollided()
    {
        return hasCollided;
    }
}
