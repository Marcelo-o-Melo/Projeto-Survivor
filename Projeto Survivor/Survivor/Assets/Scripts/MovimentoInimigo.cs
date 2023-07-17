using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    public Transform personagem;
    public float velocidade = 5f;

    void Update()
    {
        if (personagem != null)
        {
            // Calcula a direcao para o personagem
            Vector3 direcao = personagem.position - transform.position;
            direcao.Normalize();

            // Move o NPC na direcao do personagem
            transform.position += direcao * velocidade * Time.deltaTime;
        }
    }
}
