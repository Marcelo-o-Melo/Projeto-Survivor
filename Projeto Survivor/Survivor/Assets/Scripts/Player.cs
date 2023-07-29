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

    // Start is called before the first frame update
    void Start()
    {
        vidaPlayer = GetComponent<VidaPlayer>();
        xpPlayer = GetComponent<XpPlayer>();
        movimentoPlayer = GetComponent<MovimentoPlayer>();

    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Xp"))
        {
            Xp xpObject = collision.gameObject.GetComponent<Xp>();
            xpPlayer.xp += xpObject.valor;
            gui.AlterarXp(xpPlayer.xp);
            xpPlayer.SubirNivel();
        }
    }

}
