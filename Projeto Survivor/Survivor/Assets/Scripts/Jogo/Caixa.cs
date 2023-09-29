using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour
{

    private Transform player;
    public EscolherItem item;

    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6); // inimigo
        Physics2D.IgnoreLayerCollision(gameObject.layer, 7); //arma
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            item.itemAleatorio();
            AudioController.Instance.bauSFX.Play();
            animator.SetBool("Pego", true);

            StartCoroutine(EsperarTerminoAnimacao());

        }
    }

    IEnumerator EsperarTerminoAnimacao()
    {
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("Pego", false);
        DesativarCaixa();
        
    }

    public void DesativarCaixa()
    {
        gameObject.SetActive(false);
    }
}
