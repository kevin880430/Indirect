
using UnityEngine;

public class COMControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public LayerMask Wall;
    public bool isWall;
    public float touchtime;
    private Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
    }

    void Update()
    {
        // Move the character
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, Wall);
        Debug.DrawRay(transform.position, direction * 1f, Color.red);
        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            touchtime += Time.deltaTime;
            if (touchtime > 0.25f)
            {
                // Reverse the direction if hitting a wall
                moveSpeed = -moveSpeed;
                FlipCharacter();
            }

        }
    }

    void FlipCharacter()
    {
        // Flip the character's sprite to match the new direction
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        direction = -direction;
        touchtime = 0;
    }
}

