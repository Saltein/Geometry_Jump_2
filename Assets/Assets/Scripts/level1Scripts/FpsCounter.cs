using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    public TextMeshProUGUI fpsTMP;

    void Update()
    {
        fpsTMP.text = "FPS: " + (1 / Time.deltaTime).ToString();
    }
}
