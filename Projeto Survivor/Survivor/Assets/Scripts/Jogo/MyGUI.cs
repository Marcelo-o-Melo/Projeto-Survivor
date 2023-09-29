using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    //public Xp xpClass;
    public EscolherPoder escolherPoder;
    public EscolherItem escolherItem;
    public PoderEspecial poderEspecial;
    public Poderes poderes;
    public VidaPlayer vidaPlayer;
    public XpPlayer xpPlayer;
    public MovimentoPlayer movimentoPlayer;
    public Text textoLVL;
    public Text textoXP;
    /// STATUS ///
    public Text txtVida;
    public Text txtVidaMaxima;
    public Text txtVda;   
    public Text txtVdm;
    public Text textoAreaXP;
    public Text textoRegenVidaPoder;
    public Text txtDano;
    public Text textoFacasPoder;
    public Text textoOrbesPoder;
    public Text textoEscudoItem;
    public Text textoEscudoPoder;
    public Text textoAreaPoder;
    public Text textoAreaDanoPoder;
    public Text textoVelocidadeProjetilPoder;
    ///
    public float faca;
    public Text textoContadorMortes;
    public Text textoContadorTempo;
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
            ////////////////////////////// -> STATUS <- //////////////////////////////
            float vida = vidaPlayer.GetComponent<VidaPlayer>().vidaAtual;
            txtVida.text = "Vida atual: " + vida;
            ///// VIDA MAXIMA /////
            float vidaMax = vidaPlayer.GetComponent<VidaPlayer>().vidaMaxima;
            txtVidaMaxima.text = "Vida maxima: " + vidaMax;
            ///// VDA /////
            ///
            
            float vda = disparo.GetComponent<Disparo>().intervaloDisparo;
            txtVda.text = "Velocidade de ataque: " + vda;
            ///// VDM /////
            float vdm = movimentoPlayer.GetComponent<MovimentoPlayer>().velocidade;
            txtVdm.text = "Velocidade de movimento: " + vdm;
            ///// IMÃ /////
            float areaXp = Xp.distanciaMinima;
            textoAreaXP.text = "Area xp: " + areaXp;
            ///// REGEN DE VIDA /////
            float regenVida = vidaPlayer.GetComponent<VidaPlayer>().taxaDeRegeneracao;
            textoRegenVidaPoder.text = "Regen Vida: " + regenVida;
            ///// MULTIPLICADOR DE DANO DAS ARMAS /////
            float dano = EscolherPoder.multiplicador;
            txtDano.text = "Multiplicador de dano: " + dano;
            ///// FACA /////
            textoFacasPoder.text = "Quantidade de facas: " + faca;
            ///// ORBES /////
            float quantOrbes = escolherPoder.contOrbes;
            textoOrbesPoder.text = "Quantidade de Orbes: " + quantOrbes;
            ///// ESCUDOS /////
            float escudoItem = vidaPlayer.GetComponent<VidaPlayer>().escudoItem;
            textoEscudoItem.text = "Escudo item: " + escudoItem;
            float escudoPoder = vidaPlayer.GetComponent<VidaPlayer>().escudoPoder;
            textoEscudoPoder.text = "Escudo poder: " + escudoPoder;
            ///// ÁREA /////
            textoAreaPoder.text = "Tamanho Area: " + escolherPoder.TamanhoArea;
            ///// DANO ÁREA /////
            textoAreaDanoPoder.text = "Tamanho Area Dano: " + escolherPoder.TamanhoAreaDano;
            ///// VELOCIDADE DE PROJETIL /////
            textoVelocidadeProjetilPoder.text = "Velocidade Projetil: " + EscolherPoder.multiplicadorVelocidadeProjetil;
                    
            /////////////////////////////////////////////////////
            float usos = poderEspecial.GetComponent<PoderEspecial>().usos;
            txtUsosPoder.text = "" + usos;
        }
        if (!vidaPlayer.vivo)
        {
            sliderVida.gameObject.SetActive(false);
            sliderEscudoPoder.gameObject.SetActive(false);
        }
    }
    void AtualizarContador()
    {
    textoContadorMortes.text = "" + contadorMortes;
    }
    //////////barra de vida///////////////
    public void AlterarVida(float vida) 
    {
    sliderVida.maxValue = vidaPlayer.vidaMaxima;
    sliderVida.value = vida;
    }
    ////////////barra de xp////////////////
    public void AlterarXp(float xp) 
    {
    sliderXp.maxValue = xpPlayer.xpMaximo;
    sliderXp.value = xp;
    }
    //////////barra de escudo item///////////////
    public void AlterarEscudoItem(float escudoItem) 
    {
    sliderEscudoItem.maxValue = escolherItem.valorEscudo;
    sliderEscudoItem.value = escudoItem;
    }
    //////////barra de escudo poder///////////////
    public void AlterarEscudoPoder(float escudoPoder) 
    {
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