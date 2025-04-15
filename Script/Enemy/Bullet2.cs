using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float damage = 1;
    public float speed = 7.0f;
    public float verticalAmplitude = 5.0f;
    public float verticalFrequency = 8.0f;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        // Horizontal movement
        transform.Translate(Mathf.Sign(transform.localScale.x) * Vector3.left * Time.deltaTime * speed);

        //Vertical movement
        float verticalOffset = Mathf.Sin((Time.time - startTime) * verticalFrequency) * verticalAmplitude;
        transform.position += new Vector3(0, verticalOffset, 0) * Time.deltaTime;
    }

    public void Flip()
    {
        Vector3 scale = transform.localScale;
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
}