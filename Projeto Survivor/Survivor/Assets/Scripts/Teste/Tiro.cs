using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public Pool poolProjetil;
    // Update is called once per frame
    void Update()
    {
        Atirar();
    }
    private void Atirar(){
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject projetil = poolProjetil.GetObjetos();

            if(projetil != null){
                projetil.SetActive(true);
            }
        }
    }
}
