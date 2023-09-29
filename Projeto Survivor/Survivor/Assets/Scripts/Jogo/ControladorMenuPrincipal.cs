using UnityEngine;
using UnityEngine.SceneManagement;


public class ControladorMenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject menuOpcoes;
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject creditos;
    [SerializeField] private GameObject creditosText;
    [SerializeField] private GameObject popUpCache;


    private void Update()
    {
        SubirCreditos();
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
        creditos.SetActive(false);
        menuOpcoes.SetActive(false);
    }

    public void SairJogo()
    {
        Application.Quit();
    }
    public void AbrirCreditos()
    {
        creditos.SetActive(true);
        creditosText.transform.position = new Vector2(creditosText.transform.position.x, 300);
    }

    public void SubirCreditos()
    {
        creditosText.transform.position += Vector3.up;
    }
    public void FecharPopUpCache()
    {
        popUpCache.SetActive(false);
    }
    public void PopUpCache()
    {
        popUpCache.SetActive(true);
    }
    public void limparCache()
    {
        popUpCache.SetActive(false);
        PlayerPrefs.DeleteAll();
    }
}
