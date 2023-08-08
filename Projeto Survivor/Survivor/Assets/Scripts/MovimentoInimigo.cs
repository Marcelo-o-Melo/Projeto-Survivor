using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    public float velocidade = 5f;

    [SerializeField]private Transform player;
    private Vector2 direcao;

    void Update()
    {
        if (player != null)
        {
            // Calcula a direcao para o player
            direcao = player.position - transform.position;
            //direcao.y = 0f; // Mantém o inimigo na mesma altura do player, se necessário.
            direcao.Normalize();

            // Move o NPC na direcao do player
            transform.Translate(direcao * velocidade * Time.deltaTime);

            // Olha para o jogador (ajusta a rotação na direção do jogador)
            //transform.right = player.position - transform.position;


        }
    }
}
