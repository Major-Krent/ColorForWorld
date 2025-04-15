using UnityEngine;

public class FrameLimit : MonoBehaviour
{
    public enum LimitType
    {
        NoLimit=-1,
        Limit30=30,
        Limit60=60,
        Limit90=90,
        Limit120=120
    }

    public LimitType limitType;

    private void Awake()
    {
        Application.targetFrameRate = (int)limitType;
    }
}
