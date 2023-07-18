using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float vidaMaxima;
    public float vidaAtual;
    [SerializeField] public float xp;
    [SerializeField] public float xpMaximo;
    [SerializeField] public int nivel;
    public ControladorJogo controladorJogo;
    public MyGUI gui;
    public EscolherPoder escolherPoder;
    public float velocidade;
    public GameObject projetilPrefab;
    public Transform pontoLancamento;
    
    public float intervaloDisparo = 1f;
    public float forcaLancamento = 10f;
    public bool atirando;
    public float distanciaMinima = 20f;
    public bool regenera;
    public float taxaDeRegeneracao = 0f;
    public float intervaloDeRegeneracao = 1f;

    // Start is called before the first frame update
    void Start()
    {

        vidaMaxima = 50;
        xpMaximo = 10;
        vidaAtual = vidaMaxima;
        velocidade = 5;
        atirando = true;
        regenera = false;

        InvokeRepeating("RegenerarVida", intervaloDeRegeneracao, intervaloDeRegeneracao);

        StartCoroutine(IntervaloDisparo()); // Inicia a rotina de intervalo de disparo
    }

    void Update()
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
    }
    else if (vidaAtual > vidaMaxima){
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
            xp = 0;
            nivel++;
            xpMaximo += 10; //valor comentado para tester de nivel
            gui.AlterarXp(xp);
            escolherPoder.OnPlayerLevelUp();
            controladorJogo.novoPoder();
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
        
        if (collision.gameObject.CompareTag("Alvo"))
        {
            Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();
            
            if (inimigo != null)
            {
                vidaAtual -= inimigo.dano;
                gui.AlterarVida(vidaAtual);
                Morrer();    
                // Restante do codigo para atualizar a vida e tratar a morte do jogador...
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
    // Procura o alvo
    GameObject alvo = GameObject.FindGameObjectWithTag("Alvo");

    if (alvo != null)
    {
        // Calcula a direcao do alvo
        Vector2 direcaoAlvo = alvo.transform.position - transform.position;
        float distanciaAlvo = direcaoAlvo.magnitude;   

        if (distanciaAlvo <= distanciaMinima)
        {
            direcaoAlvo.Normalize();

            // Gera um projetil
            GameObject novoProjetil = Instantiate(projetilPrefab, pontoLancamento.position, pontoLancamento.rotation);
            novoProjetil.SetActive(true);

            // Aplica uma forca ao projetil
            Rigidbody2D projetil = novoProjetil.GetComponent<Rigidbody2D>();
            if (projetil != null)
            {
                projetil.AddForce(direcaoAlvo * forcaLancamento, ForceMode2D.Impulse);
            }
        }
    }
}
}
