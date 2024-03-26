using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3; // ������������ ���������� ������
    private int currentLives; // ������� ���������� ������

    public string heartTag = "Heart"; // ��� ��� ����������� ������
    private List<GameObject> heartObjects = new List<GameObject>(); // ������ �������� ������ �� �����

    public GameObject gameOverPanel; // ������ ��� ����������� ��� ���������� ����
    public Button restartButton; // ������ ��� ����������� ����
    public RectTransform ScoreTxt;

    void Start()
    {
        currentLives = maxLives; // ��������� ���������� ���������� ������

        // ������� ��� ������� � ����� "Heart" � ��������� �� � ������
        GameObject[] foundHearts = GameObject.FindGameObjectsWithTag(heartTag);
        foreach (GameObject heart in foundHearts)
        {
            heartObjects.Add(heart);
        }

        // �������� ������ � ������ ��� ������� ����
        gameOverPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            LoseLife(); // ��������� ���������� ������ ��� ������������ � ������
            Destroy(collision.gameObject); // ������� ������
        }
    }

    void LoseLife()
    {
        currentLives--; // ��������� ���������� ������

        // ������� ���� ����������� ������ �� ������ � �� �����
        if (heartObjects.Count > 0)
        {
            GameObject heartToRemove = heartObjects[0]; // ����� ������ ������� ������
            heartObjects.Remove(heartToRemove);
            Destroy(heartToRemove);
        }

        // ���������, �������� �� ��� ����� � ������
        if (currentLives <= 0)
        {
            EndGame(); // ���� ������ �� ��������, ��������� ����
        }
    }

    void EndGame()
    {
        // ���������� ������ � ������ ��� ���������� ����
        gameOverPanel.SetActive(true);
        restartButton.gameObject.SetActive(true);

        // ���������� ����� ����� � ����� ������
        ScoreTxt.localPosition = new Vector3(-2, 50, 0); // ������������� ������� ������� � ������ Canvas
    }

}


