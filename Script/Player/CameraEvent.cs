using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraEvent : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;  // Cinemachine虚拟摄像机
    public Transform player;                        // 玩家对象
    public float transitionSpeed = 5f;              // 镜头移动的速度
    public float stayDuration = 3f;                 // 镜头停留的时间
    public float targetPositionTolerance = 0.1f;    // 目标位置的容差

    private CinemachineTransposer transposer;

    void Start()
    {
        // 获取Cinemachine的Transposer组件
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    // 触发镜头事件，并传递目标位置
    public void TriggerCameraEvent(Transform targetPosition)
    {
        StartCoroutine(CameraMoveEvent(targetPosition));
    }

    // 镜头移动协程
    private IEnumerator CameraMoveEvent(Transform targetPosition)
    {
        // 1. 暂时取消对玩家的跟随
        virtualCamera.Follow = null;

        // 2. 开始移动摄像机到目标位置
        while (Vector3.Distance(virtualCamera.transform.position, targetPosition.position) > targetPositionTolerance)
        {
            // 使用Lerp平滑移动摄像机
            virtualCamera.transform.position = Vector3.Lerp(virtualCamera.transform.position, targetPosition.position, Time.deltaTime * transitionSpeed);
            yield return null; // 等待下一帧
        }

        // 3. 摄像机停留在目标位置3秒
        yield return new WaitForSeconds(stayDuration);

        // 4. 恢复摄像机跟随玩家
        virtualCamera.Follow = player;
    }


}