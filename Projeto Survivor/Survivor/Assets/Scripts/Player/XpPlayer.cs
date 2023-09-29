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
            
            bool habilidadesDisponiveis = escolherPoder.VerificarHabilidadesDisponiveis();

            if (habilidadesDisponiveis)
            {
                AudioController.Instance.levelUpSFX.Play();
                xp -= xpMaximo;
                nivel++;
                xpMaximo *= 1.5f;
                gui.AlterarXp(xp);
                escolherPoder.novoPoder();
            }
        }
    }
    public void SubirNivelManual(){
        xp = xpMaximo;
        SubirNivel();
    }

}
