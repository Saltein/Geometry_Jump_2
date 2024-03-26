using UnityEngine;

public class SlowIngredientSpawner : MonoBehaviour
{
    public float minX, maxX; // min-max координаты создания ингредиента по X
    public float spawnInterval = 1.5f; // интервал между спавнами ингредиентов
    public float fallSpeed = 1f; // скорость падения ингредиентов
    private float nextSpawnTime; // время следующего спавна ингредиента
    public Transform ingredientPrefab; // ссылка на префаб ингредиента
    private Camera cam; // ссылка на камеру
    private Transform spawnedIngredient; // ссылка на спавненный ингредиент
    private bool gameEnded = false; // флаг для отслеживания завершения игры

    void Start()
    {
        cam = Camera.main; // ссылка на основную камеру
        nextSpawnTime = Time.time + spawnInterval; // Инициализируем время следующего спавна с учетом начального интервала
    }

    void Update()
    {
        if (!gameEnded && Time.time >= nextSpawnTime)
        {
            // Удаляем предыдущий ингредиент, если он есть
            if (spawnedIngredient != null)
            {
                Destroy(spawnedIngredient.gameObject);
            }

            // Спавним ингредиент только если игра не завершена
            if (!gameEnded)
            {
                // Спавним ингредиент выше верхней границы камеры
                Vector3 spawnPosition = cam.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1.1f, cam.nearClipPlane));

                // Создаем ингредиент из префаба
                spawnedIngredient = Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);

                // Устанавливаем координату Z на 0, чтобы ингредиент не оказался впереди других объектов
                spawnedIngredient.position = new Vector3(spawnedIngredient.position.x, spawnedIngredient.position.y, 0);

                // Устанавливаем скорость падения ингредиента
                Rigidbody2D rb = spawnedIngredient.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.down * fallSpeed;
                }
            }

            // Устанавливаем следующее время спавна с учетом интервала
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    // Метод для вызова при завершении игры
    public void EndGame()
    {
        // Устанавливаем флаг завершения игры
        gameEnded = true;
    }
}



