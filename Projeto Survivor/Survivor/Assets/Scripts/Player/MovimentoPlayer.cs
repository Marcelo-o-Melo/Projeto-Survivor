using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MovimentoPlayer : MonoBehaviour
{
    public float velocidade;
    public float movHori;
    public float movVert;

    private float dashingPower = 10000;
    private float dashingTime;
    private float dashCooldown;

    Vector2 deslocamento;

    public bool canDash = true;
    public bool isDashing;

    private VidaPlayer player;
    Rigidbody2D rb;

    private void Start()
    {
        dashingTime = 0.2f;
        dashCooldown = 0.2f;
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<VidaPlayer>();
    }

    private void Update()
    {
        GetInput();
    }
    public void GetInput()
    {
        if (player.vivo)
        {
            movHori = Input.GetAxis("Horizontal");
            movVert = Input.GetAxis("Vertical");
        }

        if (!player.vivo)
        {
            movHori = 0;
            movVert = 0;
        }

        deslocamento = new Vector2(movHori, movVert);
    }
    void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        rb.velocity = deslocamento * velocidade * Time.fixedDeltaTime;
    }

    public void PoderDash()
    {
        StartCoroutine(AtivarDash());
    }
    private IEnumerator AtivarDash()
    {
        AudioController.Instance.dashSFX.Play();
        canDash = false;
        isDashing = true;
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6, true); // inimigo
        player.GetComponent<MovimentoPlayer>().velocidade += dashingPower;
        yield return new WaitForSeconds(dashingTime);
        Physics2D.IgnoreLayerCollision(gameObject.layer, 6, false); // inimigo
        player.GetComponent<MovimentoPlayer>().velocidade -= dashingPower;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
 
    }
}
