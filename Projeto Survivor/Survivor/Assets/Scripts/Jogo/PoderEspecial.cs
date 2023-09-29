using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoderEspecial : MonoBehaviour
{
    public ControladorJogo controladorJogo;
    public GameObject MenuEscolherPoder;
    public GameObject UiPoder;
    public GameObject UiUsos;
    public GameObject UiPoderEscolhido;
    public Player player;
    public MovimentoPlayer movimentoPlayer;
    public int quantiaGranadas;
    public int quantiaDashs;
    public int usos;
    private int poderEscolhido;
    public float raioGranada;

    public Rigidbody2D rb;

    public Sprite[] icones;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UsarPoder();
        }
    }
    public void UsarPoder()
    {
        if (!controladorJogo.metodoAtivo)
        {
            if (usos > 0)
            {
                if (poderEscolhido == 1)
                {
                    PoderGranada();
                    usos--;
                }
                if (poderEscolhido == 2)
                {
                    if (movimentoPlayer.canDash && !movimentoPlayer.isDashing)
                    {
                        movimentoPlayer.PoderDash();
                        usos--;
                    }
                }
            }
        }
    }

    public void EscolherGranada()
    {

        UiPoderEscolhido.GetComponentInChildren<Image>().sprite = icones[0]; //icone 
        poderEscolhido = 1;
        Time.timeScale = 1f;
        UiPoder.SetActive(true);
        MenuEscolherPoder.SetActive(false);

        usos = quantiaGranadas;
    }
    public void EscolherDash()
    {
        UiPoderEscolhido.GetComponentInChildren<Image>().sprite = icones[1]; //icone
        poderEscolhido = 2;
        Time.timeScale = 1f;
        UiPoder.SetActive(true);
        MenuEscolherPoder.SetActive(false);

        usos = quantiaDashs;
    }
    public void EscolherAumetarXp()
    {
        UiPoderEscolhido.GetComponentInChildren<Image>().sprite = icones[2]; //icone
        PoderAumetarXp();
        Time.timeScale = 1f;
        usos = 0;
        UiPoder.SetActive(true);
        MenuEscolherPoder.SetActive(false);
        UiUsos.SetActive(false);
    }

    public void PoderGranada()
    {
        AudioController.Instance.explosaoSFX.Play();
        // Obter todos os inimigos na cena com o script "Inimigo"
        Inimigo[] inimigos = FindObjectsOfType<Inimigo>();

        // Obter a posicao atual do jogador
        Vector3 posicaoDoJogador = player.transform.position;

        // Percorrer todos os inimigos e verificar se estao proximos ao jogador
        foreach (Inimigo inimigo in inimigos)
        {

            Vector3 posicaoDoInimigo = inimigo.transform.position;
            float distanciaParaJogador = Vector3.Distance(posicaoDoJogador, posicaoDoInimigo);

            // Verificar se o inimigo esta dentro do raio do nuke
            if (distanciaParaJogador <= raioGranada)
            {
                inimigo.mortoPorExplosao = true;
                inimigo.Morrer();
            }
        }
    }

    
    public void PoderAumetarXp()
    {
        player.multiplicadorXp = 1.5f;
    }


}


