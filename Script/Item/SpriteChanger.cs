using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    //public GameObject checkpointprefab;
    //private GameObject checkpointInstance;
    //private CheckPoint checkpointScript;

    public CheckPoint checkpointScript;
    // single SpriteRenderer和Sprite
    public SpriteRenderer SpriteRenderer; // Old SpriteRenderer
    public Sprite newSprite; // New Sprite

    // multiple SpriteRenderer和Sprites
    public SpriteRenderer[] spriteRenderers; // Array of SpriteRenderers to change
    public Sprite[] newSprites; // Array of new Sprites, matching the SpriteRenderers array

    // animator
    public Animator animator; // 需要更改动画的物体的Animator数组
    public string animationParameterName; // 控制动画的参数名
    public string newAnimationState; // 新的动画状态

    void Start()
    {
        //checkpointInstance = Instantiate(checkpointprefab);
        //checkpointScript = checkpointInstance.GetComponent<CheckPoint>();
    }


    void Update()
    {

    }

    // single sprite
    public void ChangeSprite()
    {
        if (SpriteRenderer != null && newSprite != null)
        {
            SpriteRenderer.sprite = newSprite;
        }
    }

    // multiple sprite
    public void ChangeSprites()
    {
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            if (spriteRenderers[i] != null && i < newSprites.Length)
            {
                spriteRenderers[i].sprite = newSprites[i];
            }
        }
    }

    // change animation
    public void ChangeAnimationState()
    {
        checkpointScript.ChangeTheState();
        Debug.Log("playing");
        //checkpointScript.isBurnC = true;
        //foreach (Animator animator in animators)
        //{
        //    if (animator != null)
        //    {
        //        animator.Play(newAnimationState);
        //    }
        //}
        animator.SetTrigger("isBurningC");
    }



    // totally change
    public void ChangeAll()
    {
        ChangeSprite(); // 单个精灵的更换
        ChangeSprites(); // 多个精灵的更换
        ChangeAnimationState(); // 动画状态的更换
        
    }




    //public void PlayIsBurningC()
    //{
    //    foreach (var animator in animators)
    //    {
    //        animator.SetTrigger("isBurningC");
    //    }
    //}
}