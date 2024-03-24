using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    public GameObject cactusPrefab;
    public float probability = 0.8f;
    public float minimalSpawnFreq = 1f;

    private float minimalSpawnFreq_t;

    private float timer = 0f;

    private void Start()
    {
        minimalSpawnFreq_t = minimalSpawnFreq;
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= minimalSpawnFreq)
        {
            if (Random.value < probability)
            {
                Instantiate(cactusPrefab, transform.position, Quaternion.identity);
                timer = 0f;
                minimalSpawnFreq = Random.value * minimalSpawnFreq_t + minimalSpawnFreq_t * 0.8f;
            }
        }
    }
}
