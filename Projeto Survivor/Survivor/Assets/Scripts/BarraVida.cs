using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
  public Slider slider;

  public void AlterarVida(int vida) {
    slider.value = vida;

  }
}
