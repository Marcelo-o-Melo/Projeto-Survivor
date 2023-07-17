using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int vidaMaxima;
    public int vidaAtual;
    [SerializeField] public int xp;
    [SerializeField] public int xpMaximo;
    [SerializeField] public int nivel;
    public ControladorJogo controladorJogo;
    public MyGUI gui;
    public int velocidade;
    public GameObject projetilPrefab;
    public Transform pontoLancamento;
    
    public float intervaloDisparo = 1f;
    public float forcaLancamento = 10f;
    public bool atirando;
    public float distanciaMinima = 20f;

    // Start is called before the first frame update
    void Start()
    {
        vidaMaxima = 10;
        xpMaximo = 10;
        vidaAtual = vidaMaxima;
        velocidade = 5;
        atirando = true;

        StartCoroutine(IntervaloDisparo()); // Inicia a rotina de intervalo de disparo
    }

    void Update()
    {
        float movHori = Input.GetAxis("Horizontal");
        float movVert = Input.GetAxis("Vertical");

        Vector2 deslocamento = new Vector2(movHori, movVert) * velocidade * Time.deltaTime;
        
        transform.Translate(deslocamento);
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
            xpMaximo += 10;
            gui.AlterarXp(xp);
            controladorJogo.novoPoder();
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("xp"))
        {
            xp++;
            gui.AlterarXp(xp);
            subirNivel();
        }
        if (collision.gameObject.CompareTag("Alvo"))
        {
            vidaAtual -= 1;
            gui.AlterarVida(vidaAtual);
            Morrer();      
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
