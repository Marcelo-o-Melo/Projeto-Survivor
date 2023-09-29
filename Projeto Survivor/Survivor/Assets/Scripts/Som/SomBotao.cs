using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SomBotao : MonoBehaviour
{
    public Button[] botoes;

    private void Start()
    {
        // Adicione um listener de clique a cada botão na lista
        foreach (Button botao in botoes)
        {
            botao.onClick.AddListener(OnBotaoClicado);
        }
    }

    // Método chamado quando um botão é clicado
    private void OnBotaoClicado()
    {
        AudioController.Instance.botaoSFX.Play();
    }
}
