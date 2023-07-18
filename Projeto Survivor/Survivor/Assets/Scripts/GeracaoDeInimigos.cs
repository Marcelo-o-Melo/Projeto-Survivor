using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeracaoDeInimigos : MonoBehaviour
{
    public GameObject inimigoPrefabComum;
    public GameObject inimigoPrefabRaro;
    public float intervaloGeracao = 5f;
    public float distanciaMaxima = 12f;
    public float distanciaMinima = 10f;

    public Transform player;

    private bool spawnInimigoRaro = false;

    void Start()
    {
        // Inicia a corrotina de geracao de monstros
        StartCoroutine(GerarMonstrosPeriodicamente());
        StartCoroutine(AtivarSpawnInimigoRaro());
    }

    IEnumerator GerarMonstrosPeriodicamente()
    {
        while (true)
        {
            if (player != null)
            {
                // Calcula uma posicao aleatoria dentro da distancia maxima para o inimigo comum
                Vector2 posicaoAleatoriaComum = (Vector2)player.position + Random.insideUnitCircle * distanciaMaxima;

                // Verifica a distancia minima entre a posicao aleatoria e o personagem
                float distanciaComum = Vector2.Distance(posicaoAleatoriaComum, player.position);
                if (distanciaComum >= distanciaMinima)
                {
                    // Cria uma copia do prefab do monstro comum
                    GameObject novoMonstro = Instantiate(inimigoPrefabComum, posicaoAleatoriaComum, Quaternion.identity);
                    novoMonstro.SetActive(true);

                    // Verifica se o inimigo raro deve ser gerado
                    if (spawnInimigoRaro)
                    {
                        // Calcula uma nova posicao aleatoria para o inimigo raro
                        Vector2 posicaoAleatoriaRaro = (Vector2)player.position + Random.insideUnitCircle * distanciaMaxima;

                        // Verifica a distancia minima entre a posicao aleatoria e o personagem
                        float distanciaRaro = Vector2.Distance(posicaoAleatoriaRaro, player.position);
                        if (distanciaRaro >= distanciaMinima)
                        {
                            // Cria uma copia do prefab do monstro raro
                            GameObject novoMonstroRaro = Instantiate(inimigoPrefabRaro, posicaoAleatoriaRaro, Quaternion.identity);
                            novoMonstroRaro.SetActive(true);
                        }
                    }
                }
            }
            
            // Aguarda o intervalo de geracao
            yield return new WaitForSeconds(intervaloGeracao);
        }
    }

    IEnumerator AtivarSpawnInimigoRaro()
    {
        yield return new WaitForSeconds(30f);
        spawnInimigoRaro = true;
    }
}
