using UnityEngine;

public class Xp : MonoBehaviour
{
    public static float velocidade = 10f;
    public static float distanciaMinima = 3f;
    public float distanciaMinimaXp = 3f;
    public float valorInicial;
    public float valorTotal;
    [SerializeField] private Transform player;
    public Pool poolXp;
    

    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 9); // caixa
        //Physics2D.IgnoreLayerCollision(gameObject.layer, 8); // xp
        Physics2D.IgnoreLayerCollision(gameObject.layer, 7); // arma
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6); // inimigo    
    }
    private void Update()
    {
        
        if (player != null)
        {
            Vector2 direcao = player.position - transform.position;

            float distancia = direcao.magnitude;

            direcao.Normalize();

            if (distancia <= distanciaMinima)
            {
                transform.Translate(direcao * velocidade * Time.deltaTime);
            }
        }

        GameObject[] xps = GameObject.FindGameObjectsWithTag("Xp");

        foreach (GameObject xp in xps)
        {
            Vector2 direcaoXp = xp.transform.position - transform.position;
            float distancia = direcaoXp.magnitude;

            direcaoXp.Normalize();

            if (distancia <= distanciaMinimaXp)
            {
                transform.Translate(direcaoXp * 2 * Time.deltaTime);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioController.Instance.xpSFX.Play();
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Xp"))
        {
            //pego o xp que foi colidido, para usar na soma
            float valorXp = collision.gameObject.GetComponent<Xp>().valorTotal;
            float valorTotalColidido = 0;
            valorTotalColidido += valorXp;

            //pego um xp da pool, para ativar depois
            GameObject xpObjectPool = poolXp.GetObjetos();


            //verifico se o xp não é nulo (verifico se a ainda tem xp disponivel pool) 
            if (xpObjectPool != null)
            {
                //somo o valor total do xp colidido + o valor total do xp atual e passo para o valor total do xp que vai ser ativado
                xpObjectPool.GetComponent<Xp>().valorTotal = valorTotalColidido + valorTotal;
                //ativo o xp com a soma e transformo a posição dele na posição do xp atual
                xpObjectPool.SetActive(true);
                xpObjectPool.transform.position = gameObject.transform.position;
            }

            //desativo o xp colidido e o xp atual quando eles colidem
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);

            valorTotal = valorInicial;

        }
        
    }
}
