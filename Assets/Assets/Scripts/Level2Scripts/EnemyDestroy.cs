using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public int health = 1; // �������� �����
    private DoodManager gameManager; // ������ �� �������� ����

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<DoodManager>(); // ������� GameManager � �����
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1); // ��������� �������� ����� �� 1 ��� ������������ � �����
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // ��������� �������� �����

        if (health <= 0)
        {
            Destroy(gameObject); // ���� �������� ����� ������ ��� ����� 0, ���������� �����
            gameManager.AddScore(10); // ����������� ���� ������ ����� GameManager
        }
    }
}