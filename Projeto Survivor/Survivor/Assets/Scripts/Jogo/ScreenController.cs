using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
    public TMP_Dropdown dropdownResolucao;
    public Toggle toggleTela;
    private bool telaCheia;

    void Update()
    {
        SetarResolu();
        SetarTelaCheia();
    }

    void SetarResolu()
    {
        dropdownResolucao.value = PlayerPrefs.GetInt("Resolucao");
    }
    void SetarTelaCheia()
    {
        switch (PlayerPrefs.GetString("TelaCheia"))
        {
            case "":
                telaCheia = true;
                toggleTela.isOn = true;
                MudarValorDDResolu();
                break;
            case "true":
                telaCheia = true;
                toggleTela.isOn = true;
                MudarValorDDResolu();
                break;
            case "false":
                telaCheia = false;
                toggleTela.isOn = false;
                MudarValorDDResolu();
                break;
        }
    }
    public void MudarValorToggle()
    {
        switch (toggleTela.isOn)
        {
            case true:
                PlayerPrefs.SetString("TelaCheia", "true");

                break;
            case false:
                PlayerPrefs.SetString("TelaCheia", "false");

                break;
        }
    }
    public void MudarValorDDResolu()
    {
        switch (dropdownResolucao.value)
        {
            case 0:
                PlayerPrefs.SetInt("Resolucao", 0);

                Screen.SetResolution(1366, 768, telaCheia);

                break;
            case 1:
                PlayerPrefs.SetInt("Resolucao", 1);

                Screen.SetResolution(1920, 1080, telaCheia);

                break;
            case 2:
                PlayerPrefs.SetInt("Resolucao", 2);

                Screen.SetResolution(2560, 1440, telaCheia);

                break;
            case 3:
                PlayerPrefs.SetInt("Resolucao", 3);

                Screen.SetResolution(3840, 2160, telaCheia);

                break;
        }
    }
}
