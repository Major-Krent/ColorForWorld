using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowScoreItem : MonoBehaviour
{
    [Header("ÉvÉåÅ[ÉÑÅ[ÇÃîªíË")] public PlayerTriggerCheck playerCheck;

    // Update is called once per frame
    void Update()
    {
        
        if (playerCheck.isOn)
        {
            Destroy(this.gameObject);

            GameObject director = GameObject.Find("ScoreY");
            director.GetComponent<ScoreY>().GetScore();
        }
    }
}