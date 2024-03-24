using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreEnemy : MonoBehaviour
{

    private DoodManager doodManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            doodManager.AddScore(100);
        }
    }
}
