using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float dano;
    public float tempoDestruicao;
    void Start()
    {
        Destroy(gameObject, tempoDestruicao);
    }

}
