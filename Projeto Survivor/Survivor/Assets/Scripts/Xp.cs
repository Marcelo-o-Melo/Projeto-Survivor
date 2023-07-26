using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : MonoBehaviour

{
    public static float velocidade = 10f;
    public static float distanciaMinima = 3f;

    private Transform player;

    void Start()
    {
        // Encontra o jogador com a tag especificada
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Objeto do jogador não encontrado com a tag: " + "Player");
        }

        Physics2D.IgnoreLayerCollision(gameObject.layer, 8); // xp
        Physics2D.IgnoreLayerCollision(gameObject.layer, 7); // arma
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6); // inimigo
        
    }

    void Update()
    {
        if (player != null)
        {
            // Calcula a direcao para o player
            Vector3 direcao = player.position - transform.position;
            float distancia = direcao.magnitude;

            // Define a distancia minima para se aproximar (ajuste esse valor conforme necessario)
            if (distancia <= distanciaMinima)
            {
                direcao.Normalize();

                // Move o NPC na direcao do player
                transform.position += direcao * velocidade * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // Destruir o xp
        }
    }
}
