using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Transform cameraTargetPosition;  // 摄像机要移动到的目标位置

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 找到CameraEvent脚本并传递目标位置
            CameraEvent cameraEvent = FindObjectOfType<CameraEvent>();
            if (cameraEvent != null)
            {
                cameraEvent.TriggerCameraEvent(cameraTargetPosition); // 传递目标位置
            }

            // 其他逻辑，如销毁物品等
            Destroy(gameObject);
        }
    }
}
