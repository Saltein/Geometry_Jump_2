using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP : MonoBehaviour
{
    public float speed = 10f; // Скорость движения дудлера

    void Update()
    {
        // Получаем ввод с клавиатуры по оси горизонтали
        float horizontalInput = Input.GetAxis("Horizontal");

        // Рассчитываем вектор движения на основе ввода
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;


        // Получаем ширину экрана в мировых координатах
        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize;

        // Ограничиваем координату X позиции персонажа в пределах ширины экрана
        float clampedX = Mathf.Clamp(transform.position.x + movement.x, -screenWidth, screenWidth);

        // Применяем ограниченное движение к позиции дудлера
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}

