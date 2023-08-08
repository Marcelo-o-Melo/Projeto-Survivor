using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private int quantidadeObjetos;

    [SerializeField] private GameObject objetos;

    private List<GameObject> poolingObjects;   

    private void Start()
    {
        poolingObjects = new List<GameObject>();

        GameObject objetoTemp;

        for(int i = 0; i< quantidadeObjetos; i++){
            objetoTemp = Instantiate(objetos);
            objetoTemp.transform.SetParent(this.transform);
            objetoTemp.SetActive(false);
            poolingObjects.Add(objetoTemp);
        }
    }

    public GameObject GetObjetos()
    {
        for(int i = 0; i< poolingObjects.Count; i++)
        {
            if(!poolingObjects[i].activeInHierarchy)
            {
                return poolingObjects[i];
            }
        }
        return null;
    }

}
