using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScr : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Transform[] spawnPoints; // Массив спавнов для врагов
    public float spawnRate = 2f; // Частота спавна врагов (в секундах)
    public float increaseRate = 10f; // Частота увеличения количества врагов (в секундах)
    public float spawnCountIncrease = 1; // Увеличение количества врагов при каждом увеличении

    private float nextSpawnTime; // Время следующего спавна
    private float nextIncreaseTime; // Время следующего увеличения количества врагов

    private int currentSpawnCount = 0; // Текущее количество врагов

    void Start()
    {
        // Устанавливаем время следующего спавна и увеличения количества врагов
        nextSpawnTime = Time.time + spawnRate;
        nextIncreaseTime = Time.time + increaseRate;
    }

    void Update()
    {
        // Проверяем, прошло ли время для следующего спавна врага
        if (Time.time >= nextSpawnTime)
        {
            // Спавним врага из случайного спавна
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);

            // Увеличиваем текущее количество врагов
            currentSpawnCount++;

            // Устанавливаем время следующего спавна
            nextSpawnTime = Time.time + spawnRate;

            // Проверяем, прошло ли время для увеличения количества врагов
            if (Time.time >= nextIncreaseTime)
            {
                // Увеличиваем частоту спавна и сбрасываем счетчик увеличения
                spawnRate /= spawnCountIncrease;
                nextIncreaseTime = Time.time + increaseRate;

            }
        }
    }
}
