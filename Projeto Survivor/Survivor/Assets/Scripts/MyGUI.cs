using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGUI : MonoBehaviour
{
    public Slider sliderXp;
    public Slider sliderVida;
    public Player player;
    public Text textoLVL;
    public Text textoXP;
    public Text txtVdm;
    public Text txtVda;
    public Text txtVida;
    public Text txtVidaMaxima;
    public Text textoContadorMortes;
    public Text textoContadorTempo;
    private float tempoDecorrido = 0f;
    public static int contadorMortes = 0;
        void Start()
        {
            AtualizarContador();
        }
        void Update()
        {
        tempoDecorrido += Time.deltaTime;
        AtualizarTextoDoContador();
        if (textoContadorMortes.text != contadorMortes.ToString())
        {
            AtualizarContador();
        }
        int lvl = player.GetComponent<Player>().nivel;
        textoLVL.text = "LVL " + lvl.ToString();

        int xp = player.GetComponent<Player>().xp;
        textoXP.text = "XP: " + xp.ToString();

        int vdm = player.GetComponent<Player>().velocidade;
        txtVdm.text = "Velocidade de movimento: " + vdm.ToString();
        
        float vda = player.GetComponent<Player>().intervaloDisparo;
        txtVda.text = "Intervalo de disparo: " + vda.ToString();

        int vida = player.GetComponent<Player>().vidaAtual;
        txtVida.text = "Vida atual: " + vida.ToString();

        int vidaMax = player.GetComponent<Player>().vidaMaxima;
        txtVidaMaxima.text = "Vida maxima: " + vidaMax.ToString();
        }
        void AtualizarContador()
        {
        textoContadorMortes.text = "MORTES: " + contadorMortes.ToString();
        }
        public void AlterarVida(int vida) {
        sliderVida.maxValue = player.vidaMaxima;
        sliderVida.value = vida;
        }
        public void AlterarXp(int xp) {
        sliderXp.maxValue = player.xpMaximo;
        sliderXp.value = xp;
        }
        void AtualizarTextoDoContador()
        {
        int minutos = Mathf.FloorToInt(tempoDecorrido / 60f);
        int segundos = Mathf.FloorToInt(tempoDecorrido % 60f);
        string textoFormatado = string.Format("{0:00}:{1:00}", minutos, segundos);
        textoContadorTempo.text = textoFormatado;
        }

}
