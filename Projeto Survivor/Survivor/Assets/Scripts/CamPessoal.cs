using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPessoal : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Define a posicao da camera como a posicao do player mais um deslocamento
            transform.position = player.position + offset;
        }
    }
}
