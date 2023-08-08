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
            if (Input.GetButtonDown("Submit"))
            {
                usos--;
                escolherItem.MatarInimigosProximos();
            }
        }

    }
}
