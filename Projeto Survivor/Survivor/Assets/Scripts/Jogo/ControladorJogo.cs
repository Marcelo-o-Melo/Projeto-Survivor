using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ControladorJogo : MonoBehaviour
{
    public bool jogoPausado = false;
    public bool metodoAtivo = false;
    [SerializeField]private GameObject painelPause;
    [SerializeField]private GameObject painelGameOver;
    [SerializeField]private GameObject painelOpcoes;
    [SerializeField]private GameObject playerInfo;

    public GameObject player;

    private VidaPlayer vidaPlayer;

    public void Start()
    {
        vidaPlayer = player.GetComponent<VidaPlayer>();
    }
    void Update()
    {
        
        if (!vidaPlayer.vivo)
        {
            AudioController.Instance.morteSFX.gameObject.SetActive(true);
            StartCoroutine(EsperarTerminoAnimacao());
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
    IEnumerator EsperarTerminoAnimacao()
    {
        yield return new WaitForSeconds(1f);
        gameOver();
        metodoAtivo = true;

        Xp.distanciaMinima = 3f;
    }

    public void Pausar(){
        if (metodoAtivo)
        {
            Debug.Log("Pausar() nao pode ser chamado enquanto o gameOver() esta ativo.");
            return;
        }
        playerInfo.SetActive(true);
        metodoAtivo = true;
        Time.timeScale = 0f;
        jogoPausado = true;
        painelPause.SetActive(true);
    }
    public void ContinuarJogo(){
        playerInfo.SetActive(false);
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
