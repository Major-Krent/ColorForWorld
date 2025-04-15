using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public SpriteChanger changer;
    public Transform cameraTargetPosition;
    public CMEvent2 cameraEvent;  // 缓存CMEvent2的引用
    GameObject score;
    float ScorePoint;
    private bool CameraEnd=false;

    void Start()
    {
        ScorePoint = 0.0f;
        this.score = GameObject.Find("ScoreB");
        this.score.GetComponent<Image>().fillAmount = 0.0f;

        // 在Start中查找CMEvent2

        if (cameraEvent == null)
        {
            Debug.LogError("CMEvent2 not found in the scene.");
        }
        else
        {
            Debug.Log("found");
        }
    }

    void Update()
    {
        ChangeBackGroundColor();
    }

    public void GetScore()
    {
        this.score.GetComponent<Image>().fillAmount += 0.05f;
        ScorePoint += 0.05f;
        Debug.Log(ScorePoint);
    }

    private void ChangeBackGroundColor()
    {
        if (ScorePoint >= 1f)
        {
            if (cameraEvent != null && !CameraEnd)
            {
                cameraEvent.TriggerCameraEvent(cameraTargetPosition);
                CameraEnd = true;
            }
            Debug.Log("camer1");
            changer.ChangeAll();
            Debug.Log("camer2");
        }
    }
}