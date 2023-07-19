using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : MonoBehaviour
{
    public Transform personagem;
    public float velocidade = 5f;
    public static float distanciaMinima = 3f;


    void Update()
    {
        if (personagem != null)
        {
            // Calcula a direcao para o personagem
            Vector3 direcao = personagem.position - transform.position;
            float distancia = direcao.magnitude;

            // Define a distancia minima para se aproximar (ajuste esse valor conforme necessario)
            if (distancia <= distanciaMinima)
            {
                direcao.Normalize();

                // Move o NPC na direcao do personagem
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
