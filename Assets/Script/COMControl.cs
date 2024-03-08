
using UnityEngine;

public class COMControl : MonoBehaviour
{
    //COMの移動速度
    public float moveSpeed = 5f;
    //RigidBody2Dを宣言
    private Rigidbody2D rb;
    //壁レイヤーを宣言
    public LayerMask Wall;
    //壁に当たっているかどうかのフラグ
    public bool isWall;
    //壁との接触時間
    public float touchtime;
    //移動方向
    private Vector2 direction;
    void Start()
    {
        //RigidBody2Dを取得する
        rb = GetComponent<Rigidbody2D>();
        //初期の移動方向を右にする
        direction = Vector2.right;
    }

    void Update()
    {
        //COMキャラを動かす
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        //RayCastで壁を探知する
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, Wall);
        Debug.DrawRay(transform.position, direction * 1f, Color.red);
        //Rayが壁に当たったら
        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            //接触時間を計算する
            touchtime += Time.deltaTime;
            //接触時間が0.25秒以上なら
            if (touchtime > 0.25f)
            {
                //移動方向を反転する
                moveSpeed = -moveSpeed;
                FlipCharacter();
            }

        }
    }

    void FlipCharacter()
    {
        //キャラの向き(Rayも)を反転する
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        direction = -direction;
        //接触時間を初期化
        touchtime = 0;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ゴールに着いたらキャラを止める
        if (collision.gameObject.CompareTag("Goal"))
        {
            print("Stop");
            moveSpeed = 0;
        }
    }
}

