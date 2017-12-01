using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAtScreenBottom : MonoBehaviour {
    public float offset = 0;
	// Use this for initialization
	void Start () {
        float screenBottomY = Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, 0, transform.position.z)).y;
        transform.position = new Vector3(transform.position.x, screenBottomY + offset, transform.position.z);
    }
}
