using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI textoTimerPro;

    private void Update()
    {
        time += Time.deltaTime;
        textoTimerPro.text = time.ToString("F2");
    }
}