using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRenderer : MonoBehaviour
{
    Vector3 deathPoint = new Vector3(-45f, 2f, 0);
    Vector3 spawnPoint = new Vector3(99f, 2f, 0);

    public float skySpeed = 1.0f;
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition + Vector3.left * skySpeed * Time.deltaTime;
        transform.position = newPosition;

        if (transform.position.x <= deathPoint.x)
        {
            transform.position = spawnPoint;
        }
    }
}
