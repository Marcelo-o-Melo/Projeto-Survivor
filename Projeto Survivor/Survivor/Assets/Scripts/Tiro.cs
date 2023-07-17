using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    public GameObject projetilPrefab;
    public Transform pontoLancamento;
    
    public float intervaloDisparo = 0.5f;
    public float forcaLancamento = 10f;

    void Start(){

        StartCoroutine(Atirar());
    }

       IEnumerator Atirar(){
            while (true)
            {
                // Procura o alvo
                GameObject alvo = GameObject.FindGameObjectWithTag("Alvo");

                if (alvo != null)
                {
                    // Calcula a direcao do alvo
                    Vector2 direcaoAlvo = alvo.transform.position - transform.position;
                    direcaoAlvo.Normalize();

                    // Gera um projetil
                    GameObject novoProjetil = Instantiate(projetilPrefab, pontoLancamento.position, pontoLancamento.rotation);
                    novoProjetil.SetActive(true);

                    // Aplica uma forca ao projetil
                    Rigidbody2D projetil = novoProjetil.GetComponent<Rigidbody2D>();
                    if (projetil != null)
                    {
                        projetil.AddForce(direcaoAlvo * forcaLancamento, ForceMode2D.Impulse);
                    }
                }

                // Aguarda o intervalo de disparo
                yield return new WaitForSeconds(intervaloDisparo);
            }
        }
   
}
