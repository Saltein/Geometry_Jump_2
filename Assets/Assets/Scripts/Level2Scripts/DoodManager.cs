using UnityEngine;
using TMPro;

public class DoodManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Ссылка на объект TextMeshPro, отображающий счет
    private int score = 0; // Счет игрока

    void Start()
    {
        UpdateScoreUI(); // Обновляем текст счета при старте игры
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Обновляем текст счета
        }
        else
        {
            Debug.LogWarning("Score text reference is missing!");
        }
    }

    public void AddScore(int amount)
    {
        score += amount; // Увеличиваем счет на заданное количество очков
        UpdateScoreUI(); // Обновляем текст счета после изменения
    }
}