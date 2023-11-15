using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 移动速度
    public float jumpForce = 8f; // 跳跃力量
    public LayerMask groundLayer; // 地面层
    private bool JumpInput;
    private bool JumpInputC;
    public float fallingMutiply=2.0f;
    public float shortJumpMutiply=1.0f;
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    public bool isGrounded;
    public enum FallingState
    {
        JumptoFall,
        ElsetoFall
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 检测是否在地面上
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, groundLayer);
        isGrounded = hit.collider != null;
        Debug.DrawRay(transform.position, Vector2.down * 0.7f, Color.red);
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            JumpInput = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            JumpInputC = true;
        }
        else
        {
            JumpInputC = false;
        }



    }
    private void FixedUpdate()
    {
        Move();
        // 跳跃
        if (JumpInput)
        {
            JumpInput = false;
            Jump();
        }
        if (rb2d.velocity.y <0)
        {
            rb2d.velocity += Vector2.up * (Physics2D.gravity.y * fallingMutiply) * Time.deltaTime;
        }
        else if (rb2d.velocity.y > 0&&!JumpInputC)
        {
            rb2d.velocity += Vector2.up * (Physics2D.gravity.y * shortJumpMutiply) * Time.deltaTime;
        }


    }

    void Jump()
    {
        if (isGrounded)
        {
            rb2d.AddForce(Vector2.up *jumpForce,ForceMode2D.Impulse);
        }
    }

    void Move()
    {
        // 左右移动
        float horizontalInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontalInput * moveSpeed, rb2d.velocity.y);
        
        if (horizontalInput > 0)
        {
            sr.flipX = false;
        }
        if (horizontalInput < 0)
        {
            sr.flipX = true;
        }
    }
    

}