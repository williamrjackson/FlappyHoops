using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeWing : MonoBehaviour {
    public Vector2 explodeForce;

    private void Start()
    {
        GameManager.instance.OnGameOver += Explode;
    }

    private void Explode()
    {
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        transform.parent = null;
        rb.AddForce(explodeForce,ForceMode2D.Impulse);
    }
}
