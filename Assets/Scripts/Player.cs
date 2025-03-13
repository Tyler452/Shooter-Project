using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Bullets bulletPrefab;
    private bool _bulletActive;
    private Animator _animator;
    private AudioSource _audioSource;
    public AudioClip shootSound;
    public AudioClip explodeSound;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * (speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!_bulletActive)
        {
            _animator.SetTrigger("Shoot");
            _audioSource.PlayOneShot(shootSound);
            Bullets bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * bullet.speed;
            _bulletActive = true;

            bullet.Destroyed += () => _bulletActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    public void Die()
    {
        _animator.SetTrigger("Explode");
        _audioSource.PlayOneShot(explodeSound);
        Destroy(gameObject, 0.5f); 
        GameSceneManager.LoadCredits(); 
    }
}