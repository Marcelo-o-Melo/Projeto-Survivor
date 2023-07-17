using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJogo : MonoBehaviour
{
    private bool jogoPausado = false;
    private bool metodoAtivo = false;
    [SerializeField]private GameObject painelPause;
    [SerializeField]private GameObject painelGameOver;
    public GameObject player;
    
    void Update()
    {
        if (player == null)
        {
            gameOver();
            metodoAtivo = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogoPausado)
            {
                ContinuarJogo();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        if (metodoAtivo)
        {
            Debug.Log("Pausar() nao pode ser chamado enquanto o gameOver() esta ativo.");
            return;
        }
        Time.timeScale = 0f;  // Define o timescale como zero para pausar o jogo
        jogoPausado = true;
        painelPause.SetActive(true);
        Debug.Log("Jogo pausado");
    }
    public void ContinuarJogo()
    {
        Time.timeScale = 1f;  // Restaura o timescale para 1 para continuar o jogo
        jogoPausado = false;
        painelPause.SetActive(false);
        Debug.Log("Jogo continuado");
    }
    public void gameOver(){
        Time.timeScale = 0f;  // Define o timescale como zero para pausar o jogo
        //jogoPausado = true;
        painelGameOver.SetActive(true);     

    }
    public void novoPoder(){
        
    }
    public void bau(){
        
    }
    public void voltarMenu(){
        SceneManager.LoadScene(0);
    }
}
