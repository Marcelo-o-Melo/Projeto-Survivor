using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoProjetil : MonoBehaviour
{
 public float rotationSpeed = 200f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the shuriken around its Z-axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
