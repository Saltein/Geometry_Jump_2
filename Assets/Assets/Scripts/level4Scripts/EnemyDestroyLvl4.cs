using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyLvl4 : MonoBehaviour
{

    public float scoreForEnemy = 150f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            Debug.Log("Hit = " + collision.collider.tag);
            ScoreScriptMain._score += scoreForEnemy;
            Destroy(gameObject);
        }
    }
}
