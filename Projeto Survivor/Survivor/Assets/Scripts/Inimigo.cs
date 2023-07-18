using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo : MonoBehaviour
{
    public GameObject XpPrefab;

    public float vida;
    public float dano;
   
    void Morrer()
    {
        GameObject novoXp = Instantiate(XpPrefab, transform.position, Quaternion.identity);
        novoXp.SetActive(true);
        Destroy(gameObject);
        MyGUI.contadorMortes++;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shuriken"))
        {
            //vidaAtual -= player.danoShuriken;
            vida -= 1;
            if (vida <= 0){
                Morrer();
        }
           
        }
    }
}
