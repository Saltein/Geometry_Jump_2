using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDoodler : MonoBehaviour
{
    public float flySpeed; // скорость полета по Y
    public GameObject Panel; // ссылка на Canvas.Panel
    public RectTransform ScoreTxt; // ссылка на Canvas.Text(TMP)
    private Rigidbody2D rb;
    // Скорость движения объекта
    public float moveSpeed1 = 15f;

    // Определение текущей позиции мыши
    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // получаем ссылку на компонент "Rigidbody2D"
    }


    void Update()
    {
        Vector2 velocity = rb.velocity; // Velocity = вектор текущей скорости объекта

        //if (Input.GetMouseButton(0)) //проверка на нажатие ЛКМ, Input.GetMouseButton(0)
        //{
        //    if (Input.mousePosition.x < Screen.width / 2) // проверка позиции мыши по X (по горизонтали) меньше половины ширины экрана
        //    {
        //        velocity.x = -moveSpeed; // составляющая X Velocity = отрицательная скорость движения
        //    }
        //    else
        //    {
        //        velocity.x = moveSpeed; // составляющая X Velocity = положительная скорость движения
        //    }
        //    rb.velocity = velocity; // задаём вектор текущей скорости объекта
        //}
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.position.y, 10));

        // Ограничиваем движение объекта по оси Y
        targetPosition.y = transform.position.y;

        // Вычисляем направление движения к мыши
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        // Вычисляем новую позицию объекта
        Vector3 newPosition = transform.position + moveDirection * moveSpeed1 * Time.deltaTime;

        // Применяем новую позицию
        transform.position = newPosition;

        //else
        //{
        //    velocity.x *= moveDecreaser; // корректируем составляющую X Velocity
        //    rb.velocity = velocity; // замедляем скорость движения по X (если moveDecreaser < 1)
        //}

        velocity.y = flySpeed; // составляющая Y Velocity = сила полета
        rb.velocity = velocity; // задаём вектор текущей скорости объекта

        if (gameObject.transform) // существует ли персонаж, т.к. он удалится при падении в OnTriggerEnter2D
        {
            if (gameObject.transform.position.y > transform.position.y) // координата персонажа по Y > координата камеры по Y
            {
                Vector3 CameraPosition = gameObject.transform.position; // CameraPosition = текущие координаты персонажа
                CameraPosition.x = 0; // координата по X всегда = 0, чтобы камера не смещалась по X
                CameraPosition.z = transform.position.z; // сохраняем координаты камеры по Z
                transform.position = CameraPosition; // меняем координаты камеры (т.е. меняем только координату по Y)
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // столкновение с твёрдым телом
    {
        if (collision.gameObject.tag == "vrag") // проверка, является ли другой объект врагом
        {
            Panel.SetActive(true); // активируем Canvas.Panel
            ScoreTxt.localPosition = new Vector3(20, 150, 0);
            Destroy(gameObject); // уничтожение объекта дудлера
        }
    }
}

