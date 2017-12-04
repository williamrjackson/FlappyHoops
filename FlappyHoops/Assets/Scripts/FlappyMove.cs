using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyMove : MonoBehaviour {
    [SerializeField]
    private string m_Input;
    [SerializeField]
    private float m_VerticalBumpAmount = 8.5f;
    [SerializeField]
    private float m_HorizontalBumpAmount = 2f;
    [SerializeField]
    private float m_MaxSpeed = 3f;
    [SerializeField]
    private float m_GravityScale = 3f;
    [SerializeField]
    private Animator m_Animator;

    private Rigidbody2D m_RigidBody;

    // Use this for initialization
    void Start () {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_RigidBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown(m_Input) && !GameManager.instance.GetGameOver())
        {
            Bump();
        }
        Vector2 forwardAdjustment = Vector2.zero;
        if (m_RigidBody.velocity.x > m_MaxSpeed)
        {
            forwardAdjustment.x += -1;
            m_RigidBody.velocity += forwardAdjustment;
        }
    }

    private void Bump()
    {
        m_Animator.Play("FlapWings");
        m_RigidBody.gravityScale = m_GravityScale;
        m_RigidBody.velocity = Vector2.zero;
        m_RigidBody.AddForce((Vector3.up * m_VerticalBumpAmount + Vector3.right * m_HorizontalBumpAmount), ForceMode2D.Impulse);
    }
}
