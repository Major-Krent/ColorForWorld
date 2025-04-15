using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ScoreY : MonoBehaviour
{
    public SpriteChanger changer;
    public Transform cameraTargetPosition;
    public CMEvent2 cameraEvent;
    GameObject score;
    float ScorePoint;
    private bool CameraEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        ScorePoint = 0.0f;
        this.score = GameObject.Find("ScoreY");
        this.score.GetComponent<Image>().fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBackGroundColor();

    }
    public void GetScore()
    {
        this.score.GetComponent<Image>().fillAmount += 0.06f;
        ScorePoint += 0.08f;
        Debug.Log(ScorePoint);
        //GetComponent<AudioSource>().Play();
    }

    private void ChangeBackGroundColor()
    {
        if (ScorePoint >= 0.05f)
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