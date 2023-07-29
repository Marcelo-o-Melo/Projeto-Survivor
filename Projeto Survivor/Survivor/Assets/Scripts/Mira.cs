using UnityEngine;

public class Mira : MonoBehaviour
{
    public Transform player; // Referência ao transform do personagem
    private SpriteRenderer arrowSprite;
    public float distanceFromPlayer = 1.5f;
    public Disparo disparo;

    private void Start()
    {
        arrowSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GameObject alvoMaisProximo = disparo.FindNearestEnemy();

        if (alvoMaisProximo != null)
        {
            Vector2 direction = (Vector2)alvoMaisProximo.transform.position - (Vector2)player.position;

            // Calcular o ângulo de rotação em graus
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Girar a seta para apontar para a direção do inimigo
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Calcular a posição da seta ao redor do personagem
            Vector2 arrowPosition = (Vector2)player.position + (direction.normalized * distanceFromPlayer);

            // Definir a posição da seta
            transform.position = arrowPosition;
        }
        else
        {
            // Caso não haja inimigo próximo, a mira ficará parada junto ao personagem
            transform.position = player.position;
        }
    }



}
