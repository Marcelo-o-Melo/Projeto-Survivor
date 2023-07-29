using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscolherPoder : MonoBehaviour
{
    [SerializeField] private GameObject painelPoder;
    public Player player;
    public Disparo disparo;
    public MyGUI gui;
    public GerenciadorArmas gerenciadorArmas;

    public VidaPlayer vidaPlayer;
    public XpPlayer xpPlayer;
    public MovimentoPlayer movimentoPlayer;

    public int contAumentarVida;
    public int contAumentarVDA;
    public int contAumentarVDM;
    public int contAumentarIma;
    public int contRegenVida;
    public int contVidaRegen;
    public int contAumentarDanoArmas;
    public int contFaca;
    public Button[] botoes;
    public Texture[] icones;
    public Sprite[] background;

    private int[] metodosIndices = new int[]
    {
        0, // Indice do metodo aumentarVida
        1, // Indice do metodo aumentarVDA
        2, // Indice do metodo aumentarVDM
        3, // Indice do metodo aumentarIma
        4, // Indice do metodo vidaRegen
        5, // Indice do metodo aumentarDanoArmas
        6  // Indice do metodo faca
    };

    private void Start()
    {
        contAumentarVida = 0;
        contAumentarVDA = 0;
        contAumentarVDM = 0;
        contAumentarIma = 0;
        contRegenVida = 0;
        contVidaRegen = 0;
        contAumentarDanoArmas = 0;
        contFaca = 0;
    }

    public void novoPoder(){
        Time.timeScale = 0f;
        painelPoder.SetActive(true); 
    }

     public void pularPoder(){
        xpPlayer.xp += xpPlayer.xpMaximo / 4;
        gui.AlterarXp(xpPlayer.xp);
        Time.timeScale = 1f;
        painelPoder.SetActive(false); 
    }

    public void aumentarVida()
    {
        contAumentarVida++;
        vidaPlayer.vidaMaxima += 10;
        gui.AlterarVida(vidaPlayer.vidaAtual);
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
    }

    public void aumentarVDA()
    {
        contAumentarVDA++;
        disparo.intervaloDisparo -= 0.1f;
        disparo.ReiniciarRotinaDeDisparo(); // Reinicia a rotina de disparo
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
    }

    public void aumentarVDM()
    {
        contAumentarVDM++;
        movimentoPlayer.velocidade += 10;
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
    }

    public void aumentarIma()
    {
        contAumentarIma++;
        Xp.distanciaMinima += 10;
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
    }

    public void vidaRegen()
    {
        contVidaRegen++;
        vidaPlayer.regenera = true;
        vidaPlayer.taxaDeRegeneracao += 1f;
        gui.AlterarVida(vidaPlayer.vidaAtual);
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
    }

    public void aumentarDanoArmas()
    {
        contAumentarDanoArmas++;

        gerenciadorArmas.AumentarDanoArmas();
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
    }

    public void faca()
    {
        contFaca++;
        disparo.poderFaca = true;
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
    }

    public void SacoDeOuro()
    {
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        // Adicione o código para dar um saco de ouro ao jogador
        // por exemplo: player.AdicionarOuro(1);
        Debug.Log("Você recebeu um saco de ouro!");
    }

    public void AtribuirMetodosAleatorios()
    {
        List<int> metodosDisponiveis = new List<int>(metodosIndices);
        List<int> metodosAtribuidos = new List<int>();

        // Verifica se há poderes com contador menor que 5 disponíveis
        bool poderesNaoAtingidosLimite = contAumentarVida < 5 || contAumentarVDA < 5 || contAumentarVDM < 5 || contAumentarIma < 5 || contVidaRegen < 5 || contAumentarDanoArmas < 5 || contFaca < 5;

        for (int i = 0; i < botoes.Length; i++)
        {
            int metodoIndex = -1;

            // Verifica se há poderes com contador menor que 5 disponíveis e que ainda não foram atribuídos
            List<int> poderesDisponiveis = new List<int>();

            if (contAumentarVida < 5 && !metodosAtribuidos.Contains(0))
                poderesDisponiveis.Add(0);
            if (contAumentarVDA < 5 && !metodosAtribuidos.Contains(1))
                poderesDisponiveis.Add(1);
            if (contAumentarVDM < 5 && !metodosAtribuidos.Contains(2))
                poderesDisponiveis.Add(2);
            if (contAumentarIma < 5 && !metodosAtribuidos.Contains(3))
                poderesDisponiveis.Add(3);
            if (contVidaRegen < 5 && !metodosAtribuidos.Contains(4))
                poderesDisponiveis.Add(4);
            if (contAumentarDanoArmas < 5 && !metodosAtribuidos.Contains(5))
                poderesDisponiveis.Add(5);
            if (contFaca < 5 && !metodosAtribuidos.Contains(6))
                poderesDisponiveis.Add(6);

            if (poderesDisponiveis.Count > 0)
            {
                int randomIndex = Random.Range(0, poderesDisponiveis.Count);
                metodoIndex = poderesDisponiveis[randomIndex];
                metodosAtribuidos.Add(metodoIndex);
            }

            if (metodoIndex != -1)
            {
                switch (metodoIndex)
                {
                    case 0:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarVida);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Benção do Milharal"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumenta a quantidade de vida máxima que o invocador possui."; // descrição
                        botoes[i].transform.Find("statusCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "VM.N/"+contAumentarVida; // status
                        int proxNivelcontAumentarVida = contAumentarVida + 1;
                        botoes[i].transform.Find("statusCarta+").GetComponent<TMPro.TextMeshProUGUI>().text = "VM.N/+"+proxNivelcontAumentarVida; // status proximo nivel                     
                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[0]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[0]; //fundo
                        break;
                    case 1:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarVDA);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Diminui o intervalo de ataques"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "descrição"; // descrição
                        botoes[i].transform.Find("statusCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "VDA.N/"+contAumentarVDA; // status
                        int proxNivelcontAumentarVDA = contAumentarVDA + 1;
                        botoes[i].transform.Find("statusCarta+").GetComponent<TMPro.TextMeshProUGUI>().text = "VDA.N/+"+proxNivelcontAumentarVDA; // status
                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[1]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[1]; //fundo
                        break;
                    case 2:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarVDM);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "O Nascer do Milho"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Os milhos lhe concederão mais velocidade de movimento."; // descrição
                        botoes[i].transform.Find("statusCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "VDM.N/"+contAumentarVDM; // status
                        int proxNivelcontAumentarVDM = contAumentarVDM + 1;
                        botoes[i].transform.Find("statusCarta+").GetComponent<TMPro.TextMeshProUGUI>().text = "VDM.N/+"+proxNivelcontAumentarVDM; // status
                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[2]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[2]; //fundo
                        break;
                    case 3:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarIma);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "ima"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "descrição"; // descrição
                        botoes[i].transform.Find("statusCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "IMA.N/"+contAumentarIma; // status
                        int proxNivelcontAumentarIma = contAumentarIma + 1;
                        botoes[i].transform.Find("statusCarta+").GetComponent<TMPro.TextMeshProUGUI>().text = "IMA.N/+"+proxNivelcontAumentarIma; // status
                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[3]; //icone 
                        botoes[i].GetComponentInChildren<Image>().sprite = background[3]; //fundo
                        break;
                    case 4:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(vidaRegen);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Nutrição do Trigo"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumenta a quantidade de regeneração máxima que o invocador possui."; // descrição
                        botoes[i].transform.Find("statusCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "REGEN.N/"+contVidaRegen; // status
                        int proxNivelcontVidaRegen = contVidaRegen + 1;
                        botoes[i].transform.Find("statusCarta+").GetComponent<TMPro.TextMeshProUGUI>().text = "REGEN.N/+"+proxNivelcontVidaRegen; // status
                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[4]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[4]; //fundo
                        break;
                    case 5:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarDanoArmas);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumentar Dano das Armas"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "descrição"; // descrição
                        botoes[i].transform.Find("statusCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "DANO.N/"+contAumentarDanoArmas; // status
                        int proxNivelcontAumentarDanoArmas = contAumentarDanoArmas + 1;
                        botoes[i].transform.Find("statusCarta+").GetComponent<TMPro.TextMeshProUGUI>().text = "DANO.N/+"+proxNivelcontAumentarDanoArmas; // status
                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[5]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[5]; //fundo
                        break;
                    case 6:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(faca);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Faca"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "descrição"; // descrição
                        botoes[i].transform.Find("statusCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "FACA.N/"+contFaca; // status
                        int proxNivelcontFaca = contFaca + 1;
                        botoes[i].transform.Find("statusCarta+").GetComponent<TMPro.TextMeshProUGUI>().text = "FACA.N/+"+proxNivelcontFaca; // status
                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[6]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[6]; //fundo

                        break;
                    default:
                        Debug.LogError("Indice de metodo invalido!");
                        break;
                }

                metodosDisponiveis.Remove(metodoIndex);

            }
            else
            {
            // Esconder o botão quando não há mais poderes disponíveis
            botoes[i].gameObject.SetActive(false);
            }
        }
    }
    

}
