using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public float bulletSpeed = 10f; // Скорость полета пули
    public float maxDistance = 10f; // Максимальное расстояние полета пули

    void Update()
    {
        // Проверяем, нажата ли клавиша для стрельбы (например, левая кнопка мыши)
        if (Input.GetButtonDown("Fire1"))
        {
            // Создаем копию пули из префаба
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Получаем позицию курсора в мировых координатах
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0f;

            // Рассчитываем направление полета пули к курсору
            Vector3 shootDirection = (cursorPosition - transform.position).normalized;

            // Применяем скорость полета к направлению пули
            Vector3 velocity = shootDirection * bulletSpeed;

            // Передаем скорость пули в ее Rigidbody2D (если он есть)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = velocity;
            }

            // Уничтожаем пулю через определенное время или при достижении максимального расстояния
            Destroy(bullet, maxDistance / bulletSpeed);
        }
    }
}
