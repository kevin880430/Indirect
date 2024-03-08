using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IMachineインターフェースを継承
public class JumpPadControl : MonoBehaviour,IMachine
{
    //与えるジャンプ力
    public float jumpforce = 10f;
    //起動されているかどうかフラグ
    private bool isTriggered = false;
    public void Activate(bool isActive)
    {
        //起動されたら値を取得する(この値OnCollisionStayで使う)
        isTriggered = isActive;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isTriggered)
        {
            //ジャンプパッドと接触してる物体に力を与える
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
       
    }
}

