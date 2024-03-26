using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScr : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public Transform[] spawnPoints; // ������ ������� ��� ������
    public float spawnRate = 2f; // ������� ������ ������ (� ��������)
    public float increaseRate = 10f; // ������� ���������� ���������� ������ (� ��������)
    public float spawnCountIncrease = 1; // ���������� ���������� ������ ��� ������ ����������

    private float nextSpawnTime; // ����� ���������� ������
    private float nextIncreaseTime; // ����� ���������� ���������� ���������� ������

    private int currentSpawnCount = 0; // ������� ���������� ������

    void Start()
    {
        // ������������� ����� ���������� ������ � ���������� ���������� ������
        nextSpawnTime = Time.time + spawnRate;
        nextIncreaseTime = Time.time + increaseRate;
    }

    void Update()
    {
        // ���������, ������ �� ����� ��� ���������� ������ �����
        if (Time.time >= nextSpawnTime)
        {
            // ������� ����� �� ���������� ������
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);

            // ����������� ������� ���������� ������
            currentSpawnCount++;

            // ������������� ����� ���������� ������
            nextSpawnTime = Time.time + spawnRate;

            // ���������, ������ �� ����� ��� ���������� ���������� ������
            if (Time.time >= nextIncreaseTime)
            {
                // ����������� ������� ������ � ���������� ������� ����������
                spawnRate /= spawnCountIncrease;
                nextIncreaseTime = Time.time + increaseRate;

            }
        }
    }
}
