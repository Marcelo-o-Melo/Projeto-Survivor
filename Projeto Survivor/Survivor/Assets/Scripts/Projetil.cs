using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float danoBase;
    public float danoFinal;
    [SerializeField] private float tempoDesativacao;
    public bool desativadoPorTempo;
    public bool desativadoPorColisao;

    void Start()
    {
        danoFinal = danoBase * EscolherPoder.multiplicador;
        Physics2D.IgnoreLayerCollision(gameObject.layer, 3); //player
        Physics2D.IgnoreLayerCollision(gameObject.layer, 7); //arma
    }

    private void Update()
    {
        if(desativadoPorTempo){
            if(gameObject.activeInHierarchy)
            {
                StartCoroutine(DesativarObjetoTempo());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (desativadoPorColisao)
        {
            Inimigo inimigo = other.gameObject.GetComponent<Inimigo>();

            if (other.gameObject.CompareTag("Inimigo"))
            {////// projetil  <= vidaInimigo /////
                if (danoFinal <= inimigo.vidaAtual)
                {
                    gameObject.SetActive(false);
                    danoFinal = danoBase * EscolherPoder.multiplicador;
                }
                else
                {
                    danoFinal--;
                }
            }
        }
    }

    private IEnumerator DesativarObjetoTempo()
    {
        yield return new WaitForSeconds(tempoDesativacao);
        gameObject.SetActive(false);
        danoFinal = danoBase * EscolherPoder.multiplicador;
    }

}
