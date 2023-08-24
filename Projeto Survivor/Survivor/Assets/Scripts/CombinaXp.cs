using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinaXp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 9); // caixa
        //Physics2D.IgnoreLayerCollision(gameObject.layer, 8); // xp
        Physics2D.IgnoreLayerCollision(gameObject.layer, 7); // arma
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6); // inimigo  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Xp"))
        {
            gameObject.SetActive(false);
        }

    }
}
