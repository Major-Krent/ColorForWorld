using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenScoreItem : MonoBehaviour
{
    [Header("ÉvÉåÅ[ÉÑÅ[ÇÃîªíË")] public PlayerTriggerCheck playerCheck;

    // Update is called once per frame
    void Update()
    {
        
        if (playerCheck.isOn)
        {
            Destroy(this.gameObject);

            GameObject director = GameObject.Find("ScoreG");
            director.GetComponent<ScoreG>().GetScore();
            GameObject director1 = GameObject.Find("ScoreG1");
            director.GetComponent<ScoreG1>().GetScore();
        }
    }
}