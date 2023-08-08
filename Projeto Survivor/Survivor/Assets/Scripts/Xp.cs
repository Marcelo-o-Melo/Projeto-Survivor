using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : MonoBehaviour
{
    public static float velocidade = 10f;
    public static float distanciaMinima = 3f;
    public float valor;
    [SerializeField]private Transform player;
    private Vector2 direcao;
    
    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 9); // caixa
        Physics2D.IgnoreLayerCollision(gameObject.layer, 8); // xp
        Physics2D.IgnoreLayerCollision(gameObject.layer, 7); // arma
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6); // inimigo    
    }

    void Update()
    {
        if (player != null)
        {
            direcao = player.position - transform.position;
            float distancia = direcao.magnitude;
            direcao.Normalize();

            if (distancia <= distanciaMinima)
            {
                transform.Translate(direcao * velocidade * Time.deltaTime);
            }
        }
    }

    void OnTr(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
        
    }
}
