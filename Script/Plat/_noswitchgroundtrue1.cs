using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _noswitchgroundtrue : MonoBehaviour
{
    [SerializeField] GameObject swicth;
    [SerializeField] private GameObject KuroshiroPrefab;
    // Update is called once per frame
    void Update()
    {
        if (KuroshiroPrefab.activeSelf == false)
        {
            swicth.SetActive(true);
        }
    }
}
