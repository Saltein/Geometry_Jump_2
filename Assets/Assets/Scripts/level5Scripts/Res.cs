using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ������ � ���������� �����

public class Res : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ���������� �����, SceneManager.LoadScene(0)
    }

    //  public void ClearScore()
    //  {
    //    PlayerPrefs.SetInt("score", 1);
    //    PlayerPrefs.Save();
    //  }

}
