using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleBehaavior : MonoBehaviour
{
    public float cactusSpeed = 10f;

    private Vector3 newPosition;
    private Vector3 currentPosition;

    void Update()
    {
        currentPosition = transform.position;

        newPosition = currentPosition + Vector3.left * cactusSpeed * Time.deltaTime;

        
        transform.position = newPosition;
    }
}
