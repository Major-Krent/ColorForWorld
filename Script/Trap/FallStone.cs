using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallStone : MonoBehaviour
{
    Rigidbody2D _rigid;

    private bool _isGroundHit = false;
    private Vector3 _originalPosition;
    private Vector3 _velocity = Vector3.zero;
    private float timer = 0;
    private float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _originalPosition= _rigid.position;


    }

    // Update is called once per frame
    void Update()
    {
        if(_isGroundHit)
        {
            timer += Time.deltaTime;
        }
        GetBack();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _rigid.isKinematic = false;
            _rigid.gravityScale = 5f;
            _isGroundHit = true;
        }
    }

    private void GetBack()
    {
        if(timer>5.0)
        {
            _rigid.isKinematic = true;
            speed = 2.5f;
            this.transform.Translate(0, speed * Time.deltaTime, 0);
            if(_rigid.position.y>_originalPosition.y)
            {
                _isGroundHit = false;
                timer= 0;
                speed = 0;
            }
        }
    }

}
