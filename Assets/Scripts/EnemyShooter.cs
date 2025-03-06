using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float fireRate = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(Shoot), fireRate, fireRate);
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * bullet.speed;
    }
}