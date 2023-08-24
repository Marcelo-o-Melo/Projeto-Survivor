using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJogo : MonoBehaviour
{
    public bool jogoPausado = false;
    public bool metodoAtivo = false;
    [SerializeField]private GameObject painelPause;
    [SerializeField]private GameObject painelGameOver;
    [SerializeField]private GameObject painelOpcoes;
    
    public GameObject player;


    public void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    void Update()
    {
        if (player == null)
        {
            gameOver();
            metodoAtivo = true;

            Xp.distanciaMinima = 3f;

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

    public void Pausar(){
        if (metodoAtivo)
        {
            Debug.Log("Pausar() nao pode ser chamado enquanto o gameOver() esta ativo.");
            return;
        }
        metodoAtivo = true;
        Time.timeScale = 0f;
        jogoPausado = true;
        painelPause.SetActive(true);
    }
    public void ContinuarJogo(){
        Time.timeScale = 1f;
        jogoPausado = false;
        painelPause.SetActive(false);
        painelOpcoes.SetActive(false);
        metodoAtivo = false;
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
    public void voltarMenu(){
        SceneManager.LoadScene(0);
        Xp.distanciaMinima = 3f;
    }
}
