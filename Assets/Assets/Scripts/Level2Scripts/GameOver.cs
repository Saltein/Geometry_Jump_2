using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject collisionPanel; // Панель, которая появляется при столкновении
    public string enemyTag = "Enemy"; // Тэг врага (Enemy)

    private void Start()
    {
        collisionPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            Time.timeScale = 0f; // Останавливаем игровое время

            // Активируем панель при столкновении
            if (collisionPanel != null)
            {
                collisionPanel.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        // Дополнительные действия при рестарте игры
        Time.timeScale = 1f; // Возобновляем игровое время
        collisionPanel.SetActive(false); // Скрываем панель при рестарте
    }
}
