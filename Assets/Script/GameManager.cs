using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header ("Elementos del Puntaje")]
    public int puntaje;
    public Text textoPuntaje;
    public int mejorPuntaje;
    public Text textoMejorPuntaje;
    

    [Header("Elementos del GameOver")]
    public GameObject panelGameOver;
    public Text textoPuntajeFinal;
    public Text textoMejorPuntajePanel;

    private void Awake()
    {
        panelGameOver.SetActive(false);
        PonerMejorPuntaje();

    }

    private void PonerMejorPuntaje()
    {
        mejorPuntaje = PlayerPrefs.GetInt("mejorPuntaje");
        textoMejorPuntaje.text = "Mejor: " + mejorPuntaje;
    }
    public void AumentarPuntaje()
    {
        puntaje += 2;
        textoPuntaje.text= puntaje.ToString();

        if(puntaje> mejorPuntaje)
        {
            PlayerPrefs.SetInt("mejorPuntaje", puntaje);
            textoMejorPuntaje.text = "Mejor: " + puntaje.ToString();
            mejorPuntaje = puntaje;
        }

    }


    public void AlTocarBomba()
    {
        
        panelGameOver.SetActive(true);
        textoPuntajeFinal.text = "Puntaje: " + puntaje.ToString();
        textoMejorPuntajePanel.text = "Mejor Puntaje: " + mejorPuntaje.ToString();
        Time.timeScale = 0;
    }

    public void Reiniciar()
    {
        puntaje = 0;
        textoPuntaje.text = puntaje.ToString();
        Time.timeScale = 1;
        panelGameOver.SetActive(false);
        

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactivo"))
        {
            Destroy (g);
        }
    }


}
