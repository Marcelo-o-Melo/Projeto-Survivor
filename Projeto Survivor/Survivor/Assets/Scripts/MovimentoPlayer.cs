using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    public FixedJoystick joystick;
    public float velocidade;
    public float movHori;
    public float movVert;

    void Update()
    {
        movHori = joystick.Horizontal;
        movVert = joystick.Vertical;

        Vector2 deslocamento = new Vector2(movHori, movVert) * velocidade * Time.deltaTime;

        transform.Translate(deslocamento);
    }
}
