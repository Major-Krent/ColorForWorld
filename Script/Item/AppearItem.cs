using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearItem : MonoBehaviour
{
    [SerializeField] private GameObject[] item;
    public GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        targetObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (item[0] == false)
        {
            targetObject.SetActive(true);
        }
    }
}
