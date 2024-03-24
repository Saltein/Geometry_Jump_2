using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLvl4 : MonoBehaviour
{
    public static float _score = 0;
    public TextMeshProUGUI scoreTXT;

    public float scoreMultipler = 150f;
    void Update()
    {
        _score += Time.deltaTime * scoreMultipler;
        scoreTXT.text = _score.ToString();  
    }
}
