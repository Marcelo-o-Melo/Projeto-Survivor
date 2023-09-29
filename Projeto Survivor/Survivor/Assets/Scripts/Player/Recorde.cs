using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recorde : MonoBehaviour
{
    public Text textoMortes;
    public Text textoTempo;

    public int contMortes;
    public float contTempo;

    void Start()
    {
        // Carrega os valores do recorde armazenados em PlayerPrefs
        contMortes = PlayerPrefs.GetInt("RecordeMortes", 0);
        contTempo = PlayerPrefs.GetFloat("RecordeTempo", 0f);

        AtualizarRecorde();
    }

    // Método para atualizar o recorde e exibir os valores atualizados nos Text components.
    void AtualizarRecorde()
    {
        // Verifica se o contadorMortes atual é maior que o recorde anterior
        if (MyGUI.contadorMortes > contMortes)
        {
            contMortes = MyGUI.contadorMortes;
            // Salva o novo recorde em PlayerPrefs
            PlayerPrefs.SetInt("RecordeMortes", contMortes);
        }

        // Verifica se o tempoDecorrido atual é maior que o recorde anterior
        if (MyGUI.tempoDecorrido > contTempo)
        {
            contTempo = MyGUI.tempoDecorrido;
            // Salva o novo recorde em PlayerPrefs
            PlayerPrefs.SetFloat("RecordeTempo", contTempo);
        }

        // Exibe os valores atualizados nos Text components
        textoMortes.text = "Inimigos Mortos: " + contMortes;

        int minutos = Mathf.FloorToInt(contTempo / 60f);
        int segundos = Mathf.FloorToInt(contTempo % 60f);
        string textoFormatado = string.Format("{0:00}:{1:00}", minutos, segundos);
        textoTempo.text = "Tempo Vivo: " + textoFormatado;
    }
}
