using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_planet : MonoBehaviour
{
    private float timer = 0;
    public float destroy_time = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= destroy_time)
        {
            Destroy(gameObject);
        }
    }
}
