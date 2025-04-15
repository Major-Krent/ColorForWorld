using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_3 : MonoBehaviour
{
    [SerializeField] private GameObject[] item;

    GameObject doorText;

    void Start()
    {

    }
    void Update()
    {
        if (item[0] == false)
        {
            Destroy(gameObject);
        }
    }
}
