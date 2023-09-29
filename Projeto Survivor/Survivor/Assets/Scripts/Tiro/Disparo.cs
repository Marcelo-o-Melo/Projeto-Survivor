using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public MyGUI gui;
    public EscolherPoder escolherPoder;
    public EscolherItem escolherItem;
    public Mira mira;

    public Pool poolProjetilMartelo;
    public Pool poolProjetilFaca;

    public Transform pontoLancamento1;
    public Transform pontoLancamento2;
    public Transform pontoLancamento3;
    public Transform pontoLancamento4;
    public Transform pontoLancamento5;

    public Transform player;

    public Vector2 direcaoAlvo;

    public float intervaloDisparo = 0.9f;
    public float intervaloDisparoMartelo = 0.1f; // Intervalo para martelo
    public float intervaloDisparoFaca = 0.5f;   // Intervalo para facas

    public float forcaLancamento;
    public float distanciaMinima = 20f;

    public bool atirandoFaca;
    public bool atirandoMartelo;
    public bool poderFaca;

    Coroutine faca;
    Coroutine martelo;

    // Start is called before the first frame update
    void Start()
    {
        forcaLancamento = EscolherPoder.multiplicadorVelocidadeProjetil / 10;
        //atirando = true;
        poderFaca = false;

        martelo = StartCoroutine(IntervaloDisparoMartelo());// Inicia a corrotina de intervalo de disparo de shurikens
        faca = StartCoroutine(IntervaloDisparoFaca());// Inicia a corrotina de intervalo de disparo de facas
    }
    void Update()
    {
        if (intervaloDisparo > 0 && intervaloDisparo < 0.2f)
        {
            intervaloDisparo = 0f;
        }
        if (!player.GetComponent<VidaPlayer>().vivo)
        {
            StopCoroutine(martelo);
            StopCoroutine(faca);
        }
    }

    IEnumerator IntervaloDisparoMartelo()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloDisparo + intervaloDisparoMartelo);
            if (atirandoMartelo)
            {
                GameObject alvoMaisProximo = FindNearestEnemy();
                
                if (alvoMaisProximo != null)
                {
                    direcaoAlvo = alvoMaisProximo.transform.position - player.position;
                    direcaoAlvo.Normalize();
                    AudioController.Instance.disparoSFX.Play();
                    ProjetilMartelo(pontoLancamento1, direcaoAlvo, forcaLancamento);
                }
            }
        }
    }
    IEnumerator IntervaloDisparoFaca()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloDisparo + intervaloDisparoFaca);
            if (atirandoFaca)
            {
                GameObject alvoMaisProximo = FindNearestEnemy();

                if (alvoMaisProximo != null)
                {
                    direcaoAlvo = alvoMaisProximo.transform.position - player.position;
                    direcaoAlvo.Normalize();

                    
                    switch (escolherPoder.contFaca)
                    {
                        case 1:
                            AudioController.Instance.disparoSFX.Play();
                            pontoLancamento1.localPosition = new Vector2(-10, 0);

                            gui.faca = 1;
                            ProjetilFaca(pontoLancamento1, direcaoAlvo, forcaLancamento);
                            break;
                        case 2:
                            AudioController.Instance.disparoSFX.Play();
                            pontoLancamento1.localPosition = new Vector2(-10, 3);

                            pontoLancamento2.localPosition = new Vector2(-10, -3);

                            gui.faca = 1;
                            ProjetilFaca(pontoLancamento1, direcaoAlvo, forcaLancamento);
                            ProjetilFaca(pontoLancamento2, direcaoAlvo, forcaLancamento);
                            break;
                        case 3:
                            AudioController.Instance.disparoSFX.Play();
                            pontoLancamento1.localPosition = new Vector2(-10, 6);

                            pontoLancamento2.localPosition = new Vector2(-10, 0);

                            pontoLancamento3.localPosition = new Vector2(-10, -6);

                            gui.faca = 1;
                            ProjetilFaca(pontoLancamento1, direcaoAlvo, forcaLancamento);
                            ProjetilFaca(pontoLancamento2, direcaoAlvo, forcaLancamento);
                            ProjetilFaca(pontoLancamento3, direcaoAlvo, forcaLancamento);
                            break;
                        case 4:
                            AudioController.Instance.disparoSFX.Play();
                            pontoLancamento1.localPosition = new Vector2(-10, 9);

                            pontoLancamento2.localPosition = new Vector2(-10, 3);

                            pontoLancamento3.localPosition = new Vector2(-10, -3);

                            pontoLancamento4.localPosition = new Vector2(-10, -9);

                            gui.faca = 1;
                            ProjetilFaca(pontoLancamento1, direcaoAlvo, forcaLancamento);
                            ProjetilFaca(pontoLancamento2, direcaoAlvo, forcaLancamento);
                            ProjetilFaca(pontoLancamento3, direcaoAlvo, forcaLancamento);
                            ProjetilFaca(pontoLancamento4, direcaoAlvo, forcaLancamento);
                            break;
                        case 5:
                            AudioController.Instance.disparoSFX.Play();
                            pontoLancamento1.localPosition = new Vector2(-10, 12);

                            pontoLancamento2.localPosition = new Vector2(-10, 6);

                            pontoLancamento3.localPosition = new Vector2(-10, 0);

                            pontoLancamento4.localPosition = new Vector2(-10, -6);

                            pontoLancamento5.localPosition = new Vector2(-10, -12);

                            gui.faca = 1;
                            ProjetilFaca(pontoLancamento1, direcaoAlvo, forcaLancamento);
                            ProjetilFaca(pontoLancamento2, direcaoAlvo, forcaLancamento);
                            ProjetilFaca(pontoLancamento3, direcaoAlvo, forcaLancamento);
                            ProjetilFaca(pontoLancamento4, direcaoAlvo, forcaLancamento);
                            ProjetilFaca(pontoLancamento5, direcaoAlvo, forcaLancamento);
                            break;
                    }
                }
            }
        }
    }
    public void ReiniciarRotinaDeDisparo()
    {
        if (!atirandoMartelo && !atirandoFaca)
        {
            AtivarDisparo(); // Ativa o disparo
            InvokeRepeating("DispararFaca", intervaloDisparoFaca, intervaloDisparoFaca); // Chama repetidamente o metodo Disparar()
            InvokeRepeating("DispararMartelo", intervaloDisparoMartelo, intervaloDisparoMartelo); // Chama repetidamente o metodo Disparar()
        }
    }
    public void AtivarDisparo()
    {

        atirandoMartelo = true;
        atirandoFaca = true;
    }
    public void DesativarDisparo()
    {
        atirandoMartelo = false;
        atirandoFaca = false;

    }
    void ProjetilMartelo(Transform pontoLancamento, Vector2 direcaoAlvo, float forcaLancamento)
    {
        ///////// OBJECT POOOLING ////////
        GameObject projetilMartelo = poolProjetilMartelo.GetObjetos();

        if (projetilMartelo != null)
        {
            projetilMartelo.SetActive(true);
            projetilMartelo.transform.position = pontoLancamento.position;
            Rigidbody2D projetilRigidbody = projetilMartelo.GetComponent<Rigidbody2D>();
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

            Vector2 direcaoInimigo = inimigo.transform.position - player.position;
            float distanciaInimigo = direcaoInimigo.magnitude;

            if (distanciaInimigo <= distanciaMinima && distanciaInimigo < distanciaMaisProxima)
            {
                if (inimigo.GetComponent<Inimigo>().vivo)
                {
                    alvoMaisProximo = inimigo;
                    distanciaMaisProxima = distanciaInimigo;
                }

            }
        }
        return alvoMaisProximo;
    }
}
