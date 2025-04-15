using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerController playerController;
    public Animator anim;
    public bool isBurning = false;
    public bool isBurnC = false;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();

        // 检查 Animator 是否正确绑定
        if (anim.runtimeAnimatorController == null)
        {
            Debug.LogError("Animator is not assigned to an AnimatorController");
        }
    }


    void Update()
    {
        AnimationController();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isBurning)
        {
            Vector3 currentPosition = this.transform.position;
            Vector3 newPosition = new Vector3(currentPosition.x, currentPosition.y + 10, currentPosition.z);
            playerController.UpDateCheckPoint(newPosition);
            isBurning = true;
        }
    }

    private void AnimationController()
    {
        anim.SetBool("isBurning", isBurning);
        anim.SetBool("isBurnC", isBurnC);
        //Debug.Log("isBurnC"+isBurnC);
        //Debug.Log("isBurning" + isBurning);
    }

    public void ChangeTheState()
    {
        isBurning = false;
        isBurnC = true ;
        //Debug.Log("havechanged");
    }
}
