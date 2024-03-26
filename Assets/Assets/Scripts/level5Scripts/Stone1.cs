using UnityEngine;

public class SlowStoneSpawner : MonoBehaviour
{
    public float minX, maxX; // min-max координаты создани€ ингредиента по X
    public float startSpawnInterval = 1.5f; // начальный интервал между спавнами ингредиентов
    public float fallSpeed = 1f; // скорость падени€ ингредиентов
    private float nextSpawnTime; // врем€ следующего спавна ингредиента
    public Transform ingredientPrefab; // ссылка на префаб ингредиента
    private Camera cam; // ссылка на камеру
    private Transform spawnedIngredient; // ссылка на спавненный ингредиент
    private bool gameEnded = false; // флаг дл€ отслеживани€ завершени€ игры
    private int score = 0; // количество очков

    void Start()
    {
        cam = Camera.main; // ссылка на основную камеру
        nextSpawnTime = Time.time + startSpawnInterval; // »нициализируем врем€ следующего спавна с учетом начального интервала
    }

    void Update()
    {
        if (!gameEnded && Time.time >= nextSpawnTime)
        {
            // ”дал€ем предыдущий ингредиент, если он есть
            if (spawnedIngredient != null)
            {
                Destroy(spawnedIngredient.gameObject);
            }

            // —павним ингредиент только если игра не завершена
            if (!gameEnded)
            {
                // —павним ингредиенты в количестве, пропорциональном количеству очков
                int numberOfIngredientsToSpawn = Mathf.Max(1, Mathf.RoundToInt(score * 0.1f)); // ”величиваем количество спавненных ингредиентов на 1 за каждые 10 набранных баллов
                for (int i = 0; i < numberOfIngredientsToSpawn; i++)
                {
                    // —павним ингредиент выше верхней границы камеры
                    Vector3 spawnPosition = cam.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1.1f, cam.nearClipPlane));

                    // —оздаем ингредиент из префаба
                    spawnedIngredient = Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);

                    // ”станавливаем координату Z на 0, чтобы ингредиент не оказалс€ впереди других объектов
                    spawnedIngredient.position = new Vector3(spawnedIngredient.position.x, spawnedIngredient.position.y, 0);

                    // ”станавливаем скорость падени€ ингредиента
                    Rigidbody2D rb = spawnedIngredient.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.velocity = Vector2.down * fallSpeed;
                    }
                }
            }

            // ”станавливаем следующее врем€ спавна с учетом интервала
            float modifiedSpawnInterval = startSpawnInterval / (1 + score * 0.1f); // ”величиваем скорость спавна на 10% за каждый набранный балл
            nextSpawnTime = Time.time + modifiedSpawnInterval;
        }
    }

    // ћетод дл€ вызова при завершении игры
    public void EndGame()
    {
        // ”станавливаем флаг завершени€ игры
        gameEnded = true;
    }

    // ћетод дл€ увеличени€ счета
    public void IncreaseScore()
    {
        score++;
    }
}
