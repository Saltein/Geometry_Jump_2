using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // работа с текстом

public class Spawner1 : MonoBehaviour
{
  public float minX, maxX; // min-max координаты создания платформ по X
  public float YrangeMin, YrangeMax; // min-max расстояния м-у платформами по Y
  public float cameraDistance; // начало создания платформ перед камерой
  public Transform planet1, planet2, planet3; // ссылки на прф.platform, прф.platformMove
  public float percentSpawn;
  public float percentSpawn2;// вероятность создания прф.platform
  private Transform cam; // ссылка на камеру
  private float lastSpawnY; // последнее место создания платформы по Y
    private float lastlastSpawn;
  private float rangeIncreaser; // увеличение расстояния м-у платформами по Y
  public TextMeshProUGUI ScoreTxt; // ссылка на кмп.TextMeshPro-Text(UI) об.Canvas.Text(TMP)
  private int score; // очки персонажа

  void Start()
  {
    cam = Camera.main.transform; // ссылка на об.MainCamera
    lastSpawnY = 0;
  }

  void Update()
  {
    ScoreTxt.text = "Очки: " + ScoreScriptMain._score;

    if (lastSpawnY < 250) // условие для увеличения расстояния м-у платформами по Y
    {
      rangeIncreaser = Mathf.Floor (lastSpawnY / 50); // округляем до меньшего целого
    }

    if (cam.position.y + cameraDistance > lastSpawnY)
    {
    Transform planets;

      if (Random.value < percentSpawn) // Random.value - случайное число 0..1
        planets = Instantiate (planet1); // создаём платформу из префаба "platformPrefab"
      else if (Random.value < percentSpawn2) // Random.value - случайное число 0..1
        planets = Instantiate(planet2);
      else
        planets = Instantiate (planet3); // создаём платформу из префаба "platformMovePrefab"

    planets.position = new Vector3 ( // устанавливаем координаты платформы
    Random.Range(minX, maxX), // координата X
    lastSpawnY + Random.Range(YrangeMin+(rangeIncreaser*0.9f), YrangeMax+(rangeIncreaser*1.1f)), // координата Y
    0); // координата Z
        //    Transform platform = Instantiate (platformPrefab, new Vector3 (Random.Range(minX, maxX), lastSpawnY + Random.Range(YrangeMin, YrangeMax), 0), Quaternion.identity);

      lastlastSpawn = lastSpawnY;
      lastSpawnY = planets.position.y;

      if (lastSpawnY-12 > 0) // чтобы очков было меньше, примерно 0 за нулевое положение дудлера
          score = Mathf.CeilToInt((lastSpawnY-12)*100); // Mathf.CeilToInt() - округление float в int
          ScoreScriptMain._score += Mathf.CeilToInt(lastSpawnY - lastlastSpawn) * 150f;
        }
  }

}