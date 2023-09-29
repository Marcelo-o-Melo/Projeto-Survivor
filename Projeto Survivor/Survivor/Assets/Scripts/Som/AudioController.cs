using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    private GameObject sliderMusica;
    private GameObject sliderSom;

    //musicas
    public AudioSource musicaMenu;
    public AudioSource musicaGame;
    //SFX
    public AudioSource hitMobSFX;
    public AudioSource bauSFX;
    public AudioSource morteSFX;
    public AudioSource explosaoSFX;
    public AudioSource xpSFX;
    public AudioSource disparoSFX;
    public AudioSource botaoSFX;
    public AudioSource levelUpSFX;
    public AudioSource superImaSFX;
    public AudioSource frangoSFX;
    public AudioSource escudoSFX;
    public AudioSource hitPlayerSFX;
    public AudioSource morteInimigoSFX;
    public AudioSource dashSFX;

    private static AudioController AudioInstance = null;
    public static AudioController Instance
    {
        get { return AudioInstance; }
    }
    void Awake()
    {
        if (AudioInstance != null && AudioInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            AudioInstance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        //musica
        musicaMenu.volume = PlayerPrefs.GetFloat("Music");
        musicaGame.volume = PlayerPrefs.GetFloat("Music");
        //SFX
        hitMobSFX.volume = PlayerPrefs.GetFloat("Som");
        bauSFX.volume = PlayerPrefs.GetFloat("Som");
        morteSFX.volume = PlayerPrefs.GetFloat("Som");
        explosaoSFX.volume = PlayerPrefs.GetFloat("Som");
        xpSFX.volume = PlayerPrefs.GetFloat("Som");
        disparoSFX.volume = PlayerPrefs.GetFloat("Som");
        botaoSFX.volume = PlayerPrefs.GetFloat("Som");
        levelUpSFX.volume = PlayerPrefs.GetFloat("Som");
        superImaSFX.volume = PlayerPrefs.GetFloat("Som");
        frangoSFX.volume = PlayerPrefs.GetFloat("Som");
        escudoSFX.volume = PlayerPrefs.GetFloat("Som");
        hitPlayerSFX.volume = PlayerPrefs.GetFloat("Som");
        morteInimigoSFX.volume = PlayerPrefs.GetFloat("Som");
        dashSFX.volume = PlayerPrefs.GetFloat("Som");
    }
    private void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "MenuPrincipal":
                musicaMenu.gameObject.SetActive(true);
                musicaGame.gameObject.SetActive(false);
                break;
            case "Jogo":
                musicaMenu.gameObject.SetActive(false);
                musicaGame.gameObject.SetActive(true);
                break;
        }
        sliderMusica = GameObject.FindGameObjectWithTag("SliderMusica");
        sliderSom = GameObject.FindGameObjectWithTag("SliderSom");

        if (sliderMusica)
        {
            sliderMusica.GetComponent<Slider>().minValue = 0;
            sliderMusica.GetComponent<Slider>().maxValue = 1;
            sliderMusica.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Music");
            sliderMusica.GetComponent<Slider>().onValueChanged.AddListener(AlterarVolumeMusica);
        }
        if (sliderSom)
        {
            sliderSom.GetComponent<Slider>().minValue = 0;
            sliderSom.GetComponent<Slider>().maxValue = 1;
            sliderSom.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Som");
            sliderSom.GetComponent<Slider>().onValueChanged.AddListener(AlterarVolumeSom);
        }
    }
    void AlterarVolumeMusica(float novoValor)
    {
        // Atualizar o valor do volume da música quando o slider é movido
        PlayerPrefs.SetFloat("Music", novoValor);
        musicaMenu.volume = novoValor;
        musicaGame.volume = novoValor;
    }
    void AlterarVolumeSom(float novoValor)
    {
        // Atualizar o valor do volume do som quando o slider é movido
        PlayerPrefs.SetFloat("Som", novoValor);
        hitMobSFX.volume = novoValor;
        bauSFX.volume = novoValor;
        morteSFX.volume = novoValor;
        explosaoSFX.volume = novoValor;
        xpSFX.volume = novoValor;
        disparoSFX.volume = novoValor;
        botaoSFX.volume = novoValor;
        levelUpSFX.volume = novoValor;
        superImaSFX.volume = novoValor;
        frangoSFX.volume = novoValor;
        escudoSFX.volume = novoValor;
        hitPlayerSFX.volume = novoValor;
        morteInimigoSFX.volume = novoValor;
        dashSFX.volume = novoValor;
    }
}
