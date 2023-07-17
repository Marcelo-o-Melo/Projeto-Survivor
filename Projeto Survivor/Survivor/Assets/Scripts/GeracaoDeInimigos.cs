using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeracaoDeInimigos : MonoBehaviour
{
    public GameObject monstroPrefab;
    public float intervaloGeracao = 5f;
    public float distanciaMaxima = 12f;
    public float distanciaMinima = 10f;

    public Transform personagem;

    void Start()
    {
        
        // Inicia a corrotina de geracao de monstros
        StartCoroutine(GerarMonstrosPeriodicamente());
    }

    IEnumerator GerarMonstrosPeriodicamente()
{
    while (true)
    {
        // Calcula uma posicao aleatoria dentro da distancia maxima
        Vector2 posicaoAleatoria = (Vector2)personagem.position + Random.insideUnitCircle * distanciaMaxima;

        
       
        // Verifica a distancia minima entre a posicao aleatoria e o personagem
        float distancia = Vector2.Distance(posicaoAleatoria, personagem.position);
        if (distancia >= distanciaMinima)
        {
        // Cria uma copia do prefab do monstro
        GameObject novoMonstro = Instantiate(monstroPrefab, posicaoAleatoria, Quaternion.identity);

        // Define o novo monstro como ativo
        novoMonstro.SetActive(true);
            
        }

        // Aguarda o intervalo de geracao
        yield return new WaitForSeconds(intervaloGeracao);
    }
}
}
