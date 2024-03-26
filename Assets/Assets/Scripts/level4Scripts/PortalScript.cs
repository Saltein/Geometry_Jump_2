using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{

    public List<string> sceneNames = new List<string>();

    private Vector3 currentPosition;
    private Vector3 newPosition;
    private Vector3 targetPos;
    private Transform target;

    public float portalSpeed = 5f;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (SceneManager.GetActiveScene().name == "level5")
        {
            Rigidbody2D rb2d = gameObject.AddComponent<Rigidbody2D>();
            rb2d.mass = 1.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if(collision.collider.tag == "Player")
            {
                OpenRandomScene();
            }
        }
    }

    private void OpenRandomScene()
    {
        int randomIndex = Random.Range(0, sceneNames.Count);
        string randomSceneName = sceneNames[randomIndex];
        if (SceneManager.GetActiveScene().name != randomSceneName)
        {
            SceneManager.LoadScene(randomSceneName);
        }
        else
        {
            OpenRandomScene();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "level4") 
        {
            Lvl4Movament();
        }
        if (SceneManager.GetActiveScene().name == "level2")
        {
            Lvl2Movament();
        }
    }

    private void Lvl4Movament()
    {
        currentPosition = transform.position;
        newPosition = currentPosition + Vector3.left * portalSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
    private void Lvl2Movament()
    {
        targetPos = new Vector3(target.position.x, target.position.y - 3, target.position.z);
        if (target != null)
        {
            Vector3 direction = (targetPos - transform.position).normalized;
            Vector3 moveAmount = direction * portalSpeed * Time.deltaTime;
            transform.Translate(moveAmount);
        }
        else
        {
            Debug.Log("Цель не найдена");
        }
    }
}
