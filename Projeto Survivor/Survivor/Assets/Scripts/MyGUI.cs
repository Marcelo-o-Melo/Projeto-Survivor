using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGUI : MonoBehaviour
{
    public Slider sliderXp;
    public Slider sliderVida;
    public Player player;
    public Xp xpClass;
    public EscolherPoder escolherPoder;
    public Text textoLVL;
    public Text textoXP;
    public Text textoAreaXP;
    public Text txtVdm;
    public Text txtVda;
    public Text txtVida;
    public Text txtVidaMaxima;
    public Text textoContadorMortes;
    public Text textoContadorTempo;

    public Text textoContadorVdm;
    public Text textoContadorVda;
    public Text textoContadorVida;
    public Text textoContadorIma;
    public Text textoContadorRegen;

    static float tempoDecorrido = 0f;
    public static int contadorMortes = 0;
        void Start()
        {
            sliderXp.interactable = false;
            sliderVida.interactable = false;
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

        if (player != null)
        {
            int lvl = player.GetComponent<Player>().nivel;
            textoLVL.text = "LVL " + lvl.ToString();

            float xp = player.GetComponent<Player>().xp;
            textoXP.text = "XP: " + xp.ToString();

            float vdm = player.GetComponent<Player>().velocidade;
            txtVdm.text = "Velocidade de movimento: " + vdm.ToString();
            
            float vda = player.GetComponent<Player>().intervaloDisparo;
            txtVda.text = "Intervalo de disparo: " + vda.ToString();

            float vida = player.GetComponent<Player>().vidaAtual;
            txtVida.text = "Vida atual: " + vida.ToString();

            float vidaMax = player.GetComponent<Player>().vidaMaxima;
            txtVidaMaxima.text = "Vida maxima: " + vidaMax.ToString();
        }      

        float areaXp = Xp.distanciaMinima;
        textoAreaXP.text = "Area xp: " + areaXp.ToString();

        //////////contadores de poder///////////////////////

        int contvdm = escolherPoder.GetComponent<EscolherPoder>().contAumentarVDM;
        textoContadorVdm.text = "vdm: " + contvdm.ToString();

        int contvda = escolherPoder.GetComponent<EscolherPoder>().contAumentarVDA;
        textoContadorVda.text = "vda: " + contvda.ToString();

        int contvida = escolherPoder.GetComponent<EscolherPoder>().contAumentarVida;
        textoContadorVida.text = "vida: " + contvida.ToString();

        int contima = escolherPoder.GetComponent<EscolherPoder>().contAumentarIma;
        textoContadorIma.text = "ima: " + contima.ToString();

        int regen = escolherPoder.GetComponent<EscolherPoder>().contVidaRegen;
        textoContadorRegen.text = "regen: " + regen.ToString();

        ////////////////////////////////////////////////////////////

        }
        void AtualizarContador()
        {
        textoContadorMortes.text = "MORTES: " + contadorMortes.ToString();
        }
        //////////barra de vida///////////////
        public void AlterarVida(float vida) {
        sliderVida.maxValue = player.vidaMaxima;
        sliderVida.value = vida;
        }
        ////////////barra de xp////////////////
        public void AlterarXp(float xp) {
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
