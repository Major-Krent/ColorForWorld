using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [Header("ÉvÉåÅ[ÉÑÅ[ÇÃîªíË")] public PlayerTriggerCheck playerCheck;

    // Update is called once per frame
    void Update()
    {
        
        if (playerCheck.isOn)
        {
            Destroy(this.gameObject);

            GameObject director = GameObject.Find("ScoreB");
            director.GetComponent<Score>().GetScore();
        }
    }
}