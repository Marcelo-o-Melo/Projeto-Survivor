using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InimigoSlimeAnima : MonoBehaviour
{
    private bool face = true;
    private Transform inimigoTransform;
    private MovimentoInimigo movInimigo;

    void Start()
    {
        movInimigo = GetComponent<MovimentoInimigo>();
        inimigoTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movInimigo.direcao.x > 0 && face)
        {
            Flip();
        }
        if (movInimigo.direcao.x < 0 && face)
        {
            Flip();
        }
    }
    void Flip()
    {
        face = !face;

        Vector3 escala = inimigoTransform.localScale;

        escala.x *= -1;
        inimigoTransform.localScale = escala;
    }
}
