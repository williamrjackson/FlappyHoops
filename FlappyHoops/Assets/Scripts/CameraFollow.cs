using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour { 
    public Transform followee;
    private float xOffset;
    private void Start()
    {
        // get relative position of camera from player/sphere
        xOffset = transform.position.x + followee.position.x;
    }

    // Use lateupdate to ensure positioning of sphere is complete
    void LateUpdate () {
        // Move to new poition
        transform.position = new Vector3(followee.position.x - xOffset, transform.position.y, transform.position.z);
	}
}
