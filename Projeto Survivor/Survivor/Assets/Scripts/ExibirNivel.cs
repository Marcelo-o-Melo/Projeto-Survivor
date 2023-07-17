using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExibirNivel : MonoBehaviour
{
    public GameObject jogador;
    public Text textoLVL;

    void Update()
    {
        int lvl = jogador.GetComponent<Player>().nivel;
        textoLVL.text = "LVL " + lvl.ToString();
    }
}
