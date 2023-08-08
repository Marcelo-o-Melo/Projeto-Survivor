using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeracaoDeCaixas : MonoBehaviour
{
    public Pool poolCaixa;
    GameObject caixa;

    [SerializeField]private Transform player;
    public float intervalo = 5f;
    public float distanciaMaxima = 12f;
    public float distanciaMinima = 10f;

    void Start()
        {
            // Inicia a corrotina de geracao de monstros
            StartCoroutine(GerarCaixaPeriodicamente());
        }
        
        IEnumerator GerarCaixaPeriodicamente()
        {
            while (true)
            {
                if (player != null)
                {
                    caixa = poolCaixa.GetObjetos();
                    // Calcula uma posicao aleatoria dentro da distancia maxima para o inimigo comum
                    Vector2 posicaoAleatoria = (Vector2)player.position + Random.insideUnitCircle * distanciaMaxima;
                    // Verifica a distancia minima entre a posicao aleatoria e o personagem
                    float distancia = Vector2.Distance(posicaoAleatoria, player.position);

                    if(caixa != null)
                    {
                        if (distancia >= distanciaMinima)
                        {                         
                        caixa.SetActive(true);
                        caixa.transform.position = posicaoAleatoria;
                        }
                    }
                }
                
                // Aguarda o intervalo de geracao
                yield return new WaitForSeconds(intervalo);
            }
            
        }

}



