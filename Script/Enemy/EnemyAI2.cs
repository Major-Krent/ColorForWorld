using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : Character
{
    private Animator anim;
    public Transform player;
    public float detectionRange = 10f;
    public float moveSpeed = 3f;
    public float attackRange = 2f;
    public float attackCooldown = 2f;
    public float chargeSpeed = 10f; // 冲击速度
    public float chargeDuration = 0.5f; // 冲击持续时间

    private bool isAttacking = false;
    private bool canAttack = true;
    private bool isCharging = false;
    private bool isHurt = false;
    private bool isDead = false;

    Transform AttackTf;

    private PlayerController playerScript;
    private Rigidbody2D rb;

    public float damage;
    private SpriteRenderer sr;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        AttackTf = transform.Find("Attack");
        sr = GetComponent<SpriteRenderer>();

        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
                playerScript = playerObject.GetComponent<PlayerController>();
            }
        }
    }

    void Update()
    {
        if (!isCharging)
        {
            SearchPlayer();
        }

        bool isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("isCharging", isCharging);
        anim.SetBool("isDead", isDead);
        DieOrNot();
    }

    private void SearchPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (isHurt == true)
        {
            rb.velocity = Vector3.zero;
        }
        else if (distanceToPlayer <= detectionRange)
        {
            if (distanceToPlayer > attackRange)
            {
                MoveTowardsPlayer();
            }
            else if (!isAttacking && canAttack)
            {
                StartCoroutine(ChargeTowardsPlayer());
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = new Vector3((player.position - transform.position).normalized.x, 0, 0);
        transform.position += direction * moveSpeed * Time.deltaTime;

        //Slim flip
        float x = player.position.x - transform.position.x;
        if (x > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        /*
        if (direction.x < 0.0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (direction.x > 0.0f)
        {
            transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        }
        */
    }

    private IEnumerator ChargeTowardsPlayer()
    {
        //Slim flip
        float x = player.position.x - transform.position.x;
        if (x > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        isCharging = true;
        yield return new WaitForSeconds(0.5f);
        Vector3 direction = (player.position - transform.position).normalized;
        float chargeEndTime = Time.time + chargeDuration;


        while (Time.time < chargeEndTime)
        {
            if (isHurt == true)
            {
                rb.velocity = Vector3.zero;
            }
            else
                rb.velocity = direction * chargeSpeed;
            yield return null;
        }

        rb.velocity = Vector3.zero;
        isCharging = false;
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        Debug.Log("Enemy attack cooldown finished");
        canAttack = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().TakeDamage(damage);
        }
    }

    public void SlimHurt()
    {
        isHurt = true;
        anim.SetTrigger("hurt");
        StartCoroutine(DazzleCooldown());
    }

    private IEnumerator DazzleCooldown()
    {
        yield return new WaitForSeconds(2f);
        isHurt = false;
    }

    public void SlimDie()
    {
        isDead = true;

    }

    private void DieOrNot()
    {
        if (isDead == true)
        {
            rb.velocity = Vector3.zero;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            foreach (Character script in GetComponents<Character>())
            {
                script.enabled = false;
            }
        }
    }
}
