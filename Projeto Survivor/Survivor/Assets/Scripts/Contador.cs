using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Text textoDoContador;
    private float tempoDecorrido = 0f;

    void Update()
    {
        tempoDecorrido += Time.deltaTime;
        AtualizarTextoDoContador();
    }

    void AtualizarTextoDoContador()
    {
        int minutos = Mathf.FloorToInt(tempoDecorrido / 60f);
        int segundos = Mathf.FloorToInt(tempoDecorrido % 60f);
        string textoFormatado = string.Format("{0:00}:{1:00}", minutos, segundos);
        textoDoContador.text = textoFormatado;
    }
}
