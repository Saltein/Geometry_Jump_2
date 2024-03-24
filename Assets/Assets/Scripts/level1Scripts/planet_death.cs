using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet_death : MonoBehaviour
{
    public Transform Player; // персонаж
    public float speed; // скорость следования камеры за персонажем
    public GameObject Panel; // ссылка на Canvas.Panel
    public RectTransform ScoreTxt; // ссылка на Canvas.Text(TMP)
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false); // деактивируем Canvas.Panel
    }
    private void OnTriggerEnter2D(Collider2D collision) // столкновение с твёрдым телом
    {
        if (collision.gameObject.GetComponent<Doodler>()) // проверка, является ли другой объект планетой
        {
            Panel.SetActive(true); // активируем Canvas.Panel
            ScoreTxt.localPosition = new Vector3(20, 150, 0);
            Destroy(gameObject); // уничтожение объекта дудлера
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Player) // существует ли персонаж, т.к. он удалится при падении в OnTriggerEnter2D
        {
            if (Player.position.y > transform.position.y) // координата персонажа по Y > координата камеры по Y
            {
                Vector3 CameraPosition = Player.position; // CameraPosition = текущие координаты персонажа
                CameraPosition.x = 0; // координата по X всегда = 0, чтобы камера не смещалась по X
                CameraPosition.z = transform.position.z; // сохраняем координаты камеры по Z
                transform.position = CameraPosition; // меняем координаты камеры (т.е. меняем только координату по Y)
            }
        }
    }
}
