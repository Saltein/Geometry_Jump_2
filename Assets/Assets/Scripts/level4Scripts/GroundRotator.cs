using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotator : MonoBehaviour
{

    public float rotationSpeed = -60f;

    void Update()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        float newRotation = currentRotation + rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(85, 0, newRotation);
    }
}
