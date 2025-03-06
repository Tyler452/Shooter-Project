using UnityEngine;

public class Barricade : MonoBehaviour
{
    public int health = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            Destroy(collision.gameObject); // Destroy the bullet

            if (health <= 0)
            {
                Destroy(gameObject); // Destroy the barricade
            }
            else
            {
                transform.localScale *= 0.8f; // Shrink the barricade
            }
        }
    }
}