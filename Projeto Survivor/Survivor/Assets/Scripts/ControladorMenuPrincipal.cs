using UnityEngine;
using UnityEngine.SceneManagement;


public class ControladorMenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject menuOpcoes;
    [SerializeField] private GameObject menuPrincipal;

    public void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void Jogar()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0f;
        MyGUI.tempoDecorrido = 0f;
        MyGUI.contadorMortes = 0;

    }
    public void AbrirOpcoes()
    {
        //menuPrincipal.SetActive(false);
        menuOpcoes.SetActive(true);
    }
    public void BtnVoltar()
    {
        //menuPrincipal.SetActive(true);
        menuOpcoes.SetActive(false);
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
