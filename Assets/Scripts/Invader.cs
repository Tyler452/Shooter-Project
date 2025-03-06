using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] sprites;
    public float animationTime = 1f;
    private SpriteRenderer spriteRenderer;
    private int animationFrame;
    public System.Action killed;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating("ChangeSprite", this.animationTime, this.animationTime);
    }

    private void ChangeSprite()
    {
        animationFrame++;

        if (animationFrame >= this.sprites.Length)
        {
            animationFrame = 0;
        }
        spriteRenderer.sprite = this.sprites[animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}