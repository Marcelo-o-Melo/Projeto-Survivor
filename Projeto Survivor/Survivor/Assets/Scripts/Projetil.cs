using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public GerenciadorArmas gerenciador;
    public float danoBase;
    public float danoFinal;
    private float tempoDestruicao;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 3); //player
        Physics2D.IgnoreLayerCollision(gameObject.layer, 7); //arma
        
        tempoDestruicao = 2f;
        
        Destroy(gameObject, tempoDestruicao);
    }
    private void Update() {
        danoFinal = danoBase * gerenciador.multiplicador;
        
    }

}
