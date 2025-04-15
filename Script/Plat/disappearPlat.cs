using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearPlat : MonoBehaviour
{
    GameObject ChangeColor;
    
    private void Start()
    {
        ChangeColor = GameObject.Find("Main Camera");
        if (ChangeColor == null)
        {
            
        }
    }
    void Update()
    {
        if (ChangeColor != null)
        {
            InvertCircleController colorInverter = ChangeColor.GetComponent<InvertCircleController>();
            if (colorInverter != null)
            {
                bool shouldEnable = colorInverter.isColor();

                gameObject.GetComponent<SpriteRenderer>().enabled = shouldEnable;
                gameObject.GetComponent<BoxCollider2D>().enabled = shouldEnable;


                SpriteRenderer[] childRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
                foreach (var renderer in childRenderers)
                {
                    renderer.enabled = shouldEnable;
                }
            }
        }
    }
}
