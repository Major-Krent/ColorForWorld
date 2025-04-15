using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBall : MonoBehaviour
{
    Rigidbody2D _rigid;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigid.velocity=new Vector2(_rigid.velocity.x, _rigid.velocity.y);

        if(_rigid.velocity.y > 0 )
        {
            _rigid.AddForce(new Vector2(0, 0.02f), ForceMode2D.Impulse);
        }
    }
}
