using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestory : MonoBehaviour

{
    [Header("�v���[���[�̔���")] public PlayerTriggerCheck playerCheck;

    // Update is called once per frame
    void Update()
    {

        if (playerCheck.isOn)
        {
            Destroy(this.gameObject);
        }
    }
}
