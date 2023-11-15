using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    public GameObject controlledMachine; // 可控制的机关

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                // 调用机关的 Activate 方法
                controlledMachine.GetComponent<IMachine>().Activate(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                // 调用机关的 Activate 方法
                controlledMachine.GetComponent<IMachine>().Activate(false); 
        }
    }
}
