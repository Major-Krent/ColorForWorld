using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemofChange : MonoBehaviour
{
    public GameObject TargetObject;
    private SpriteChanger spriteChanger;

    // Start is called before the first frame update
    void Start()
    {
        spriteChanger= TargetObject.GetComponent<SpriteChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (spriteChanger != null)
            {
                spriteChanger.ChangeAll();
            }
        }
        Destroy(gameObject);
    }
}
