using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraXp : MonoBehaviour
{
    public Slider slider;

  public void AlterarXp(int xp) {
    slider.value = xp;

  }
}
