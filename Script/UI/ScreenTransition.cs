using UnityEngine;

public class ScreenTransitionAnimator : MonoBehaviour
{
    public Animator animator;

    public void FadeToWhite()
    {
        if (animator != null)
        {
            animator.SetTrigger("FadeIn"); // ȷ�� Animator �е� Trigger ����Ϊ "FadeIn"
        }
    }

    public void FadeFromWhite()
    {
        if (animator != null)
        {
            animator.SetTrigger("FadeOut"); // ȷ�� Animator �е� Trigger ����Ϊ "FadeOut"
        }
    }
}
