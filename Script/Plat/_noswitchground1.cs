using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class _noswitchground : MonoBehaviour
{
    [SerializeField] private GameObject KuroshiroPrefab;
    // Start is called before the first frame upda
    // Update is called once per frame
    void Update()
    {
        if (KuroshiroPrefab.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
    }
}
