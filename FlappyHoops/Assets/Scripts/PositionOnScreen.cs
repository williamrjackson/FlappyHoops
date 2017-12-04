using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOnScreen : MonoBehaviour {
    [Range(-1, 2)]
    public float xOffset = .5f;
    [Range(-1, 2)]
    public float yOffset = .5f;
    public bool onUpdate;

    private void Start()
    {
        SetPosition();
    }
    // Use this for initialization
    void Update () {
        if (onUpdate)
        {
            SetPosition();
        }
    }
    void SetPosition()
    {
        float screenX = Camera.main.ScreenToWorldPoint(new Vector3(Mathf.LerpUnclamped(0, Screen.width, xOffset), transform.position.y, transform.position.z)).x;
        float screenY = Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, Mathf.LerpUnclamped(0, Screen.height, yOffset), transform.position.z)).y;
        transform.position = new Vector3(screenX, screenY, transform.position.z);
    }
}
