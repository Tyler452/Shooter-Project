using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;
    public int points = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            OnEnemyDied?.Invoke(points);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}