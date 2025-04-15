using UnityEngine;

public class ScreenTransitionAnimator : MonoBehaviour
{
    public Animator animator;

    public void FadeToWhite()
    {
        if (animator != null)
        {
            animator.SetTrigger("FadeIn"); // 确保 Animator 中的 Trigger 名称为 "FadeIn"
        }
    }

    public void FadeFromWhite()
    {
        if (animator != null)
        {
            animator.SetTrigger("FadeOut"); // 确保 Animator 中的 Trigger 名称为 "FadeOut"
        }
    }
}
