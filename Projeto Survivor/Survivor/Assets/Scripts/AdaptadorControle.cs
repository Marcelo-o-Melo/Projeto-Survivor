using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdaptadorControle : MonoBehaviour
{
    public Button[] buttons;
    private int selectedIndex = 0;

    private void Start()
    {
        HighlightButton(selectedIndex);
    }

    private void Update()
    {
        // Lógica para navegar pelos botões usando as setas do controle
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveSelection(-1); // Move para cima
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveSelection(1); // Move para baixo
        }

        // Captura da seleção do botão
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            PressButton(selectedIndex); // Realiza a ação associada ao botão selecionado
        }
    }

    private void MoveSelection(int direction)
    {
        HighlightButton(selectedIndex, false); // Remove o destaque do botão atualmente selecionado

        selectedIndex = (selectedIndex + direction + buttons.Length) % buttons.Length; // Move para o próximo botão disponível na direção especificada

        HighlightButton(selectedIndex); // Destaca visualmente o novo botão selecionado
    }

    private void HighlightButton(int index, bool highlight = true)
    {
        // Implemente a lógica de realce visual do botão conforme desejado
        // Aqui, você pode mudar a cor do botão, exibir um indicador, etc.
        // Por exemplo, se for usar cores, pode ser algo assim:
        if (highlight)
            buttons[index].image.color = Color.yellow;
        else
            buttons[index].image.color = Color.white;
    }

    private void PressButton(int index)
    {
        buttons[index].onClick.Invoke(); // Implemente a ação que o botão realizará quando pressionado
    }
}
