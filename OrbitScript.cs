﻿using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    [SerializeField]
    private GameObject orbitObject;

    [SerializeField]
    private float orbitSpeed = 0.01f; // In case forgetting to set individual speed in scene.

    [SerializeField]
    private Vector3 orbitDirection = Vector3.up;

    private void Update()
    {
        transform.RotateAround(orbitObject.transform.position, orbitDirection, orbitSpeed * Time.deltaTime);
    }
}
