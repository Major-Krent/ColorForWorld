using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    public float damage = 1;
    AudioSource audioS;
    public AudioClip deadclip;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character>().TakeDamage(damage);    
            if(!audioS.isPlaying)
            {
                audioS.clip = deadclip;
                audioS.PlayOneShot(deadclip);
            }
        }

    }

}
