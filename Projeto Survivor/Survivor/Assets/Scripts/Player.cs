using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MyGUI gui;
    public EscolherPoder escolherPoder;
    public EscolherItem escolherItem;
  
    public GameObject shurikenPrefab;
    public GameObject facaPrefab;
    public Transform pontoLancamento;

    public float xp;
    public float xpMaximo;
    public int nivel;
    public float velocidade;
    public float vidaMaxima;
    public float vidaAtual;

    public float escudo;

    public float intervaloDisparo = 1f;
    public float forcaLancamento = 10f;
    public float distanciaMinima = 20f;
    public float taxaDeRegeneracao = 0f;
    public float intervaloDeRegeneracao = 1f;

    public bool regenera;
    public bool atirando;
    public bool poderFaca;
    public bool escudoAtivo;

    // Start is called before the first frame update
    void Start()
    {

        vidaMaxima = 50;
        xpMaximo = 10;
        vidaAtual = vidaMaxima;
        velocidade = 5;
        atirando = true;
        regenera = false;
        poderFaca = false; 
        escudoAtivo = false;

        InvokeRepeating("RegenerarVida", intervaloDeRegeneracao, intervaloDeRegeneracao);

        StartCoroutine(IntervaloDisparo()); // Inicia a rotina de intervalo de disparo
    }

    void FixedUpdate()
    {
        float movHori = Input.GetAxis("Horizontal");
        float movVert = Input.GetAxis("Vertical");

        Vector2 deslocamento = new Vector2(movHori, movVert) * velocidade * Time.deltaTime;
        
        transform.Translate(deslocamento);
      
    }
    public void RegenerarVida()
    {
    if (vidaAtual < vidaMaxima)
    {
        vidaAtual += taxaDeRegeneracao;

        // Atualizar o slider de vida
        gui.AlterarVida(vidaAtual);
    }
    else if (vidaAtual > vidaMaxima)
    {
        vidaAtual = vidaMaxima;
    }
    }

    public void Morrer()
    {
        if (vidaAtual <= 0)
        {
            Destroy(gameObject);  
        }
    }
    

    public void subirNivel()
    {
        if (xp >= xpMaximo)
        {

            xp = xp - xpMaximo;
            nivel++;
            xpMaximo += 10;
            gui.AlterarXp(xp);
            escolherPoder.AtribuirMetodosAleatorios();
            escolherPoder.novoPoder();
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("xp1"))
        {
            xp++;
            gui.AlterarXp(xp);
            subirNivel();
        }
        if (collision.gameObject.CompareTag("xp2"))
        {
            xp += 2;
            gui.AlterarXp(xp);
            subirNivel();
        }
        if (collision.gameObject.CompareTag("xp3"))
        {
            xp += 4;
            gui.AlterarXp(xp);
            subirNivel();
        }
        if (collision.gameObject.CompareTag("xp4"))
        {
            xp += 10;
            gui.AlterarXp(xp);
            subirNivel();
        }
        if (collision.gameObject.CompareTag("xp5"))
        {
            xp += 40;
            gui.AlterarXp(xp);
            subirNivel();
        }
        
    }

    void OnCollisionStay2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Inimigo"))
    {
        Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();

        if (inimigo != null)
        {
            if (escudoAtivo == true){
                escudo -= inimigo.dano;
                gui.AlterarEscudo(escudo);
            }
            if (escudo <= 0){
                escudoAtivo = false;
                vidaAtual -= inimigo.dano;
                escolherItem.gameObjectEscudo.SetActive(false);
                gui.AlterarVida(vidaAtual);

                Morrer();
            }

        }
    }
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

private void Disparar()
{
    // Get all enemies within the minimum distance
    GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
    GameObject alvoMaisProximo = null;
    float distanciaMaisProxima = Mathf.Infinity;

    // Search for the nearest enemy
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

    if (alvoMaisProximo != null)
    {
        // Calculate the direction of the nearest enemy
        Vector2 direcaoAlvo = alvoMaisProximo.transform.position - transform.position;
        direcaoAlvo.Normalize();

        // Generate the projectiles
        GameObject novoProjetil;

        if (poderFaca)
        {
            // Dispara a faca
            novoProjetil = Instantiate(facaPrefab, pontoLancamento.position, pontoLancamento.rotation);
            novoProjetil.SetActive(true);

            Rigidbody2D facaRigidbody = novoProjetil.GetComponent<Rigidbody2D>();

            if (facaRigidbody != null)
            {
                facaRigidbody.AddForce(direcaoAlvo * forcaLancamento, ForceMode2D.Impulse);
            }

            // Dispara a shuriken
            novoProjetil = Instantiate(shurikenPrefab, pontoLancamento.position, pontoLancamento.rotation);
            novoProjetil.SetActive(true);

            Rigidbody2D shurikenRigidbody = novoProjetil.GetComponent<Rigidbody2D>();

            if (shurikenRigidbody != null)
            {
                shurikenRigidbody.AddForce(direcaoAlvo * forcaLancamento, ForceMode2D.Impulse);
            }
        }
        else
        {
            // Dispara apenas a shuriken
            novoProjetil = Instantiate(shurikenPrefab, pontoLancamento.position, pontoLancamento.rotation);
            novoProjetil.SetActive(true);

            Rigidbody2D shurikenRigidbody = novoProjetil.GetComponent<Rigidbody2D>();

            if (shurikenRigidbody != null)
            {
                shurikenRigidbody.AddForce(direcaoAlvo * forcaLancamento, ForceMode2D.Impulse);
            }
        }
    }
}




}
