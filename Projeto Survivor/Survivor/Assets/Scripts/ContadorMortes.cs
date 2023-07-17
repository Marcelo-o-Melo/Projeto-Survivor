using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorMortes : MonoBehaviour
{
 public Text textoContador;

    void Start()
    {
        AtualizarContador();
    }

    void Update()
    {
        // Voce pode atualizar o contador apenas quando necessario,
        // por exemplo, quando ele for alterado.
        if (textoContador.text != GerenciadorDeJogo.contadorMortes.ToString())
        {
            AtualizarContador();
        }
    }

    void AtualizarContador()
    {
        textoContador.text = "Mortes: " + GerenciadorDeJogo.contadorMortes.ToString();
    }
}
