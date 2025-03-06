using UnityEngine;

public class Invaders : MonoBehaviour
{
    public int rows = 5;
    public int cols = 11;
    public Invader[] invaders;
    private Vector3 _directionOfInvaders = Vector2.right;
    public AnimationCurve speed;
    public int invadersDead;
    public float invadersAlive;

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = 1.0f * (this.cols - 1);
            float height = 1.0f * (this.rows + 1);
            Vector3 CenterOfScreen = new Vector3(-width / 1f, -height / 1f, 0.0f);
            Vector3 rowPosition = new Vector3(CenterOfScreen.x, CenterOfScreen.y +(row * 1.0f), 0.0f);
            for (int col = 0; col < cols; col++)
            {
                Invader invader = Instantiate(this.invaders[row], this.transform);
                invader.killed += InvaderKilled;
                Vector3 postition = rowPosition;
                postition.x += col * 1.0f;
                invader.transform.localPosition = postition;
            }
        }
    }

    private void Update()
    {
        this.transform.position += this._directionOfInvaders * (this.speed.Evaluate((float)this.invadersDead /((float)this.rows * (float)this.cols)) * Time.deltaTime);
        
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (_directionOfInvaders == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
            {
                NextRow();
            }else if (_directionOfInvaders == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
            {
                NextRow();
            }
            
        }
    }

    private void NextRow()
    {
        _directionOfInvaders.x *= -1.0f;
        
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }
    
    private void InvaderKilled(){
        
    }
}