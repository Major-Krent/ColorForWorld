using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour
{
    [SerializeField] private GameObject[] item;

    GameObject doorText;

    void Start()
    {
        doorText = GameObject.Find("DoorText");
        doorText.SetActive(false);
    }
    void Update()
    {
        if (item[0] == false) 
        {
            doorText.SetActive (true);
            Destroy(gameObject);
        }
    }
}
