using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public int health = 1; // Здоровье врага
    private DoodManager gameManager; // Ссылка на менеджер игры

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<DoodManager>(); // Находим GameManager в сцене
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1); // Уменьшаем здоровье врага на 1 при столкновении с пулей
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // Уменьшаем здоровье врага

        if (health <= 0)
        {
            Destroy(gameObject); // Если здоровье врага меньше или равно 0, уничтожаем врага
            gameManager.AddScore(10); // Увеличиваем счет игрока через GameManager
        }
    }
}
