using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //プレイヤーの移動速度
    public float moveSpeed = 5f;
    //プレイヤーのジャンプ力
    public float jumpForce = 8f; 
    //地面レイヤー
    public LayerMask groundLayer;
    //ジャンプの入力しているかどうかのフラグ
    private bool JumpInput;
    //ジャンプのキーが押されているかどうかのフラグ
    private bool JumpInputC;
    //
    public float fallingMutiply=2.0f;
    public float shortJumpMutiply=1.0f;
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    //地面にいるかどうかのフラグ
    public bool isGrounded;
    public enum FallingState
    {
        JumptoFall,
        ElsetoFall
    }

    void Start()
    {
        //RididBody2Dとスプライトを取得する
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //RayCastで地面にいるかどうかを検知
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, groundLayer);
        isGrounded = hit.collider != null;
        Debug.DrawRay(transform.position, Vector2.down * 0.7f, Color.red);
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            JumpInput = true;
        }
        //キーが押されてる時間によるジャンプの高さを変えるため
        //キーが押されているかどうかを検知
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
        //ジャンプの入力がある時
        if (JumpInput)
        {
            //次の入力までジャンプさせない
            JumpInput = false;
            Jump();
        }
        //RigidBodyの垂直速度が0以下(落下中)の時さらに重力を加える
        if (rb2d.velocity.y <0)
        {
            rb2d.velocity += Vector2.up * (Physics2D.gravity.y * fallingMutiply) * Time.deltaTime;
        }
        //RigidBodyの垂直速度が0以上(ジャンプ中)かつキーが押されてないの時重力は普通にする
        else if (rb2d.velocity.y > 0&&!JumpInputC)
        {
            rb2d.velocity += Vector2.up * (Physics2D.gravity.y * shortJumpMutiply) * Time.deltaTime;
        }


    }

    void Jump()
    {
        //地面にいる時だけジャンプできる
        if (isGrounded)
        {
            rb2d.AddForce(Vector2.up *jumpForce,ForceMode2D.Impulse);
        }
    }

    void Move()
    {
        // 左右移動
        float horizontalInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontalInput * moveSpeed, rb2d.velocity.y);
        //方向に応じでスプライトを反転する
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