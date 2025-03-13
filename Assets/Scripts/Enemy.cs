using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;

    public int points = 10;
    private Animator _animator;
    private AudioSource _audioSource;
    public AudioClip explodeSound;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _animator.SetTrigger("Explode");
            _audioSource.PlayOneShot(explodeSound);
            OnEnemyDied?.Invoke(points);
            Destroy(collision.gameObject);
            Destroy(gameObject, 0.5f);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Die(); 
        }
    }
}