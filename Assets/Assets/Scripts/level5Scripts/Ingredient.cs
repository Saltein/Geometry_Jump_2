using UnityEngine;

public class SlowIngredientSpawner : MonoBehaviour
{
    public float minX, maxX; // min-max ���������� �������� ����������� �� X
    public float spawnInterval = 1.5f; // �������� ����� �������� ������������
    public float fallSpeed = 1f; // �������� ������� ������������
    private float nextSpawnTime; // ����� ���������� ������ �����������
    public Transform ingredientPrefab; // ������ �� ������ �����������
    private Camera cam; // ������ �� ������
    private Transform spawnedIngredient; // ������ �� ���������� ����������
    private bool gameEnded = false; // ���� ��� ������������ ���������� ����

    void Start()
    {
        cam = Camera.main; // ������ �� �������� ������
        nextSpawnTime = Time.time + spawnInterval; // �������������� ����� ���������� ������ � ������ ���������� ���������
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

            // ������������� ��������� ����� ������ � ������ ���������
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    // ����� ��� ������ ��� ���������� ����
    public void EndGame()
    {
        // ������������� ���� ���������� ����
        gameEnded = true;
    }
}



