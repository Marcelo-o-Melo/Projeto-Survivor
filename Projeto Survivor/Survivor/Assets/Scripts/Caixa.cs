using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour
{

    private Transform player;
    public EscolherItem item;
    
    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 8); // xp
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6); // inimigo
        Physics2D.IgnoreLayerCollision(gameObject.layer, 7); //arma
        
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            item.itemAleatorio();
            Destroy(gameObject);

        }
    }
}
