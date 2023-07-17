using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float tempoDestruicao = 2f; // Tempo em segundos antes do projetil ser destruido
    void Start()
    {
        // Destruir o projetil apos o tempo de destruicao especificado
        Destroy(gameObject, tempoDestruicao);
    }
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alvo"))
        {
           Destroy(gameObject); // Destruir o projetil
        }
    }
}
