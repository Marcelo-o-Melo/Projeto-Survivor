using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolherPoder : MonoBehaviour
{
    [SerializeField] private GameObject painelPoder;
    public Player player;
    public MyGUI gui;

    public void aumentarVida()
    {
        player.vidaMaxima += 10;
        gui.AlterarVida(player.vidaAtual);
        Time.timeScale = 1f;
        painelPoder.SetActive(false); 
    }

    public void aumentarVDA()
    {
        player.intervaloDisparo -= 0.1f;
        player.ReiniciarRotinaDeDisparo(); // Reinicia a rotina de disparo
        Time.timeScale = 1f;
        painelPoder.SetActive(false); 
    }

    public void aumentarVDM()
    {
        player.velocidade += 10;
        Time.timeScale = 1f;
        painelPoder.SetActive(false); 
    }
}
