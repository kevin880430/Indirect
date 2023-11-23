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
            this.gameObject.transform.localScale = new Vector3(1.2f, 1.2f,1.0f);
            if (controlledMachine.gameObject.name == "Pad")
            {
                controlledMachine.transform.Translate(Vector3.up * 0.1f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controlledMachine.GetComponent<IMachine>().Activate(false);
            this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f,1.0f);
            if (controlledMachine.gameObject.name == "Pad")
            {
                controlledMachine.transform.Translate(Vector3.down * 0.1f);
            }
            
            
        }
    }
}
