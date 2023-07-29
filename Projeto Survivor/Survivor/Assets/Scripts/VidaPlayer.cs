using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public float vidaMaxima;
    public float vidaAtual;
    public float escudo;
    public float taxaDeRegeneracao = 0f;
    public float intervaloDeRegeneracao = 1f;
    public bool regenera;
    public bool escudoAtivo;

    public MyGUI gui;

    void Start()
    {
        vidaMaxima = 50;
        vidaAtual = vidaMaxima;
        regenera = false;
        escudoAtivo = false;

        InvokeRepeating("RegenerarVida", intervaloDeRegeneracao, intervaloDeRegeneracao);
    }

    public void RegenerarVida()
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

    public void Morrer()
    {
        if (vidaAtual <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();

            if (inimigo != null)
            {
                if (escudoAtivo)
                {
                    escudo -= inimigo.dano;
                    gui.AlterarEscudo(escudo);
                }

                if (escudo <= 0)
                {
                    escudoAtivo = false;
                    vidaAtual -= inimigo.dano;
                    gui.AlterarVida(vidaAtual);
                    Morrer();
                }
            }
        }
    }
}
