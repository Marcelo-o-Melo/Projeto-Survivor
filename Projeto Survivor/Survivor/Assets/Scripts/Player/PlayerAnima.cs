using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnima : MonoBehaviour
{
    private bool face = true;
    private Transform playerT;
    private MovimentoPlayer movPlayer;
    private VidaPlayer vidaPlayer;
    private Animator animator;
    public bool animMorte;

    void Start()
    {
        playerT = GetComponent<Transform>();
        movPlayer = GetComponent<MovimentoPlayer>();
        vidaPlayer = GetComponent<VidaPlayer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (movPlayer.movHori == 0)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Mover", false);
            
        }

        if (movPlayer.movHori > 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Mover", true);

            if (!face)
            {
                Flip();
            }
            
            
        }
        if (movPlayer.movHori < 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Mover", true);

            if (face)
            {
                Flip();
            }
        }
        if (movPlayer.movVert < 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Mover", true);
        }
        if (movPlayer.movVert > 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Mover", true);
        }
        if (!vidaPlayer.vivo)
        {
            animator.SetBool("Mover", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Morto", true);
        }
        
        
    }

    void Flip()
    {
        face = !face;

        Vector3 escala = playerT.localScale;

        escala.x *= -1;
        playerT.localScale = escala;
    }
}
