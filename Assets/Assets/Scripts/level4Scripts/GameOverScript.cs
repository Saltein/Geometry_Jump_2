using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{


    public GameObject Panel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Time.timeScale = 0f;
            Panel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
