using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpPlayer : MonoBehaviour
{
    public float xp;
    public float xpMaximo;
    public int nivel;

    public EscolherPoder escolherPoder;

    public MyGUI gui;

    public void SubirNivel()
    {
        if (xp >= xpMaximo)
        {
            bool habilidadesDisponiveis = VerificarHabilidadesDisponiveis();

            if (habilidadesDisponiveis)
            {
                xp -= xpMaximo;
                nivel++;
                xpMaximo *= 1.5f;
                gui.AlterarXp(xp);
                //escolherPoder.AtribuirMetodosAleatorios();
                escolherPoder.novoPoder();
            }
        }
    }

    private bool VerificarHabilidadesDisponiveis()
    {
        // Verifica se há alguma habilidade disponível para o jogador escolher
        return  escolherPoder.contAumentarVida < 5 ||
                escolherPoder.contAumentarVDA < 5 ||
                escolherPoder.contAumentarVDM < 5 ||
                escolherPoder.contAumentarIma < 5 ||
                escolherPoder.contVidaRegen < 5 ||
                escolherPoder.contAumentarDanoArmas < 5 ||
                escolherPoder.contFaca < 5 ||
                escolherPoder.contOrbes < 5 ||
                escolherPoder.contPenetracao <5 ||
                escolherPoder.contEscudo <5 ||
                escolherPoder.contDanoArea <5 ||
                escolherPoder.contVelocidadeProjetil <5;
    }
}
