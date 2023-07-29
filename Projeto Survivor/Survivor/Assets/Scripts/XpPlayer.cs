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

    void Start()
    {
        xpMaximo = 10;
    }

    public void SubirNivel()
    {
        if (xp >= xpMaximo)
        {
            bool habilidadesDisponiveis = VerificarHabilidadesDisponiveis();

            if (habilidadesDisponiveis)
            {
                xp -= xpMaximo;
                nivel++;
                xpMaximo = 10;
                gui.AlterarXp(xp);
                escolherPoder.AtribuirMetodosAleatorios();
                escolherPoder.novoPoder();
            }
            else
            {
                Debug.Log("Não há mais habilidades disponíveis. Não é possível subir de nível.");
            }
        }
    }

    private bool VerificarHabilidadesDisponiveis()
    {
        // Verifica se há alguma habilidade disponível para o jogador escolher
        return escolherPoder.contAumentarVida < 5 ||
               escolherPoder.contAumentarVDA < 5 ||
               escolherPoder.contAumentarVDM < 5 ||
               escolherPoder.contAumentarIma < 5 ||
               escolherPoder.contVidaRegen < 5 ||
               escolherPoder.contAumentarDanoArmas < 5 ||
               escolherPoder.contFaca < 5;
    }
}
