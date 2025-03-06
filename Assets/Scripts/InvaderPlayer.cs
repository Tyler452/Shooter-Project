using UnityEngine;

public class InvaderPlayer : MonoBehaviour
{
    public float speed = 5.0f;
    public Bullets bulletPrefab;
    private bool _bulletActive;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * (this.speed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * (this.speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        void Shoot()
        {
            if (!_bulletActive)
            {
                Bullets bullet = Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);
                bullet.Destroyed += BulletDestroyed;
                _bulletActive = true;
            }

            void BulletDestroyed()
            {
                _bulletActive = false;
            }
        }
        
    }
}
