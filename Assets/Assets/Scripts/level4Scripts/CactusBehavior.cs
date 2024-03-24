using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusBehavior : MonoBehaviour
{
    public float cactusSpeed = 10f;

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition + Vector3.left * cactusSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}
