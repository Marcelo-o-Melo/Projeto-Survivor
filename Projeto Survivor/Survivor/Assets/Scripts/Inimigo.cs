using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo : MonoBehaviour
{
    public GameObject XpPrefab;
    public Projetil projetil;

    public float vida;
    public float dano;
   
    void Morrer()
    {
        GameObject novoXp = Instantiate(XpPrefab, transform.position, Quaternion.identity);
        novoXp.SetActive(true);
        Destroy(gameObject);
        MyGUI.contadorMortes++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Projetil projetil = collision.gameObject.GetComponent<Projetil>();

        if (projetil != null)
        {
            vida -= projetil.dano;

            if (vida <= 0)
            {
                Morrer();
            }

            Destroy(projetil.gameObject);
        }
    }
}
