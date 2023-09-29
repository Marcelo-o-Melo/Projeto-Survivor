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
    public GameObject orbe5;
    public GameObject orbe6;
    public GameObject orbe7;
    public GameObject orbe8;
    public float velocidadeRotacao;
    /// <summary>
    /// dano em area
    /// </summary>

    public GameObject danoArea;
    public float areaFinal;

    private void Update()
    {
        VerificarOrbes();
        VerificarDanoArea();

        orbesOrbitais.transform.position = player.position;
        danoArea.transform.position = player.position;
        //recebe o multiplicador de velocidade da Classa Escolher Poder
        //velocidadeRotacao = EscolherPoder.multiplicadorVelocidadeProjetil;

        if (orbesOrbitais != null)
        {
            //rotaciona os orbes orbitais
            orbesOrbitais.Rotate(0f, 0f, velocidadeRotacao * Time.deltaTime);
        }

        //codigo do aumento da area
        if (danoArea != null)
        {
            float i = areaFinal;
            //danoArea.transform.Rotate(0f, 0f, 10 * Time.deltaTime);
            danoArea.transform.localScale = new Vector3(i, i, i);
        }

    }

    private void VerificarOrbes()
    {
        switch (escolherPoder.contOrbes)
        {
            case 1:
                orbe1.transform.localPosition = new Vector2(0, 20);

                orbe1.SetActive(true);

                velocidadeRotacao = 50;
                break;
            case 2:

                orbe2.transform.localPosition = new Vector2(0, -20);

                orbe2.SetActive(true);

                velocidadeRotacao = 100;
                break;
            case 3:
                orbe1.transform.localPosition = new Vector2(-10, 20);
                orbe2.transform.localPosition = new Vector2(-10, -20);
                orbe3.transform.localPosition = new Vector2(20, 0);

                orbe3.SetActive(true);
                velocidadeRotacao = 150;
                break;
            case 4:
                orbe1.transform.localPosition = new Vector2(0, 20);
                orbe2.transform.localPosition = new Vector2(0, -20);
                orbe3.transform.localPosition = new Vector2(20, 0);
                orbe4.transform.localPosition = new Vector2(-20, 0);

                orbe4.SetActive(true);
                velocidadeRotacao = 200;
                break;
            case 5:
                orbe5.transform.localPosition = new Vector2(0, 40);

                orbe5.SetActive(true);
                velocidadeRotacao = 250;
                break;
            case 6:
                orbe6.transform.localPosition = new Vector2(0, -40);

                orbe6.SetActive(true);
                velocidadeRotacao = 300;
                break;
            case 7:
                orbe7.transform.localPosition = new Vector2(40, 0);

                orbe7.SetActive(true);
                velocidadeRotacao = 350;
                break;
            case 8:

                orbe8.transform.localPosition = new Vector2(-40, 0);

                orbe8.SetActive(true);
                velocidadeRotacao = 400;
                break;
        }
    }

    private void VerificarDanoArea()
    {
        if (escolherPoder.contDanoArea >= 1)
        {
            areaFinal = escolherPoder.TamanhoArea + escolherPoder.TamanhoAreaDano;
            danoArea.SetActive(true);
        }
    }
}
