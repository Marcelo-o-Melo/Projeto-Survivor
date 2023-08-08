using System.Collections;
using UnityEngine;

public class RotacaoProjetil : MonoBehaviour
{
    public float rotationSpeed = 200f;

    private Rigidbody2D rb2D;

    private void Awake()
    {
        // Cache the Rigidbody2D component
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Start the coroutine for rotation
        rb2D.angularVelocity = rotationSpeed;
    }

}
