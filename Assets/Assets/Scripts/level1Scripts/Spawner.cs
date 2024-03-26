using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // ������ � �������

public class Spawner : MonoBehaviour
{
    public float minX, maxX; // min-max ���������� �������� �������� �� X
    public float YrangeMin, YrangeMax; // min-max ���������� �-� ����������� �� Y
    public float cameraDistance; // ������ �������� �������� ����� �������
    public Transform platformPrefab, platformMovePrefab; // ������ �� ���.platform, ���.platformMove
    public float percentSpawn; // ����������� �������� ���.platform
    private Transform cam; // ������ �� ������
    private float lastSpawnY; // ��������� ����� �������� ��������� �� Y
    private float lastlastSpawnY;
    private float rangeIncreaser; // ���������� ���������� �-� ����������� �� Y
    public TextMeshProUGUI ScoreTxt; // ������ �� ���.TextMeshPro-Text(UI) ��.Canvas.Text(TMP)
    private int score; // ���� ���������

    void Start()
    {
        cam = Camera.main.transform; // ������ �� ��.MainCamera
        lastSpawnY = 0;
    }

    void Update()
    {
        ScoreTxt.text = "����: " + ScoreScriptMain._score;

        if (lastSpawnY < 250) // ������� ��� ���������� ���������� �-� ����������� �� Y
        {
            rangeIncreaser = Mathf.Floor(lastSpawnY / 50); // ��������� �� �������� ������
        }

        if (cam.position.y + cameraDistance > lastSpawnY)
        {
            Transform platform;

            if (Random.value < percentSpawn) // Random.value - ��������� ����� 0..1
                platform = Instantiate(platformPrefab); // ������ ��������� �� ������� "platformPrefab"
            else
                platform = Instantiate(platformMovePrefab); // ������ ��������� �� ������� "platformMovePrefab"

            platform.position = new Vector3( // ������������� ���������� ���������
              Random.Range(minX, maxX), // ���������� X
              lastSpawnY + Random.Range(YrangeMin + (rangeIncreaser * 0.9f), YrangeMax + (rangeIncreaser * 1.1f)), // ���������� Y
              0); // ���������� Z
                  //    Transform platform = Instantiate (platformPrefab, new Vector3 (Random.Range(minX, maxX), lastSpawnY + Random.Range(YrangeMin, YrangeMax), 0), Quaternion.identity);
            lastlastSpawnY = lastSpawnY;
            lastSpawnY = platform.position.y;

            if (lastSpawnY - 12 > 0) // ����� ����� ���� ������, �������� 0 �� ������� ��������� �������
                score = Mathf.CeilToInt((lastSpawnY - 12) * 100); // Mathf.CeilToInt() - ���������� float � int
            ScoreScriptMain._score += Mathf.CeilToInt(lastSpawnY - lastlastSpawnY) * 50f;
        }
    }

}