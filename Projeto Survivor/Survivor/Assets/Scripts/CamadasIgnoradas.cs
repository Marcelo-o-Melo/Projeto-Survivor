using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamadasIgnoradas : MonoBehaviour
{
        void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 7);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6);
    }
}
