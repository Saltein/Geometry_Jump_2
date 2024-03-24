using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject collisionPanel; // ������, ������� ���������� ��� ������������
    public string enemyTag = "Enemy"; // ��� ����� (Enemy)

    private void Start()
    {
        collisionPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            Time.timeScale = 0f; // ������������� ������� �����

            // ���������� ������ ��� ������������
            if (collisionPanel != null)
            {
                collisionPanel.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        // �������������� �������� ��� �������� ����
        Time.timeScale = 1f; // ������������ ������� �����
        collisionPanel.SetActive(false); // �������� ������ ��� ��������
    }
}
