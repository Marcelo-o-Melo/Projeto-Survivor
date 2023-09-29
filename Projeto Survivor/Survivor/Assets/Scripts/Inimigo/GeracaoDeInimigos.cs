using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GeracaoDeInimigos : MonoBehaviour
{
    public Pool poolInimigoLVL1;
    public Pool poolInimigoLVL2;

    GameObject inimigo1;
    GameObject inimigo2;

    public float intervaloGeracao = 5f;
    public float distanciaMaxima = 12f;
    public float distanciaMinima = 10f;

    public int nivelInimigos;

    [SerializeField] private Transform player;

    private bool spawnInimigoLevel1 = true;
    private bool spawnInimigoLevel2 = false;

    public bool gerarInimigos;


    void Start()
    {

        nivelInimigos = 1;
        if (gerarInimigos)
        {
            // Inicia a corrotina de geracao de monstros
            StartCoroutine(GerarMonstrosPeriodicamente());
        }

        StartCoroutine(AtivarSpawnInimigoRaro());

        InvokeRepeating("DiminuirIntervalo", 60f, 60f);
    }

    IEnumerator GerarMonstrosPeriodicamente()
    {
        while (true)
        {
            if (player != null)
            {
                /// pega os inimigos da pool ///
                inimigo1 = poolInimigoLVL1.GetObjetos();
                inimigo2 = poolInimigoLVL2.GetObjetos();

                // Verifica se o inimigo 1 deve ser gerado
                if (spawnInimigoLevel1 && inimigo1 != null)
                {
                    // Calcula uma nova posicao aleatoria para o inimigo
                    Vector2 posicaoLevel1 = (Vector2)player.position + Random.insideUnitCircle * distanciaMaxima;
                    float distancia = Vector2.Distance(posicaoLevel1, player.position);

                    // Verifica a distancia minima entre a posicao aleatoria e o personagem
                    if (distancia >= distanciaMinima)
                    {
                        inimigo1.SetActive(true);
                        inimigo1.transform.position = posicaoLevel1;
                    }
                }

                // Verifica se o inimigo 2 deve ser gerado
                if (spawnInimigoLevel2 && inimigo2 != null)
                {
                    // Calcula uma nova posicao aleatoria para o inimigo
                    Vector2 posicaoLevel2 = (Vector2)player.position + Random.insideUnitCircle * distanciaMaxima;
                    float distancia = Vector2.Distance(posicaoLevel2, player.position);

                    // Verifica a distancia minima entre a posicao aleatoria e o personagem
                    if (distancia >= distanciaMinima)
                    {
                        inimigo2.SetActive(true);
                        inimigo2.transform.position = posicaoLevel2;
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
        spawnInimigoLevel2 = true;
    }
    // Método para aumentar o nível (chamado quando necessário)

    void DiminuirIntervalo()
    {
        if (intervaloGeracao > 0)
        {
            intervaloGeracao *= 0.90f;

        }
    }
}
