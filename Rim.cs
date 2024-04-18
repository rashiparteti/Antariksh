using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rim : MonoBehaviour

{
    public float rotationSpeed = 45f; // Adjust this to change rotation speed

    void Update()
    {
        // Rotate the object in the anticlockwise direction around its up axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

