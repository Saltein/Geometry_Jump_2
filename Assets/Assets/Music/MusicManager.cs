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
        DontDestroyOnLoad(gameObject); // �� ���������� ������ ��� �������� ����� �����
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayMusicForScene(SceneManager.GetActiveScene().buildIndex); // ������������� ������ ��� ��������� �����
    }

    private void Update()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex != currentSceneIndex) // ���� ����� ����������
        {
            PlayMusicForScene(sceneIndex); // ������������� ������ ��� ����� �����
            currentSceneIndex = sceneIndex;
        }
    }

    private void PlayMusicForScene(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < levelMusic.Length) // ��������� ������� ������ ��� ������ �����
        {
            audioSource.clip = levelMusic[sceneIndex];
            audioSource.volume = 0.1f;
            audioSource.Play();
        }
    }
}
