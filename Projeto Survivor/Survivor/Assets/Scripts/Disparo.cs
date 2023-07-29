using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public MyGUI gui;
    public EscolherPoder escolherPoder;
    public EscolherItem escolherItem;
    public Mira mira;
  
    public GameObject shurikenPrefab;
    public GameObject facaPrefab;
    public Transform pontoLancamentoPrimario;

    public Transform pontoLancamento1;
    public Transform pontoLancamento2;
    public Transform pontoLancamento3;

    public GameObject ponto1;
    public GameObject ponto2;
    public GameObject ponto3;

    public Vector2 direcaoAlvo;

    public float intervaloDisparo = 1f;
    public float forcaLancamento = 10f;
    public float distanciaMinima = 20f;

    public bool atirando;
    public bool poderFaca;

    // Start is called before the first frame update
    void Start()
    {
        atirando = true;
        poderFaca = false; 

        StartCoroutine(IntervaloDisparo()); // Inicia a rotina de intervalo de disparo

    }

    IEnumerator IntervaloDisparo()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloDisparo);
            if (atirando)
            {
                Disparar(); // Chama o metodo Disparar apenas se estiver atirando
            }
        }
    }

    public void ReiniciarRotinaDeDisparo()
    {
        if (!atirando)
        {
            AtivarDisparo(); // Ativa o disparo
            InvokeRepeating("Disparar", intervaloDisparo, intervaloDisparo); // Chama repetidamente o metodo Disparar()
        }
    }

    public void AtivarDisparo()
    {
        atirando = true;
    }

    public void DesativarDisparo()
    {
        atirando = false;
    }

    void DispararProjetil(GameObject prefab, Transform pontoLancamento, Vector2 direcaoAlvo, float forcaLancamento)
    {
        GameObject novoProjetil = Instantiate(prefab, pontoLancamento.position, pontoLancamento.rotation);
        novoProjetil.SetActive(true);

        Rigidbody2D projetilRigidbody = novoProjetil.GetComponent<Rigidbody2D>();

        projetilRigidbody.AddForce(direcaoAlvo * forcaLancamento, ForceMode2D.Impulse);

        if (prefab == shurikenPrefab)
        {
        RotacaoProjetil rotacaoProjetil = novoProjetil.GetComponent<RotacaoProjetil>();
        if (rotacaoProjetil != null)
        {
            rotacaoProjetil.rotationSpeed = 200f; // You can adjust the rotation speed here if needed.
        }
        }

        if (prefab == facaPrefab)
        {
        RotacaoProjetil rotacaoProjetil = novoProjetil.GetComponent<RotacaoProjetil>();
        if (rotacaoProjetil != null)
        {
            rotacaoProjetil.rotationSpeed = 200f; // You can adjust the rotation speed here if needed.
        }
        }

    }

    public void Disparar()
    {
        
        GameObject alvoMaisProximo = FindNearestEnemy();
        
        if (alvoMaisProximo != null)
        {
            direcaoAlvo = alvoMaisProximo.transform.position - transform.position;
            direcaoAlvo.Normalize();
            
            if (escolherPoder.contFaca >= 1)
            {
                DispararProjetil(facaPrefab, pontoLancamento1, direcaoAlvo, forcaLancamento);  
            }
            if (escolherPoder.contFaca >= 3)
            {
                DispararProjetil(facaPrefab, pontoLancamento2, direcaoAlvo, forcaLancamento);  
            }
            if (escolherPoder.contFaca >= 5)
            {
                DispararProjetil(facaPrefab, pontoLancamento3, direcaoAlvo, forcaLancamento);  
            }
            
            DispararProjetil(shurikenPrefab, pontoLancamentoPrimario, direcaoAlvo, forcaLancamento);
        }
        
    }

    public GameObject FindNearestEnemy()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        GameObject alvoMaisProximo = null;
        float distanciaMaisProxima = Mathf.Infinity;

        foreach (GameObject inimigo in inimigos)
        {
            Vector2 direcaoInimigo = inimigo.transform.position - transform.position;
            float distanciaInimigo = direcaoInimigo.magnitude;

            if (distanciaInimigo <= distanciaMinima && distanciaInimigo < distanciaMaisProxima)
            {
                alvoMaisProximo = inimigo;
                distanciaMaisProxima = distanciaInimigo;
            }
        }

        return alvoMaisProximo;
    }
}
