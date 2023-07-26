using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeracaoDeCaixas : MonoBehaviour
{
    public GameObject PrefabCaixa;

    public string playerTag = "Player"; // Tag do jogador

    private Transform player;
    public float intervaloGeracao = 5f;
    public float distanciaMaxima = 12f;
    public float distanciaMinima = 10f;

    void Start()
        {
            // Inicia a corrotina de geracao de monstros
            StartCoroutine(GerarCaixaPeriodicamente());

            // Encontra o jogador com a tag especificada
            GameObject playerObject = GameObject.FindWithTag(playerTag);
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogWarning("Objeto do jogador não encontrado com a tag: " + playerTag);
            }

        }
        

        IEnumerator GerarCaixaPeriodicamente()
        {
            while (true)
            {
                if (player != null)
                {
                   
                        // Calcula uma posicao aleatoria dentro da distancia maxima para o inimigo comum
                        Vector2 posicaoAleatoria = (Vector2)player.position + Random.insideUnitCircle * distanciaMaxima;

                        // Verifica a distancia minima entre a posicao aleatoria e o personagem
                        float distancia = Vector2.Distance(posicaoAleatoria, player.position);
                        
                        if (distancia >= distanciaMinima)
                        {
                            // Cria uma copia do prefab do monstro comum
                            GameObject novaCaixa = Instantiate(PrefabCaixa, posicaoAleatoria, Quaternion.identity);
                            novaCaixa.SetActive(true);

                        }
                    
                }
                
                // Aguarda o intervalo de geracao
                yield return new WaitForSeconds(intervaloGeracao);
            }
        }

}



