using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenuPrincipal : MonoBehaviour
{
    [SerializeField]private GameObject menuOpcoes;
    [SerializeField]private GameObject menuPrincipal;
    
    public void jogar(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void abrirOpcoes(){
        menuPrincipal.SetActive(false);
        menuOpcoes.SetActive(true);   
    }
    public void btnVoltar(){
        menuPrincipal.SetActive(true);
        menuOpcoes.SetActive(false);   
    }
    public void sairJogo(){
        Debug.Log("saimento");
        Application.Quit();
    }
}
