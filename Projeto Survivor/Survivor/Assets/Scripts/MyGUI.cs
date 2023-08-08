using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGUI : MonoBehaviour
{
    public Slider sliderXp;
    public Slider sliderVida;
    public Slider sliderEscudoItem;
    public Slider sliderEscudoPoder;

    public Disparo disparo;
    public Player player;
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
    public Text textoEscudoItem;
    public Text textoEscudoPoder;

    public Text txtUsosPoder;

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
    textoLVL.text = "LVL " + lvl;

    float xp = xpPlayer.GetComponent<XpPlayer>().xp;
    textoXP.text = "XP: " + xp;

    float vdm = movimentoPlayer.GetComponent<MovimentoPlayer>().velocidade;
    txtVdm.text = "Velocidade de movimento: " + vdm;
            
    float vda = disparo.GetComponent<Disparo>().intervaloDisparo;
    txtVda.text = "Intervalo de disparo: " + vda;

    float vida = vidaPlayer.GetComponent<VidaPlayer>().vidaAtual;
    txtVida.text = "Vida atual: " + vida;

    float vidaMax = vidaPlayer.GetComponent<VidaPlayer>().vidaMaxima;
    txtVidaMaxima.text = "Vida maxima: " + vidaMax;

    float escudoItem = vidaPlayer.GetComponent<VidaPlayer>().escudoItem;
    textoEscudoItem.text = "Escudo item: " + escudoItem;

    float escudoPoder = vidaPlayer.GetComponent<VidaPlayer>().escudoPoder;
    textoEscudoPoder.text = "Escudo poder: " + escudoPoder;

    float dano = EscolherPoder.multiplicador;
    txtDano.text = "Multiplicador de dano: " + dano;
              
    float areaXp = Xp.distanciaMinima;
    textoAreaXP.text = "Area xp: " + areaXp;

    float usos = poderEspecial.GetComponent<PoderEspecial>().usos;
    txtUsosPoder.text = "" + usos;

    }

    }
    void AtualizarContador()
    {
    textoContadorMortes.text = "MORTES: " + contadorMortes;
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
    //////////barra de escudo item///////////////
    public void AlterarEscudoItem(float escudoItem) {
    sliderEscudoItem.maxValue = escolherItem.valorEscudo;
    sliderEscudoItem.value = escudoItem;
    }
    //////////barra de escudo poder///////////////
    public void AlterarEscudoPoder(float escudoPoder) {
    sliderEscudoPoder.maxValue = vidaPlayer.escudoPoderMaximo;
    sliderEscudoPoder.value = escudoPoder;
    }

    void AtualizarTextoDoContador()
    {
    int minutos = Mathf.FloorToInt(tempoDecorrido / 60f);
    int segundos = Mathf.FloorToInt(tempoDecorrido % 60f);
    string textoFormatado = string.Format("{0:00}:{1:00}", minutos, segundos);
    textoContadorTempo.text = textoFormatado;
    }

}