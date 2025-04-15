using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;

    GameObject ChangeColor;

    private void Start()
    {
        ChangeColor = GameObject.Find("Main Camera");
    }
    private void Update()
    {
       
        

        if (ChangeColor.GetComponent<InvertCircleController>().isColor())
        {  
            // 目的地を次のポイントにセットすE
            currentWaypointIndex = 1;
            
        }
        else
        {
            currentWaypointIndex = 0;
            
        }

        // 現在の床の位置から、目的地の位置まで移丒すE
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

    }
}