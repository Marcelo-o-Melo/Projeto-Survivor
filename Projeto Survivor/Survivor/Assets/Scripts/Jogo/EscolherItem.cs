using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscolherItem : MonoBehaviour
{
    public Sprite[] itens;
    public GameObject itemHolder; 
    public Player player;
    public MyGUI gui;
    public GameObject gameObjectEscudo;
    public GameObject explosao;

    public VidaPlayer vidaPlayer;
    public XpPlayer xpPlayer;
    public MovimentoPlayer movimentoPlayer;

    public float valorEscudo;
    public float nukeRadius; // Raio de efeito do nuke

    private int[] metodosIndices = new int[]
    {
        0,// Indice do metodo frango
        1,// Indice do metodo escudo
        2,// Indice do metodo nuke
        3 // Indice do metodo imaPotente

    };

    void frango(){
        AudioController.Instance.frangoSFX.Play();
        vidaPlayer.vidaAtual = vidaPlayer.vidaMaxima;
        gui.AlterarVida(vidaPlayer.vidaAtual);
        StartCoroutine(AtivarItemHolderPorCincoSegundos());
    }
    void escudo(){
        AudioController.Instance.escudoSFX.Play();
        vidaPlayer.escudoItem = valorEscudo;
        gui.AlterarEscudoItem(vidaPlayer.escudoItem);
        vidaPlayer.escudoAtivoItem = true;
        gameObjectEscudo.SetActive(true);
        StartCoroutine(AtivarItemHolderPorCincoSegundos());
    }
    void nuke(){
        AudioController.Instance.explosaoSFX.Play();
        MatarInimigosProximos();
        StartCoroutine(AtivarItemHolderPorCincoSegundos());
    }
    void imaPotente(){
        AudioController.Instance.superImaSFX.Play();
        StartCoroutine(AtivarImaPotente());
        StartCoroutine(AtivarItemHolderPorCincoSegundos());
    }

    public void itemAleatorio()
    {
        List<int> metodosDisponiveis = new List<int>(metodosIndices);
                
        int randomIndex = Random.Range(0, metodosDisponiveis.Count);

            if (randomIndex != -1)
            {
                switch (randomIndex)
                {
                    case 0:
                        frango();
                        itemHolder.GetComponentInChildren<Image>().sprite = itens[0];
                        break;
                    case 1:
                        escudo();
                        itemHolder.GetComponentInChildren<Image>().sprite = itens[1];
                        break;
                    case 2:
                        nuke();
                        itemHolder.GetComponentInChildren<Image>().sprite = itens[2];
                        break;
                    case 3:
                        imaPotente();
                        itemHolder.GetComponentInChildren<Image>().sprite = itens[3];
                        break;
                    default:
                        Debug.LogError("indice de metodo invalido!");
                        break;
                }
            }
    }

    private IEnumerator AtivarItemHolderPorCincoSegundos()
    {
        itemHolder.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        itemHolder.SetActive(false);
    }

    private IEnumerator AtivarImaPotente()
    {
        Xp.distanciaMinima += 10000;
        Xp.velocidade +=100;
        yield return new WaitForSeconds(5f);
        Xp.distanciaMinima -= 10000;
        Xp.velocidade -=100;
    }

    public void MatarInimigosProximos()
    {
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
            if (distanciaParaJogador <= nukeRadius)
            {
                inimigo.mortoPorExplosao = true;
                inimigo.Morrer();
            }
        }
    }

}
