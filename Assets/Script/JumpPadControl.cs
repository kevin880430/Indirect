using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadControl : MonoBehaviour,IMachine
{
    public float jumpforce = 10f;
    public GameObject pad;
    private bool isTriggered = false;

    private void Update()
    {
        Debug.Log(isTriggered);
    }
    public void Activate(bool isActive)
    {
        isTriggered = isActive;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isTriggered)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

        }
       
    }
}

