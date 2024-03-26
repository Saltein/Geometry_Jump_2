using UnityEngine;
using TMPro;

public class DoodManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ �� ������ TextMeshPro, ������������ ����
    private int score = 0; // ���� ������

    void Start()
    {
        UpdateScoreUI(); // ��������� ����� ����� ��� ������ ����
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // ��������� ����� �����
        }
        else
        {
            Debug.LogWarning("Score text reference is missing!");
        }
    }

    public void AddScore(int amount)
    {
        score += amount; // ����������� ���� �� �������� ���������� �����
        UpdateScoreUI(); // ��������� ����� ����� ����� ���������
    }
}