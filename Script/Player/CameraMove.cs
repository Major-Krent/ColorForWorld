using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;  // 你的Cinemachine虚拟摄像机
    public float moveSpeed = 10f;                   // 摄像机移动速度
    public float maxOffset = 5f;                    // 最大偏移量
    public float returnSpeed = 10f;                 // 回归初始偏移的速度
    private float initialYOffset = 3.2f;            // 初始Y偏移值
    private float initialXOffset = 0f;              // 初始X偏移值

    private CinemachineFramingTransposer transposer;
    private PlayerController playerController;      // 引用PlayerController脚本

    void Start()
    {
        // 获取Cinemachine的Framing Transposer组件
        transposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        // 获取玩家的PlayerController组件
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        // 获取手柄的垂直输入
        float verticalInput = Input.GetAxis("Vertical");
        // 获取手柄的水平输入，使用新的轴 CameraHorizontal
        float horizontalInput = Input.GetAxis("CameraHorizontal");

        // 根据角色的朝向调整水平输入
        if (!playerController.facingRight)  // 当角色朝向左侧时，反转水平输入
        {
            horizontalInput = -horizontalInput;
        }

        // 如果有手柄输入，调整Y轴偏移
        if (Mathf.Abs(verticalInput) > 0.1f) // 检测是否有输入
        {
            // 计算新的Y轴偏移值，限制其范围
            float newYOffset = Mathf.Clamp(transposer.m_TrackedObjectOffset.y + verticalInput * moveSpeed * Time.deltaTime, -maxOffset, maxOffset + 3f);

            // 更新摄像机的偏移量
            transposer.m_TrackedObjectOffset.y = newYOffset;
        }
        else
        {
            // 如果没有输入，逐渐恢复到初始的Y偏移值
            transposer.m_TrackedObjectOffset.y = Mathf.Lerp(transposer.m_TrackedObjectOffset.y, initialYOffset, Time.deltaTime * returnSpeed);
        }

        // 如果有手柄输入，调整X轴偏移
        if (Mathf.Abs(horizontalInput) > 0.1f) // 检测是否有输入
        {
            // 计算新的X轴偏移值，限制其范围
            float newXOffset = Mathf.Clamp(transposer.m_TrackedObjectOffset.x + horizontalInput * moveSpeed * Time.deltaTime, -maxOffset, maxOffset);

            // 更新摄像机的偏移量
            transposer.m_TrackedObjectOffset.x = newXOffset;
        }
        else
        {
            // 如果没有输入，逐渐恢复到初始的X偏移值
            transposer.m_TrackedObjectOffset.x = Mathf.Lerp(transposer.m_TrackedObjectOffset.x, initialXOffset, Time.deltaTime * returnSpeed);
        }
    }
}
