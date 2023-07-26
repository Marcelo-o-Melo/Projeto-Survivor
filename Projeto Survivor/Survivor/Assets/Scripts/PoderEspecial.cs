using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderEspecial : MonoBehaviour
{
    public EscolherItem escolherItem;
    public GameObject poder;
    public int usos;
    
    void Update(){
        if(usos > 0){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                usos--;
                escolherItem.MatarInimigosProximos();
                Debug.Log("Usos restantes: " + usos);
            }
        }
        else{
            Debug.Log("acabou a nuke sexual");
        }

    }
}
