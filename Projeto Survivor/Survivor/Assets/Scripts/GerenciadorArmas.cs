using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorArmas : MonoBehaviour
{
    public List<Projetil> projetil;
    public float multiplicador;

    void Start(){
        multiplicador = 1f;
    }

     // Resto do codigo

    public void AumentarDanoArmas()
{
    multiplicador *= 1.2f; //aumenta em 20%

}


}
