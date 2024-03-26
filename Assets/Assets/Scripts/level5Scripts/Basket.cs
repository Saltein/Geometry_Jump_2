using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Basket : MonoBehaviour
{
    private int score = 0; // ���� ������
    public TextMeshProUGUI scoreText;
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ��� ������������� ������ - ����������
        if (collision.gameObject.CompareTag("Ingredient"))
        {
            // ����������� ����
            ScoreScriptMain._score += 500;

            // ������� ����������
            Destroy(collision.gameObject);

            // ��������� ����������� �����
          
            scoreText.text = "Score:" + ScoreScriptMain._score.ToString();

        }
    }

    
}



