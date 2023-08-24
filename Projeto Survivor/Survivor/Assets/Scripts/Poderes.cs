using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poderes : MonoBehaviour
{
    public Transform player;
    public EscolherPoder escolherPoder;
/// <summary>
/// orbes
/// </summary>
    public Transform orbesOrbitais;
    public GameObject orbe1;
    public GameObject orbe2;
    public GameObject orbe3;
    public GameObject orbe4;
    public float velocidadeRotacao;
/// <summary>
/// dano em area
/// </summary>

    public GameObject danoArea;
    public float areaFinal;

    private void Update() {
        VerificarOrbes();
        VerificarDanoArea();

        orbesOrbitais.transform.position = player.position;
        danoArea.transform.position = player.position;
        //recebe o multiplicador de velocidade da Classa Escolher Poder
        velocidadeRotacao = EscolherPoder.multiplicadorVelocidadeProjetil;

        if(orbesOrbitais != null)
        {
            //rotaciona os orbes orbitais
            orbesOrbitais.Rotate(0f, 0f, velocidadeRotacao * Time.deltaTime);
        }

        //codigo do aumento da area
        if(danoArea != null)
        {
            float i = areaFinal;
            danoArea.transform.localScale = new Vector3(i, i, i);
        }


    }

    private void VerificarOrbes(){
        if(escolherPoder.contOrbes >= 1){
            orbe1.SetActive(true);
        }
        if(escolherPoder.contOrbes >= 2){
            orbe2.SetActive(true);               
        }
        if(escolherPoder.contOrbes >= 3){
            orbe3.SetActive(true);                
        }
        if(escolherPoder.contOrbes >= 4){
            orbe4.SetActive(true);                
        }
    }

    private void VerificarDanoArea(){
        if(escolherPoder.contDanoArea >= 1){
            areaFinal = escolherPoder.TamanhoArea + escolherPoder.TamanhoAreaDano;
            danoArea.SetActive(true);
        }
    }
}
