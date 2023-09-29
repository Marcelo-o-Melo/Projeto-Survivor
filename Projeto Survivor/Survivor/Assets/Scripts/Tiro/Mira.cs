using UnityEngine;

public class Mira : MonoBehaviour
{
    public Transform player; // Referência ao transform do personagem
    private SpriteRenderer arrowSprite;
    public float distanceFromPlayer = 1.5f;
    public Disparo disparo;
    private Vector2 playerPosition;

    private void Start()
    {
        arrowSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Cache da referência do jogador
        playerPosition = player.position;

        GameObject alvoMaisProximo = disparo.FindNearestEnemy();

        if (alvoMaisProximo != null && player.GetComponent<VidaPlayer>().vivo)
        {
            arrowSprite.enabled = true;
            Vector2 direction = (Vector2)alvoMaisProximo.transform.position - playerPosition;

            // Calcular o ângulo de rotação em graus
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Girar a seta para apontar para a direção do inimigo
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Calcular a posição da seta ao redor do personagem
            Vector2 arrowPosition = playerPosition + (direction.normalized * distanceFromPlayer);

            // Definir a posição da seta
            transform.position = arrowPosition;
        }
        else
        {
            // Caso não haja inimigo próximo, a mira é desativada
            arrowSprite.enabled = false;
        }
    }



}
