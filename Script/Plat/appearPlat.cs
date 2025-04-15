using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appearPlat : MonoBehaviour
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
                bool shouldEnable = !colorInverter.isColor();
                // 启用或禁用父对象的 SpriteRenderer 和 BoxCollider2D
                gameObject.GetComponent<SpriteRenderer>().enabled = shouldEnable;
                gameObject.GetComponent<BoxCollider2D>().enabled = shouldEnable;

                // 启用或禁用所有子对象的 SpriteRenderer
                SpriteRenderer[] childRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
                foreach (var renderer in childRenderers)
                {
                    renderer.enabled = shouldEnable;
                }
            }
        }
    }
}
