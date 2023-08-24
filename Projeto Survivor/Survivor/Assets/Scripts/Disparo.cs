using System.Collections;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public MyGUI gui;
    public EscolherPoder escolherPoder;
    public EscolherItem escolherItem;
    public Mira mira;

    public Pool poolProjetilShuriken;
    public Pool poolProjetilFaca;

    public Transform pontoLancamento1;
    public Transform pontoLancamento2;
    public Transform pontoLancamento3;

    public Vector2 direcaoAlvo;

    public float intervaloDisparoShuriken = 1f; // Intervalo para shurikens
    public float intervaloDisparoFaca = 1.5f;   // Intervalo para facas

    public float forcaLancamento;
    public float distanciaMinima = 20f;

    public bool atirando;
    public bool poderFaca;

    // Start is called before the first frame update
    void Start()
    {

        forcaLancamento = EscolherPoder.multiplicadorVelocidadeProjetil / 10;
        //atirando = true;
        poderFaca = false;

        StartCoroutine(IntervaloDisparoShuriken());// Inicia a corrotina de intervalo de disparo de shurikens
        StartCoroutine(IntervaloDisparoFaca());// Inicia a corrotina de intervalo de disparo de facas
    }

    private void Update()
    {
        //intervaloDisparoShuriken = escolherPoder.multilpicadorIntervalo ; // Intervalo para shurikens
        //intervaloDisparoFaca = escolherPoder.multilpicadorIntervalo;   // Intervalo para facas       
    }
    IEnumerator IntervaloDisparoShuriken()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloDisparoShuriken);
            if (atirando)
            {
                GameObject alvoMaisProximo = FindNearestEnemy();

                if (alvoMaisProximo != null)
                {
                    direcaoAlvo = alvoMaisProximo.transform.position - transform.position;
                    direcaoAlvo.Normalize();

                    ProjetilShuriken(pontoLancamento1, direcaoAlvo, forcaLancamento);
                }
            }
        }
    }
    IEnumerator IntervaloDisparoFaca()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloDisparoFaca);
            if (atirando)
            {
                GameObject alvoMaisProximo = FindNearestEnemy();

                if (alvoMaisProximo != null)
                {
                    direcaoAlvo = alvoMaisProximo.transform.position - transform.position;
                    direcaoAlvo.Normalize();

                    if (escolherPoder.contFaca >= 1)
                    {
                        gui.faca = 1;
                        ProjetilFaca(pontoLancamento1, direcaoAlvo, forcaLancamento);
                    }
                    if (escolherPoder.contFaca >= 3)
                    {
                        gui.faca = 2;
                        ProjetilFaca(pontoLancamento2, direcaoAlvo, forcaLancamento);
                    }
                    if (escolherPoder.contFaca >= 5)
                    {
                        gui.faca = 3;
                        ProjetilFaca(pontoLancamento3, direcaoAlvo, forcaLancamento);
                    }
                }
            }
        }
    }
    public void ReiniciarRotinaDeDisparo()
    {
        if (!atirando)
        {
            AtivarDisparo(); // Ativa o disparo
            InvokeRepeating("DispararFaca", intervaloDisparoFaca, intervaloDisparoFaca); // Chama repetidamente o metodo Disparar()
            InvokeRepeating("DispararShuriken", intervaloDisparoShuriken, intervaloDisparoShuriken); // Chama repetidamente o metodo Disparar()
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
    void ProjetilShuriken(Transform pontoLancamento, Vector2 direcaoAlvo, float forcaLancamento)
    {
        ///////// OBJECT POOOLING ////////
        GameObject projetilShuriken = poolProjetilShuriken.GetObjetos();

        if (projetilShuriken != null)
        {
            projetilShuriken.SetActive(true);
            projetilShuriken.transform.position = pontoLancamento.position;
            Rigidbody2D projetilRigidbody = projetilShuriken.GetComponent<Rigidbody2D>();
            projetilRigidbody.AddForce(direcaoAlvo * forcaLancamento, ForceMode2D.Impulse);
        }
    }
    void ProjetilFaca(Transform pontoLancamento, Vector2 direcaoAlvo, float forcaLancamento)
    {
        ///////// OBJECT POOOLING ////////
        GameObject projetilFaca = poolProjetilFaca.GetObjetos();

        if (projetilFaca != null)
        {
            projetilFaca.SetActive(true);
            projetilFaca.transform.position = pontoLancamento.position;
            Rigidbody2D projetilRigidbody = projetilFaca.GetComponent<Rigidbody2D>();
            projetilRigidbody.AddForce(direcaoAlvo * forcaLancamento, ForceMode2D.Impulse);
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
