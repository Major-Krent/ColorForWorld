using System.Collections;
using UnityEngine;

public class MoveUIObjectUp : MonoBehaviour
{
    public float targetYPositionPercentage = 0.8f; // 目标的 Y 轴位置百分比（相对屏幕高度）
    public float moveDuration = 5f; // 移动的持续时间
    public float waitTime = 3f; // 等待时间

    private RectTransform rectTransform; // UI 的 RectTransform
    private Vector2 initialPosition; // 初始位置
    private Vector2 targetPosition; // 目标位置

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition;

        // 计算目标位置，基于屏幕高度的百分比
        targetPosition = new Vector2(initialPosition.x, Screen.height * targetYPositionPercentage);

        StartCoroutine(MoveAfterWait());
    }

    IEnumerator MoveAfterWait()
    {
        // 等待指定时间
        yield return new WaitForSeconds(waitTime);

        // 移动物体
        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            // 只改变 Y 轴位置，基于百分比计算
            float newY = Mathf.Lerp(initialPosition.y, targetPosition.y, elapsedTime / moveDuration);
            rectTransform.anchoredPosition = new Vector2(initialPosition.x, newY);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 确保物体最终停在目标 Y 轴位置
        rectTransform.anchoredPosition = new Vector2(initialPosition.x, targetPosition.y);
    }
}
