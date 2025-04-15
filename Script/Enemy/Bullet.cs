using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1;
    public float speed = 7.0f;
    public float Lifetime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("DestroyBullet", Lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Mathf.Sign(transform.localScale.x) * Vector3.left * Time.deltaTime * speed);
    }


    public void Flip()
    {
        Vector3 scale= transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().TakeDamage(damage);
            gameObject.SetActive(false);
        }

        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Character>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject); 
    }
}
