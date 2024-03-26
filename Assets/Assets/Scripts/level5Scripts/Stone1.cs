using UnityEngine;

public class SlowStoneSpawner : MonoBehaviour
{
    public float minX, maxX; // min-max ���������� �������� ����������� �� X
    public float startSpawnInterval = 1.5f; // ��������� �������� ����� �������� ������������
    public float fallSpeed = 1f; // �������� ������� ������������
    private float nextSpawnTime; // ����� ���������� ������ �����������
    public Transform ingredientPrefab; // ������ �� ������ �����������
    private Camera cam; // ������ �� ������
    private Transform spawnedIngredient; // ������ �� ���������� ����������
    private bool gameEnded = false; // ���� ��� ������������ ���������� ����
    private int score = 0; // ���������� �����

    void Start()
    {
        cam = Camera.main; // ������ �� �������� ������
        nextSpawnTime = Time.time + startSpawnInterval; // �������������� ����� ���������� ������ � ������ ���������� ���������
    }

    void Update()
    {
        if (!gameEnded && Time.time >= nextSpawnTime)
        {
            // ������� ���������� ����������, ���� �� ����
            if (spawnedIngredient != null)
            {
                Destroy(spawnedIngredient.gameObject);
            }

            // ������� ���������� ������ ���� ���� �� ���������
            if (!gameEnded)
            {
                // ������� ����������� � ����������, ���������������� ���������� �����
                int numberOfIngredientsToSpawn = Mathf.Max(1, Mathf.RoundToInt(score * 0.1f)); // ����������� ���������� ���������� ������������ �� 1 �� ������ 10 ��������� ������
                for (int i = 0; i < numberOfIngredientsToSpawn; i++)
                {
                    // ������� ���������� ���� ������� ������� ������
                    Vector3 spawnPosition = cam.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1.1f, cam.nearClipPlane));

                    // ������� ���������� �� �������
                    spawnedIngredient = Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);

                    // ������������� ���������� Z �� 0, ����� ���������� �� �������� ������� ������ ��������
                    spawnedIngredient.position = new Vector3(spawnedIngredient.position.x, spawnedIngredient.position.y, 0);

                    // ������������� �������� ������� �����������
                    Rigidbody2D rb = spawnedIngredient.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.velocity = Vector2.down * fallSpeed;
                    }
                }
            }

            // ������������� ��������� ����� ������ � ������ ���������
            float modifiedSpawnInterval = startSpawnInterval / (1 + score * 0.1f); // ����������� �������� ������ �� 10% �� ������ ��������� ����
            nextSpawnTime = Time.time + modifiedSpawnInterval;
        }
    }

    // ����� ��� ������ ��� ���������� ����
    public void EndGame()
    {
        // ������������� ���� ���������� ����
        gameEnded = true;
    }

    // ����� ��� ���������� �����
    public void IncreaseScore()
    {
        score++;
    }
}
