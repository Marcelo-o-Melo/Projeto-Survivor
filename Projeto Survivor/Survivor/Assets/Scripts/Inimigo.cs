using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo : MonoBehaviour
{
    public Pool poolXp;
    public GeracaoDeInimigos geracao;
    GameObject xp;

    public float vidaMaxima;
    public float vidaAtual;
    public float dano;


   private void OnEnable() 
   {
        AtualizarVidaAtual();
   }


    void Start()
    {
        InvokeRepeating("AumentarStatus", 60f, 60f);
    }

    public void Morrer()
    {
        xp = poolXp.GetObjetos();
        if(xp != null){
            xp.SetActive(true);
            xp.transform.position = gameObject.transform.position;
        }
        
        MyGUI.contadorMortes++;
        gameObject.SetActive(false);
    }

    public void VerificarVida()
    {
        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projetil"))
        {
            Projetil projetil = collision.gameObject.GetComponent<Projetil>();
            vidaAtual -= projetil.danoFinal;

            VerificarVida();
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Projetil"))
        {
            Projetil projetil = other.gameObject.GetComponent<Projetil>();
            vidaAtual -= projetil.danoFinal;

            VerificarVida();
        }
    }

    void AumentarStatus()
    {
        vidaMaxima *= 1.2f;
        dano *= 1.4f;
        AtualizarVidaAtual();
    }

    // Método para atualizar a vida atual com base na vida máxima atual
    void AtualizarVidaAtual()
    {
        vidaAtual = vidaMaxima;
    }


}
