using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Bullet bulletPrefab;
    private bool _bulletActive;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.position += Vector3.left * (speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.position += Vector3.right * (speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) Shoot();
    }

    private void Shoot()
    {
        if (_bulletActive) return;

        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * bullet.speed;
        bullet.OnBulletDestroyed += () => _bulletActive = false;
        _bulletActive = true;
    }
}