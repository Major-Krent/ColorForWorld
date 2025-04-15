using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeheal : Character
{
    [SerializeField] int amountheal;
    [SerializeField] private GameObject healitem;
    private bool itemcheck=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (healitem == false && itemcheck == true)
        {
            currentHealth += amountheal;
            itemcheck = false;
        }
    }
}
