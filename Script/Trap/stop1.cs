using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class stop1 : MonoBehaviour
{
    private GameObject ChangeColor;
    private Rigidbody2D rb;
    private bool isStop;
    private Vector2 temporaryVelosity;
    private float angularVelocity;
    // Start is called before the first frame update
    void Start()
    {
        ChangeColor = GameObject.Find("Main Camera");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            if (ChangeColor.GetComponent<InvertCircleController>().isColor())
            {
                if (isStop == false)
                {
                    temporaryVelosity = rb.velocity;
                    angularVelocity = rb.angularVelocity;
                }
                rb.isKinematic = true;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                if (GetComponent<Trap>() != null)
                {
                    GetComponent<Trap>().enabled = false;
                    GetComponent<CircleCollider2D>().isTrigger = false;
                    this.gameObject.layer = LayerMask.NameToLayer("Ground");
                }
                isStop = true;
            }
            else if (!ChangeColor.GetComponent<InvertCircleController>().isColor() && isStop == true)
            {
                rb.isKinematic = false;
                rb.constraints = RigidbodyConstraints2D.None;
                if (GetComponent<Trap>() != null)
                {
                    rb.velocity = temporaryVelosity;
                    rb.angularVelocity = angularVelocity;
                    GetComponent<Trap>().enabled = true;
                    GetComponent<CircleCollider2D>().isTrigger = true;
                    this.gameObject.layer = LayerMask.NameToLayer("Default");
                }
                isStop = false;
            }

    }
}
