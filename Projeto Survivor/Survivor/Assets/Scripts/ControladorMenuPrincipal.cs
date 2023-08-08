using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControladorMenuPrincipal : MonoBehaviour
{
    [SerializeField]private GameObject menuOpcoes;
    [SerializeField]private GameObject menuPrincipal;
        
    public void jogar(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        MyGUI.tempoDecorrido = 0f;
        MyGUI.contadorMortes = 0;
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
        Application.Quit();
    }
}
