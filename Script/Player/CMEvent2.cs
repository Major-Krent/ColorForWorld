using System.Collections;
using UnityEngine;
using Cinemachine;

public class CMEvent2 : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;  // Cinemachine虚拟摄像机
    public Camera noInvertCamera;                   // NoInvert Camera（作为Main Camera的子相机）
    public Transform player;                        // 玩家对象
    public float transitionSpeed = 10f;             // 摄像机移动的速度
    public float stayDuration = 0f;                 // 镜头停留的时间
    public float zoomSpeed = 5f;                    // 缩放速度
    private float initialOrthographicSize;          // 初始的镜头缩放值
    public float targetOrthographicSize = 5f;       // 目标缩放值（看到物体的全貌）
    public float targetPositionTolerance = 10f;     // 目标位置容差

    private CinemachineTransposer transposer;

    void Start()
    {
        // 获取Cinemachine的Transposer组件
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        initialOrthographicSize = virtualCamera.m_Lens.OrthographicSize; // 存储初始缩放
    }

    // 触发镜头事件，传递目标位置和缩放
    public void TriggerCameraEvent(Transform targetPosition)
    {
        StartCoroutine(CameraMoveAndZoomEvent(targetPosition));
    }

    // 镜头移动和缩放的协程
    private IEnumerator CameraMoveAndZoomEvent(Transform targetPosition)
    {
        // 1. 暂时取消对玩家的跟随
        virtualCamera.Follow = null;

        // 2. 平滑移动摄像机到目标位置
        while (Vector3.Distance(virtualCamera.transform.position, targetPosition.position) > targetPositionTolerance)
        {
            virtualCamera.transform.position = Vector3.Lerp(virtualCamera.transform.position, targetPosition.position, Time.deltaTime * transitionSpeed);
            yield return null; // 等待下一帧
        }

        // 3. 调整摄像机的缩放（正交视角），同时同步子相机的缩放
        while (Mathf.Abs(virtualCamera.m_Lens.OrthographicSize - targetOrthographicSize) > 0.01f)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetOrthographicSize, Time.deltaTime * zoomSpeed);
            noInvertCamera.orthographicSize = virtualCamera.m_Lens.OrthographicSize;  // 同步子相机的缩放
            yield return null;
        }

        // 4. 镜头停留在目标位置和缩放值一段时间
        yield return new WaitForSeconds(stayDuration);

        // 5. 恢复摄像机缩放，并同步子相机的缩放
        while (Mathf.Abs(virtualCamera.m_Lens.OrthographicSize - initialOrthographicSize) > 0.01f)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, initialOrthographicSize, Time.deltaTime * zoomSpeed);
            noInvertCamera.orthographicSize = virtualCamera.m_Lens.OrthographicSize;  // 同步子相机的缩放
            yield return null;
        }

        // 6. 恢复摄像机跟随玩家
        virtualCamera.Follow = player;
    }
}

