using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class TextFadeOut : MonoBehaviour
{

    //fadeËÙ¶È
    public float speed = 0.5f;
    Color color;

    void Start()
    {

        color = GetComponent<TextMeshProUGUI>().color;

    }

    void Update()
    {

        if (gameObject.activeSelf)  
        {
            color.a -= Time.deltaTime * speed;  
            GetComponent<TextMeshProUGUI>().color = color; 
        }

    }
}