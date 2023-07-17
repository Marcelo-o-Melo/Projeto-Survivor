using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo : MonoBehaviour
{
    public GameObject XpPrefab;

    public int vidaMaxima = 5;
    private int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }
       void Morrer()
    {
            GameObject novoXp = Instantiate(XpPrefab, transform.position, Quaternion.identity);
            novoXp.SetActive(true);
            Destroy(gameObject);
            GerenciadorDeJogo.contadorMortes++;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shuriken"))
        {
            vidaAtual -=1;
            if (vidaAtual <= 0){
                Morrer();
        }
           
        }
    }
}
