using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MyGUI gui;
    public EscolherPoder escolherPoder;
    public EscolherItem escolherItem;

    public VidaPlayer vidaPlayer;
    public XpPlayer xpPlayer;
    public MovimentoPlayer movimentoPlayer;

    public float multiplicadorXp;

    void Start()
    {
        multiplicadorXp = 1;
        vidaPlayer = GetComponent<VidaPlayer>();
        xpPlayer = GetComponent<XpPlayer>();
        movimentoPlayer = GetComponent<MovimentoPlayer>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Xp"))
        {
            if (vidaPlayer.vivo)
            {
                Xp xp = collision.gameObject.GetComponent<Xp>();

                xpPlayer.xp += xp.valorTotal * multiplicadorXp;
                gui.AlterarXp(xpPlayer.xp);

                xp.valorTotal = xp.valorInicial;
                xpPlayer.SubirNivel();
            }

        }
    }

}
