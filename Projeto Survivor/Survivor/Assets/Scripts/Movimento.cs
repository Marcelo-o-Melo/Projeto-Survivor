using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{

    public float velocidade;

    // Update is called once per frame
    void Update()
    {
        float movHori = Input.GetAxis("Horizontal");
        float movVert = Input.GetAxis("Vertical");

        Vector2 deslocamento = new Vector2(movHori, movVert) * velocidade * Time.deltaTime;
        
        transform.Translate(deslocamento);
    }
}
