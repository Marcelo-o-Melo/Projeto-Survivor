using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisao : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        // Ação a ser realizada quando ocorrer uma colisão
        Debug.Log("Colisão detectada com: " + collider.name);
    }
}
