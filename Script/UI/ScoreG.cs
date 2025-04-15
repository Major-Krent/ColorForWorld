using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreG : MonoBehaviour
{
    public SpriteChanger changer;
    public Transform cameraTargetPosition;
    public CMEvent2 cameraEvent; 
    GameObject score;
    float ScorePoint;
    private bool CameraEnd = false;


    void Start()
    {
        ScorePoint = 0.0f;
        this.score = GameObject.Find("ScoreG");
        this.score.GetComponent<Image>().fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBackGroundColor();

    }
    public void GetScore()
    {
        this.score.GetComponent<Image>().fillAmount += 0.05f;
        ScorePoint += 0.05f;
        Debug.Log(ScorePoint);
        //GetComponent<AudioSource>().Play();
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
            changer.ChangeAll();
        }
    }
}