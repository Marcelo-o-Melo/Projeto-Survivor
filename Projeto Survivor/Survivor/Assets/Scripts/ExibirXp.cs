using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExibirXp : MonoBehaviour
{
    public GameObject jogador;
    public Text textoXP;

    void Update()
    {
        int xp = jogador.GetComponent<Player>().xp;
        textoXP.text = "XP: " + xp.ToString();
    }
}
