using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public float vidaMaxima;
    public float vidaAtual;
    public float escudoItem;
    public float escudoPoderMaximo;
    public float escudoPoder;
    public float taxaDeRegeneracaoEscudo = 0f;
    public float taxaDeRegeneracao = 0f;
    public float intervaloDeRegeneracao = 1f;

    public bool regenera;
    public bool escudoAtivoItem;
    public bool escudoAtivoPoder;

    public MyGUI gui;
    public EscolherPoder escolherPoder;

    void Start()
    {
        vidaMaxima = 50;
        vidaAtual = vidaMaxima;
        //escudoPoderMaximo = 10;
        //escudoPoder = escudoPoderMaximo;
        regenera = false;
        escudoAtivoItem = false;
        //escudoAtivoPoder = false;

        InvokeRepeating("RegenerarVida", intervaloDeRegeneracao, intervaloDeRegeneracao);
        InvokeRepeating("RegenerarEscudoPoder", intervaloDeRegeneracao, intervaloDeRegeneracao);
    }

    public void RegenerarVida()
    {
        if(regenera)
        {
            if (vidaAtual < vidaMaxima)
            {
                vidaAtual += taxaDeRegeneracao;

                // Atualizar o slider de vida
                gui.AlterarVida(vidaAtual);
            }
            else if (vidaAtual > vidaMaxima)
            {
                vidaAtual = vidaMaxima;
            }
        }

    }

    public void Morrer()
    {
        if (vidaAtual <= 0)
        {
           gameObject.SetActive(false);
        }
    }

    public void RegenerarEscudoPoder()
    {
        if(escudoAtivoPoder)
        {
            if (escudoPoder < escudoPoderMaximo)
            {
                escudoPoder += taxaDeRegeneracaoEscudo;

                // Atualizar o slider de vida
                gui.AlterarEscudoPoder(escudoPoder);
            }
            else if (escudoPoder > escudoPoderMaximo)
            {
                escudoPoder = escudoPoderMaximo;
            }
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();

            if (inimigo != null)
            {
                if (escudoAtivoItem)
                {
                    escudoItem -= inimigo.dano;
                    gui.AlterarEscudoItem(escudoItem);
                }

                if (escudoItem <= 0)
                {
                    escudoAtivoItem = false;
                }

                if (escudoAtivoPoder)
                {
                    escudoPoder -= inimigo.dano;
                    gui.AlterarEscudoPoder(escudoPoder);
                }

                if (escudoPoder <= 0 && escudoItem <= 0)
                {
                    vidaAtual -= inimigo.dano;
                    gui.AlterarVida(vidaAtual);
                    Morrer();
                }
            }
        }
    }
}
