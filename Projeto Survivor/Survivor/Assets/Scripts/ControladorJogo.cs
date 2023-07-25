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
    [SerializeField]private GameObject painelOpcoes;
    [SerializeField]private GameObject painelPoder;
    
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

        Time.timeScale = 0f;
        jogoPausado = true;
        painelPause.SetActive(true);
    }
    public void ContinuarJogo()
    {
        Time.timeScale = 1f;
        jogoPausado = false;
        painelPause.SetActive(false);
        painelOpcoes.SetActive(false);
    }
    public void gameOver(){
        Time.timeScale = 0f;
        painelGameOver.SetActive(true);     
    }
    public void abrirOpcoes(){
        painelOpcoes.SetActive(true);   
    }
    public void fecharOpcoes(){
        painelOpcoes.SetActive(false);
    }
    public void novoPoder(){
        Time.timeScale = 0f;
        painelPoder.SetActive(true); 
    }
     public void pularPoder(){
        Time.timeScale = 1f;
        painelPoder.SetActive(false); 
    }
    public void bau(){
        
    }
    public void voltarMenu(){
        SceneManager.LoadScene(0);
    }
}
