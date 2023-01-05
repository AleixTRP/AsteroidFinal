using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int lives = 3;
    public TextMeshProUGUI textoTimerPro;

    private void Start()
    {
        // Inicializamos el contador de vidas en la interfaz de usuario
        UpdateLivesUI();
    }

    private void Update()
    {
        // Actualizamos el contador de vidas en la interfaz de usuario cada frame
        UpdateLivesUI();
    }

    private void UpdateLivesUI()
    {
        textoTimerPro.text = GameManager.instance.life.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            // Restamos una vida al jugador y actualizamos el contador de vidas en la interfaz de usuario
            GameManager.instance.life--;
            UpdateLivesUI();
        }
    }
}
