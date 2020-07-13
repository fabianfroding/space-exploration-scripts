using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 20.0f;

    private void FixedUpdate()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime);
    }
}
