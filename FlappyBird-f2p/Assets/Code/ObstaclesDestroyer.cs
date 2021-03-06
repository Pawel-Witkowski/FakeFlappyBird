﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDestroyer : MonoBehaviour {

    public Transform objectToFollow;
    private Vector3 offset;
	void Start () {
        offset = objectToFollow.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = objectToFollow.position - offset;	
	}

    private void OnTriggerEnter(Collider other) {
        GameObject destroyedObstacle = other.gameObject.transform.parent.parent.gameObject;
        Destroy(destroyedObstacle, 1f);
    }
}
