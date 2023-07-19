using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscolherPoder : MonoBehaviour
{
    [SerializeField] private GameObject painelPoder;
    public Player player;
    public MyGUI gui;
    public Xp xp;
    public Button[] botoes;
    public int contAumentarVida;
    public int contAumentarVDA;
    public int contAumentarVDM;
    public int contAumentarIma;
    public int contRegenVida;
    public int contVidaRegen;

    private int[] metodosIndices = new int[]
    {
        0, // Indice do metodo aumentarVida
        1, // Indice do metodo aumentarVDA
        2, // Indice do metodo aumentarVDM
        3, // Indice do metodo aumentarIma
        4 // Indice do metodo vidaRegen
    };

    private void Start()
    {
        contAumentarVida = 0;
        contAumentarVDA = 0;
        contAumentarVDM = 0;
        contAumentarIma = 0;
        contRegenVida = 0;
        contVidaRegen = 0;
        AtribuirMetodosAleatorios();
    }

    public void aumentarVida()
    {
        contAumentarVida++;
        player.vidaMaxima += 10;
        gui.AlterarVida(player.vidaAtual);
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
    }

    public void aumentarVDA()
    {
        contAumentarVDA++;
        player.intervaloDisparo -= 0.1f;
        player.ReiniciarRotinaDeDisparo(); // Reinicia a rotina de disparo
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
    }

    public void aumentarVDM()
    {
        contAumentarVDM++;
        player.velocidade += 10;
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
        player.regenera = true;
        player.taxaDeRegeneracao +=1f;
        gui.AlterarVida(player.vidaAtual);
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
    }

    public void SacoDeOuro()
    {
        Time.timeScale = 1f;
        painelPoder.SetActive(false);
        // Adicione o codigo para dar um saco de ouro ao jogador
        // por exemplo: player.AdicionarOuro(1);
        Debug.Log("Voce recebeu um saco de ouro!");
    }

    private void AtribuirMetodosAleatorios()
    {
        List<int> metodosDisponiveis = new List<int>(metodosIndices);
        List<int> metodosAtribuidos = new List<int>();

        // Verifica se ha poderes com contador menor que 5 disponiveis
        bool poderesNaoAtingidosLimite = contAumentarVida < 5 || contAumentarVDA < 5 || contAumentarVDM < 5 || contAumentarIma < 5 || contVidaRegen < 5;

        for (int i = 0; i < botoes.Length; i++)
        {
            int metodoIndex = -1;

            // Verifica se ha poderes com contador menor que 5 disponiveis e que ainda nao foram atribuidos
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
                        botoes[i].GetComponentInChildren<Text>().text = "Aumentar Vida";
                        break;
                    case 1:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarVDA);
                        botoes[i].GetComponentInChildren<Text>().text = "Diminui o intervalo de ataques";
                        break;
                    case 2:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarVDM);
                        botoes[i].GetComponentInChildren<Text>().text = "Aumentar velocidade de movimento";
                        break;
                    case 3:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(aumentarIma);
                        botoes[i].GetComponentInChildren<Text>().text = "Aumentar Area do Ima";
                        break;
                    case 4:
                        botoes[i].onClick.RemoveAllListeners();
                        botoes[i].onClick.AddListener(vidaRegen);
                        botoes[i].GetComponentInChildren<Text>().text = "Regeneracao de vida";
                        break;
                    default:
                        Debug.LogError("Indice de metodo invalido!");
                        break;
                }

                metodosDisponiveis.Remove(metodoIndex);
            }
            else
            {
                // Atribui o metodo SacoDeOuro ao botao sem poder disponivel
                botoes[i].onClick.RemoveAllListeners();
                botoes[i].onClick.AddListener(SacoDeOuro);
                botoes[i].GetComponentInChildren<Text>().text = "saco de ouro!";
            }
        }
    }

    public void OnPlayerLevelUp()
    {
        AtribuirMetodosAleatorios();
    }
}
