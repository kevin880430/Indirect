using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    //違う装置のコンポーネントを取得するため宣言する空欄
    public GameObject controlledMachine; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーと接触すると
        if (collision.gameObject.tag == "Player")
        {
            //装置にあるActiveメソッドにアクセス、起動させる  
            controlledMachine.GetComponent<IMachine>().Activate(true);
            //見やすいためスイッチのスプライトを拡大する
            this.gameObject.transform.localScale = new Vector3(1.2f, 1.2f,1.0f);
            //起動した装置がジャンプパットの場合、ジャンプパットを少し上げる
            if (controlledMachine.gameObject.name == "Pad")
            {
                controlledMachine.transform.Translate(Vector3.up * 0.1f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //プレイヤーが離れたら
        if (collision.gameObject.tag == "Player")
        {
            //装置を停止
            controlledMachine.GetComponent<IMachine>().Activate(false);
            //スイッチのスプライトを元の状態に戻る
            this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f,1.0f);
            //起動した装置がジャンプパットの場合、ジャンプパットを少し下げる
            if (controlledMachine.gameObject.name == "Pad")
            {
                controlledMachine.transform.Translate(Vector3.down * 0.1f);
            }
            
            
        }
    }
}
