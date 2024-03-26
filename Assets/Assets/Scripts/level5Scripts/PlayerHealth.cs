using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3; // Максимальное количество жизней
    private int currentLives; // Текущее количество жизней

    public string heartTag = "Heart"; // Тег для изображений сердец
    private List<GameObject> heartObjects = new List<GameObject>(); // Список объектов сердец на сцене

    public GameObject gameOverPanel; // Панель для отображения при завершении игры
    public Button restartButton; // Кнопка для перезапуска игры
    public RectTransform ScoreTxt;

    void Start()
    {
        currentLives = maxLives; // Установка начального количества жизней

        // Находим все объекты с тегом "Heart" и добавляем их в список
        GameObject[] foundHearts = GameObject.FindGameObjectsWithTag(heartTag);
        foreach (GameObject heart in foundHearts)
        {
            heartObjects.Add(heart);
        }

        // Скрываем панель и кнопку при запуске игры
        gameOverPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            LoseLife(); // Уменьшаем количество жизней при столкновении с камнем
            Destroy(collision.gameObject); // Удаляем камень
        }
    }

    void LoseLife()
    {
        currentLives--; // Уменьшаем количество жизней

        // Удаляем одно изображение сердца из списка и со сцены
        if (heartObjects.Count > 0)
        {
            GameObject heartToRemove = heartObjects[0]; // Берем первый элемент списка
            heartObjects.Remove(heartToRemove);
            Destroy(heartToRemove);
        }

        // Проверяем, остались ли еще жизни у игрока
        if (currentLives <= 0)
        {
            EndGame(); // Если жизней не осталось, завершаем игру
        }
    }

    void EndGame()
    {
        // Показываем панель и кнопку при завершении игры
        gameOverPanel.SetActive(true);
        restartButton.gameObject.SetActive(true);

        // Перемещаем текст счёта в центр экрана
        ScoreTxt.localPosition = new Vector3(-2, 50, 0); // Устанавливаем якорную позицию в центре Canvas
    }

}


