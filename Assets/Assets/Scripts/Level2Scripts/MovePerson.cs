using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePerson : MonoBehaviour
{
    public float speed = 5f; // Скорость движения дудлера

    void Update()
    {
        // Получаем ввод с клавиатуры по оси горизонтали
        float horizontalInput = Input.GetAxis("Horizontal");

        // Рассчитываем вектор движения на основе ввода
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;

        // Применяем движение к позиции дудлера
        transform.position += movement;
    }
}
