using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenuPrincipal : MonoBehaviour
{
    
    public void jogar(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void sairJogo(){
        Debug.Log("saimento");
        Application.Quit();
    }
}
