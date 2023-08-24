using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider sliderMusica;
    public AudioSource musica;
    public float valorSlider;

    void Start()
    {
        // Configurar o valor inicial do slider e obter o componente AudioSource
        sliderMusica.minValue = 0;
        sliderMusica.maxValue = 1;
        sliderMusica.value = valorSlider;
        
        musica = musica.GetComponent<AudioSource>();
        musica.volume = valorSlider;

        // Configurar um listener para o evento OnValueChanged do Slider
        sliderMusica.onValueChanged.AddListener(AlterarVolumeMusica);
    }

    void AlterarVolumeMusica(float novoValor)
    {
        // Atualizar o valor do volume da música quando o slider é movido
        valorSlider = novoValor;
        musica.volume = valorSlider;
    }
}
