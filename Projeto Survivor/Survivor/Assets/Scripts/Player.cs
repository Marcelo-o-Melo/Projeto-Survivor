using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int vidaMaxima = 5;
    [SerializeField] private int vidaAtual;
    [SerializeField] public int xp;
    [SerializeField] public int nivel;
    public BarraVida barraVida;
    public BarraXp barraXp;
   
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
    }
    public void Morrer(){
        
        if (vidaAtual <= 0){
            Destroy(gameObject);  
            }

    }
    public void subirNivel(){
        if (xp >= 10){
            xp = 0;
            Debug.Log("Subiu de Nivel");
            nivel +=1;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("xp"))
        {
            Debug.Log("pegou xp");
            xp +=1;
            barraXp.AlterarXp(xp);
            subirNivel();
        }
        if (collision.gameObject.CompareTag("Alvo"))
        {
            Debug.Log("hit");
            vidaAtual -=1;
            barraVida.AlterarVida(vidaAtual);
            Morrer();
                
        }
}
}

