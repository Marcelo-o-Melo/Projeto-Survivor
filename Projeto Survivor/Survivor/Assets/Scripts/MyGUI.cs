using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGUI : MonoBehaviour
{
    public Slider sliderXp;
    public Slider sliderVida;
    public Slider sliderEscudo;

    public Disparo disparo;
    public Player player;
    public GerenciadorArmas gerenciadorArmas;
    public Xp xpClass;
    public EscolherPoder escolherPoder;
    public EscolherItem escolherItem;
    public PoderEspecial poderEspecial;

    public VidaPlayer vidaPlayer;
    public XpPlayer xpPlayer;
    public MovimentoPlayer movimentoPlayer;

    public Text textoLVL;
    public Text textoXP;
    public Text textoAreaXP;
    public Text txtVdm;
    public Text txtVda;
    public Text txtVida;
    public Text txtDano;
    public Text txtVidaMaxima;
    public Text textoContadorMortes;
    public Text textoContadorTempo;
    public Text textoEscudo;

    public Text txtUsosPoder;

    public Text textoContadorVdm;
    public Text textoContadorVda;
    public Text textoContadorVida;
    public Text textoContadorIma;
    public Text textoContadorRegen;
    public Text textoContadorDano;
    public Text textoContadorFaca;

    public static float tempoDecorrido = 0f;
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

        if (textoContadorMortes.text != contadorMortes.ToString()){
        AtualizarContador();
        }

       if(player != null){
        int lvl = xpPlayer.GetComponent<XpPlayer>().nivel;
        textoLVL.text = "LVL " + lvl.ToString();

        float xp = xpPlayer.GetComponent<XpPlayer>().xp;
        textoXP.text = "XP: " + xp.ToString();

        float vdm = movimentoPlayer.GetComponent<MovimentoPlayer>().velocidade;
        txtVdm.text = "Velocidade de movimento: " + vdm.ToString();
            
        float vda = disparo.GetComponent<Disparo>().intervaloDisparo;
        txtVda.text = "Intervalo de disparo: " + vda.ToString();

        float vida = vidaPlayer.GetComponent<VidaPlayer>().vidaAtual;
        txtVida.text = "Vida atual: " + vida.ToString();

        float vidaMax = vidaPlayer.GetComponent<VidaPlayer>().vidaMaxima;
        txtVidaMaxima.text = "Vida maxima: " + vidaMax.ToString();

        float escudo = vidaPlayer.GetComponent<VidaPlayer>().escudo;
        textoEscudo.text = "Escudo: " + escudo.ToString();

        float dano = gerenciadorArmas.GetComponent<GerenciadorArmas>().multiplicador;
        txtDano.text = "Multiplicador de dano: " + dano.ToString();
              
        float areaXp = Xp.distanciaMinima;
        textoAreaXP.text = "Area xp: " + areaXp.ToString();

        float usos = poderEspecial.GetComponent<PoderEspecial>().usos;
        txtUsosPoder.text = "" + usos.ToString();

       }
        

        //////////contadores de poder///////////////////////

        int contvdm = escolherPoder.GetComponent<EscolherPoder>().contAumentarVDM;
        textoContadorVdm.text = "vdm: " + contvdm.ToString();

        int contvda = escolherPoder.GetComponent<EscolherPoder>().contAumentarVDA;
        textoContadorVda.text = "vda: " + contvda.ToString();

        int contvida = escolherPoder.GetComponent<EscolherPoder>().contAumentarVida;
        textoContadorVida.text = "vida: " + contvida.ToString();

        int contima = escolherPoder.GetComponent<EscolherPoder>().contAumentarIma;
        textoContadorIma.text = "ima: " + contima.ToString();

        int contRegen = escolherPoder.GetComponent<EscolherPoder>().contVidaRegen;
        textoContadorRegen.text = "regen: " + contRegen.ToString();

        int contDano = escolherPoder.GetComponent<EscolherPoder>().contAumentarDanoArmas;
        textoContadorDano.text = "dano: " + contDano.ToString();

        int contFaca = escolherPoder.GetComponent<EscolherPoder>().contFaca;
        textoContadorFaca.text = "faca: " + contFaca.ToString();

        ////////////////////////////////////////////////////////////

        }
        void AtualizarContador()
        {
        textoContadorMortes.text = "MORTES: " + contadorMortes.ToString();
        }
        //////////barra de vida///////////////
        public void AlterarVida(float vida) {
        sliderVida.maxValue = vidaPlayer.vidaMaxima;
        sliderVida.value = vida;
        }
        ////////////barra de xp////////////////
        public void AlterarXp(float xp) {
        sliderXp.maxValue = xpPlayer.xpMaximo;
        sliderXp.value = xp;
        }
        //////////barra de escudo///////////////
        public void AlterarEscudo(float escudo) {
        sliderEscudo.maxValue = escolherItem.valorEscudo;
        sliderEscudo.value = escudo;
        }

        void AtualizarTextoDoContador()
        {
        int minutos = Mathf.FloorToInt(tempoDecorrido / 60f);
        int segundos = Mathf.FloorToInt(tempoDecorrido % 60f);
        string textoFormatado = string.Format("{0:00}:{1:00}", minutos, segundos);
        textoContadorTempo.text = textoFormatado;
        }

}
