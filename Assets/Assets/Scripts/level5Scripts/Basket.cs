using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Basket : MonoBehaviour
{
    private int score = 0; // Очки игрока
    public TextMeshProUGUI scoreText;
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, что столкнувшийся объект - ингредиент
        if (collision.gameObject.CompareTag("Ingredient"))
        {
            // Увеличиваем счет
            ScoreScriptMain._score += 500;

            // Удаляем ингредиент
            Destroy(collision.gameObject);

            // Обновляем отображение счета
          
            scoreText.text = "Score:" + ScoreScriptMain._score.ToString();

        }
    }

    
}



