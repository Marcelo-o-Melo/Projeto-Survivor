using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EscolherPoder : MonoBehaviour
{
    [SerializeField] private GameObject painelPoder;
    public ControladorJogo controladorJogo;
    public Player player;
    public Disparo disparo;
    public MyGUI gui;
    public GameObject escudoPoder;

    public VidaPlayer vidaPlayer;
    public XpPlayer xpPlayer;
    public MovimentoPlayer movimentoPlayer;

    public int contAumentarVida;
    public int contAumentarVDA;
    public int contAumentarVDM;
    public int contAumentarIma;
    public int contVidaRegen;
    public int contAumentarDanoArmas;
    public int contFaca;
    public int contOrbes;
    public int contEscudo;
    public int contArea;
    public int contDanoArea;
    public int contVelocidadeProjetil;

    public Button[] botoes;
    public Texture[] icones;
    public Sprite[] background;

    public RawImage[] holders;
    public TextMeshProUGUI[] texts;

    public float TamanhoArea;
    public float TamanhoAreaDano;

    public static float multiplicador;
    public static float multiplicadorVelocidadeProjetil;

    private int[] metodosIndices = new int[]
    {
        0, // Indice do metodo aumentarVida
        1, // Indice do metodo aumentarVDA
        2, // Indice do metodo aumentarVDM
        3, // Indice do metodo aumentarIma
        4, // Indice do metodo vidaRegen
        5, // Indice do metodo aumentarDanoArmas
        6, // Indice do metodo faca
        7, // Indice do metodo orbes
        8, // Indice do metodo escudo
        9, // Indice do metodo aumentar a area
        10,// Indice do metodo danoArea
        11 // indice do metodo velocidadeProjetil
    };




    private void Start()
    {
        for (int i = 0; i <= 11; i++)
        {
            holders[i].texture = icones[i];
        }
        TamanhoArea = 5f;
        TamanhoAreaDano = 10f;
        multiplicador = 1f;
        multiplicadorVelocidadeProjetil = 200f;

        contAumentarVida = 0;
        contAumentarVDA = 0;
        contAumentarVDM = 0;
        contAumentarIma = 0;
        contVidaRegen = 0;
        contAumentarDanoArmas = 0;
        contFaca = 0;
        contOrbes = 0;
        contEscudo = 0;
        contArea = 0;
        contDanoArea = 0;
        contVelocidadeProjetil = 0;

    }

    public void novoPoder()
    {
        Time.timeScale = 0f;
        AtribuirMetodosAleatorios();

        painelPoder.SetActive(true);
        controladorJogo.metodoAtivo = true;
    }

    public void pularPoder()
    {
        xpPlayer.xp *= 1.25f;
        gui.AlterarXp(xpPlayer.xp);

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void aumentarVida()
    {
        holders[0].gameObject.SetActive(true);


        contAumentarVida++;
        texts[0].text = contAumentarVida.ToString();
        vidaPlayer.vidaMaxima *= 1.40f;
        gui.AlterarVida(vidaPlayer.vidaAtual);

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void aumentarVDA()
    {
        holders[1].gameObject.SetActive(true);


        contAumentarVDA++;
        texts[1].text = contAumentarVDA.ToString();
        disparo.intervaloDisparo -= 0.2f;
        disparo.ReiniciarRotinaDeDisparo(); // Reinicia a rotina de disparo

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void aumentarVDM()
    {
        holders[2].gameObject.SetActive(true);


        contAumentarVDM++;
        texts[2].text = contAumentarVDM.ToString();
        movimentoPlayer.velocidade *= 1.30f;

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void aumentarIma()
    {
        holders[3].gameObject.SetActive(true);


        contAumentarIma++;
        texts[3].text = contAumentarIma.ToString();
        Xp.distanciaMinima += 10;

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void vidaRegen()
    {
        holders[4].gameObject.SetActive(true);


        contVidaRegen++;
        texts[4].text = contVidaRegen.ToString();
        vidaPlayer.regenera = true;
        vidaPlayer.taxaDeRegeneracao += vidaPlayer.vidaAtual * 0.2f;
        gui.AlterarVida(vidaPlayer.vidaAtual);

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void aumentarDanoArmas()
    {
        holders[5].gameObject.SetActive(true);


        contAumentarDanoArmas++;
        texts[5].text = contAumentarDanoArmas.ToString();
        multiplicador *= 1.5f; //aumenta em 50%

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void faca()
    {
        holders[6].gameObject.SetActive(true);


        contFaca++;
        texts[6].text = contFaca.ToString();
        disparo.poderFaca = true;

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void orbes()
    {
        holders[7].gameObject.SetActive(true);


        contOrbes++;
        texts[7].text = contOrbes.ToString();
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void escudo()
    {
        holders[8].gameObject.SetActive(true);

        contEscudo++;
        texts[8].text = contEscudo.ToString();

        escudoPoder.SetActive(true);
        vidaPlayer.escudoAtivoPoder = true;
        vidaPlayer.escudoPoderMaximo *= 1.30f;
        vidaPlayer.taxaDeRegeneracaoEscudo += vidaPlayer.escudoPoderMaximo * 0.01f;
        gui.AlterarEscudoPoder(vidaPlayer.escudoPoder);

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void area()
    {
        holders[9].gameObject.SetActive(true);


        contArea++;
        texts[9].text = contArea.ToString();
        TamanhoArea *= 1.1f;

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void danoArea()
    {
        holders[10].gameObject.SetActive(true);


        contDanoArea++;
        texts[10].text = contDanoArea.ToString();
        TamanhoAreaDano *= 1.1f;

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void velocidadeProjetil()
    {
        holders[11].gameObject.SetActive(true);

        contVelocidadeProjetil++;
        texts[11].text = contVelocidadeProjetil.ToString();

        multiplicadorVelocidadeProjetil *= 1.3f; //aumenta em 30%

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        AudioController.Instance.botaoSFX.Play();
    }

    public void SacoDeOuro()
    {

        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        controladorJogo.metodoAtivo = false;
        // Adicione o código para dar um saco de ouro ao jogador
        // por exemplo: player.AdicionarOuro(1);
        // Debug.Log("Você recebeu um saco de ouro!");
    }
    public bool VerificarHabilidadesDisponiveis()
    {
        // Verifica se há alguma habilidade disponível para o jogador escolher
        return contAumentarVida < 5 ||
                contAumentarVDA < 8 ||
                contAumentarVDM < 5 ||
                contAumentarIma < 5 ||
                contVidaRegen < 5 ||
                contAumentarDanoArmas < 5 ||
                contFaca < 5 ||
                contOrbes < 8 ||
                contArea < 5 ||
                contEscudo < 5 ||
                contDanoArea < 5 ||
                contVelocidadeProjetil < 5;
    }
    public void AtribuirMetodosAleatorios()
    {
        List<int> metodosDisponiveis = new List<int>(metodosIndices);
        List<int> metodosAtribuidos = new List<int>();

        for (int i = 0; i < botoes.Length; i++)
        {
            int metodoIndex = -1;

            // Verifica se há poderes com contador menor que 5 disponíveis e que ainda não foram atribuídos
            List<int> poderesDisponiveis = new List<int>();

            if (contAumentarVida < 5 && !metodosAtribuidos.Contains(0)) poderesDisponiveis.Add(0);
            if (contAumentarVDA < 8 && !metodosAtribuidos.Contains(1)) poderesDisponiveis.Add(1);
            if (contAumentarVDM < 5 && !metodosAtribuidos.Contains(2)) poderesDisponiveis.Add(2);
            if (contAumentarIma < 5 && !metodosAtribuidos.Contains(3)) poderesDisponiveis.Add(3);
            if (contVidaRegen < 5 && !metodosAtribuidos.Contains(4)) poderesDisponiveis.Add(4);
            if (contAumentarDanoArmas < 5 && !metodosAtribuidos.Contains(5)) poderesDisponiveis.Add(5);
            if (contFaca < 5 && !metodosAtribuidos.Contains(6)) poderesDisponiveis.Add(6);
            if (contOrbes < 8 && !metodosAtribuidos.Contains(7)) poderesDisponiveis.Add(7);
            if (contEscudo < 5 && !metodosAtribuidos.Contains(8)) poderesDisponiveis.Add(8);
            if (contArea < 5 && !metodosAtribuidos.Contains(9)) poderesDisponiveis.Add(9);
            if (contDanoArea < 5 && !metodosAtribuidos.Contains(10)) poderesDisponiveis.Add(10);
            if (contVelocidadeProjetil < 5 && !metodosAtribuidos.Contains(11)) poderesDisponiveis.Add(11);

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
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumentar Vida"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumenta a quantidade de vida máxima que o jogador possui."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[0]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[0]; //fundo


                        break;
                    case 1:

                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarVDA);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Velocidade de Ataque"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumenta a velocidade de ataque do jogador."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[1]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[1]; //fundo


                        break;
                    case 2:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarVDM);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Velocidade de Movimento"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumenta a velocidade de movimento do jogador."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[2]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[2]; //fundo


                        break;
                    case 3:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarIma);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Magnetismo"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Atrai o xp de maiores distâncias."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[3]; //icone 
                        botoes[i].GetComponentInChildren<Image>().sprite = background[3]; //fundo


                        break;
                    case 4:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(vidaRegen);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Regenerar Vida"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "O jogador regenera vida."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[4]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[4]; //fundo

                        break;
                    case 5:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarDanoArmas);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumentar Dano"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumenta o dano causado pelo jogador."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[5]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[5]; //fundo


                        break;
                    case 6:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(faca);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Faca"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Faca."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[6]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[6]; //fundo


                        break;
                    case 7:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(orbes);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Orbes Orbitais"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Orbes que oribitam o jogador."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[7]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[7]; //fundo


                        break;
                    case 8:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(escudo);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Escudo"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Escudo que absorve o dano recebido pelo jogador, regenera lentamente."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[8]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[8]; //fundo


                        break;
                    case 9:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(area);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumento de Área"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumenta a área dos poderes de dano baseados em área."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[9]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[9]; //fundo


                        break;
                    case 10:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(danoArea);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Dano em Área"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Uma área ao redor do player que causa dano."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[10]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[10]; //fundo


                        break;
                    case 11:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(velocidadeProjetil);
                        botoes[i].transform.Find("tituloCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Velocidade de Projétil"; // titulo
                        botoes[i].transform.Find("textoCarta").GetComponent<TMPro.TextMeshProUGUI>().text = "Aumenta a velocidade na qual os projéteis se locomovem."; // descrição

                        botoes[i].GetComponentInChildren<RawImage>().texture = icones[11]; //icone
                        botoes[i].GetComponentInChildren<Image>().sprite = background[11]; //fundo


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
