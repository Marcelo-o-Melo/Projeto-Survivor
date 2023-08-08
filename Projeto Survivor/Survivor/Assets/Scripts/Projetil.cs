using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float danoBase;
    public float danoFinal;
    public float tempoDesativacao;
    public bool desativadoPorTempo;
    public bool desativadoPorColisao;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 3); //player
        Physics2D.IgnoreLayerCollision(gameObject.layer, 7); //arma
    }

    private void Update()
    {
        danoFinal = danoBase * EscolherPoder.multiplicador;
        if(desativadoPorTempo){
            if(gameObject.activeInHierarchy)
            {
                StartCoroutine(DesativarObjetoTempo());
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(desativadoPorColisao)
        {
            if (collision.gameObject.CompareTag("Inimigo"))
            {
                gameObject.SetActive(false);
            }
        }

    }

    public IEnumerator DesativarObjetoTempo()
    {
        yield return new WaitForSeconds(tempoDesativacao);

        gameObject.SetActive(false);
    }

}
