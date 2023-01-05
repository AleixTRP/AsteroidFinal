using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text puntuacion;
    public TMP_Text vida;




    // Update is called once per frame
    void Update()
    {
        puntuacion.text = GameManager.instance.punt.ToString();
        
    }
}
