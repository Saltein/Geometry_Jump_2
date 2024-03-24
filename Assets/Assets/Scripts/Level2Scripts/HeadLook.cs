using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLook : MonoBehaviour
{
    public Transform head; // Ссылка на Transform головы персонажа

    void Update()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Игнорируем изменения по оси Z, чтобы голова не двигалась вглубь экрана
        cursorPosition.z = 0f;

        // Рассчитываем направление курсора от головы
        Vector3 direction = cursorPosition - head.position;

        // Рассчитываем поворот головы к курсору
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Применяем поворот к голове
        head.rotation = lookRotation;
    }
}
