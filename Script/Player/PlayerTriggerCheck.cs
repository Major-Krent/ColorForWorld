using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
   
    [HideInInspector] public bool isOn = false;

    #region//½Ó´¥ÅÐ¶¨


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isOn = true;
            //GameDerictor.Instance.ChangeSpriteColor(new Color(173f / 255f, 180f / 255f, 253f / 255));
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") 
        {
            isOn = false;
        }
    }
    */
    #endregion

}
