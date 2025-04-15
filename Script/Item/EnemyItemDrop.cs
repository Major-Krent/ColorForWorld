using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyItemDrop : MonoBehaviour
{
    Rigidbody2D rb;
    bool isFirst = true;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject item;
    [SerializeField] private Collider2D enemyrb;
    [SerializeField] private float jumpoutForce = 680.0f;


    private void Start()
    {
        rb = item.GetComponent<Rigidbody2D>();
        enemyrb = enemy.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (enemyrb.enabled == true)
        {
            item.transform.position = enemy.transform.position;
        }
        if (enemyrb.enabled == false)
        {

            if (isFirst == true)
            {
                this.item.SetActive(true);
                //Vector2 itempos = item.transform.position;
                //itempos.y += 0.5f;
                //item.transform.position = itempos;
                rb.isKinematic = false;
                this.rb.AddForce(transform.up * this.jumpoutForce);
                isFirst = false;
            }
        }
    }
}

