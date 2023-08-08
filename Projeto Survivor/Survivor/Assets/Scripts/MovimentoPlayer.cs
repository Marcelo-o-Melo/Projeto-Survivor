using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
 public float velocidade;

    void Update()
    {
        float movHori = Input.GetAxis("Horizontal");
        float movVert = Input.GetAxis("Vertical");

        Vector2 deslocamento = new Vector2(movHori, movVert) * velocidade * Time.deltaTime;

        transform.Translate(deslocamento);
    }
}
