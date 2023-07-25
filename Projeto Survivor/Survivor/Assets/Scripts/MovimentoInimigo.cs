using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    public string playerTag = "Player"; // Tag do jogador
    public float velocidade = 5f;

    private Transform player;

    void Start(){
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

    void Update()
    {
        if (player != null)
        {
            // Calcula a direcao para o player
            Vector3 direcao = player.position - transform.position;
            direcao.Normalize();

            // Move o NPC na direcao do player
            transform.position += direcao * velocidade * Time.deltaTime;
        }
    }
}
