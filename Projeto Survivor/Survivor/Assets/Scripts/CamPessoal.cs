using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPessoal : MonoBehaviour
{
    public Transform personagem;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (personagem != null)
        {
            // Define a posicao da camera como a posicao do personagem mais um deslocamento
            transform.position = personagem.position + offset;
        }
    }
}
