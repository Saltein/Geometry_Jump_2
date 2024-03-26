using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] levelMusic;
    private AudioSource audioSource;
    private int currentSceneIndex = -1;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Не уничтожать объект при загрузке новой сцены
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayMusicForScene(SceneManager.GetActiveScene().buildIndex); // Воспроизводим музыку для начальной сцены
    }

    private void Update()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex != currentSceneIndex) // Если сцена изменилась
        {
            PlayMusicForScene(sceneIndex); // Воспроизводим музыку для новой сцены
            currentSceneIndex = sceneIndex;
        }
    }

    private void PlayMusicForScene(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < levelMusic.Length) // Проверяем наличие музыки для данной сцены
        {
            audioSource.clip = levelMusic[sceneIndex];
            audioSource.volume = 0.1f;
            audioSource.Play();
        }
    }
}
