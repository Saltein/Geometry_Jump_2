using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // работа с менеджером сцены

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1); // перезапуск сцены, SceneManager.LoadScene(0)
        Time.timeScale = 1f;
        ScoreScriptMain._score = 0;
    }
}