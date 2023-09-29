using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo : MonoBehaviour
{
    public Pool poolXp;
    public GameObject xp;

    public float vidaMaxima;
    public float vidaAtual;
    public float dano;

    private Animator animator;

    public bool vivo;
    public bool mortoPorExplosao;


    void Start()
    {
        animator = GetComponent<Animator>();

        Physics2D.IgnoreLayerCollision(gameObject.layer, 10); //terreno
        InvokeRepeating("AumentarStatus", 60f, 60f);
    }

    private void OnEnable()
    {
        mortoPorExplosao = false;
        vivo = true;
        AtualizarVidaAtual();

        if (animator != null)
        {
            animator.SetBool("Morto", false);
            animator.SetBool("MortoExplosao", false);
        }

    }
    public void DesativarInimigo()
    {
        gameObject.SetActive(false);
    }
    public void Morrer()
    {
        vivo = false;

        xp = poolXp.GetObjetos();
        if (xp != null)
        {
            xp.SetActive(true);
            xp.transform.position = gameObject.transform.position;
        }

        MyGUI.contadorMortes++;

        if (mortoPorExplosao)
        {
            animator.SetBool("MortoExplosao", true);
        }
        else if (!mortoPorExplosao)
        {
            AudioController.Instance.morteInimigoSFX.Play();
            animator.SetBool("Morto", true);
        }

        StartCoroutine(EsperarTerminoAnimacao());

    }

    public void VerificarVida()
    {
        if (vidaAtual <= 0 && vivo)
        {
            Morrer();
        }
    }

    IEnumerator EsperarTerminoAnimacao()
    {
        yield return new WaitForSeconds(0.5f);

        DesativarInimigo();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projetil"))
        {
            Projetil projetil = other.gameObject.GetComponent<Projetil>();
            vidaAtual -= projetil.danoFinal;
            //AudioController.Instance.hitMobSFX.Play();
            VerificarVida();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projetil"))
        {
            Projetil projetil = other.gameObject.GetComponent<Projetil>();
            vidaAtual -= projetil.danoFinal;
            AudioController.Instance.hitMobSFX.Play();
            VerificarVida();
        }

    }
    void AumentarStatus()
    {
        vidaMaxima *= 1.5f;
        dano *= 1.5f;
        AtualizarVidaAtual();
    }

    // Método para atualizar a vida atual com base na vida máxima atual
    void AtualizarVidaAtual()
    {
        vidaAtual = vidaMaxima;
    }
}
