using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOnScreen : MonoBehaviour {
    [Range(0, 1)]
    public float xOffset = .5f;
    [Range(0, 1)]
    public float yOffset = .5f;

    // Use this for initialization
    void Update () {
        float screenX = Camera.main.ScreenToWorldPoint(new Vector3(Mathf.Lerp(0, Screen.width, xOffset), transform.position.y, transform.position.z)).x;
        float screenY = Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, Mathf.Lerp(0, Screen.height, yOffset), transform.position.z)).y;
        transform.position = new Vector3(screenX, screenY, transform.position.z);
    }
}
