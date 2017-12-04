using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderKill : MonoBehaviour {
    public GameObject ball;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == ball)
        {
            //Kill Ball
            GameManager.instance.SetGameOver();
        }
    }
}
