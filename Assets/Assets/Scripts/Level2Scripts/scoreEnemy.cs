using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreEnemy : MonoBehaviour
{
    public float score = 100f;
    private DoodManager doodManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ScoreScriptMain._score += score;
        }
    }
}
