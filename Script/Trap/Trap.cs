using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerStay2D(Collider2D collision)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y < -0.01f)//落下するとき　ダメージを与える
            {
                collision.gameObject.GetComponent<Character>().TakeDamage(damage);
            }
        }
    }
}
