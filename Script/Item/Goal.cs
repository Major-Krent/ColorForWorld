using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private AudioSource goalSound;
    public ScreenTransitionAnimator screenTransitionAnimator; // 关联的 ScreenTransitionAnimator 脚本

    void Start()
    {
        goalSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            goalSound.Play();
            // 启动白屏转场效果并等待其蛠E�
            StartCoroutine(HandleTransition());
        }
    }

    private IEnumerator HandleTransition()
    {
        // 播放白屏淡葋E�
        screenTransitionAnimator.FadeToWhite();

        // 等待动画蛠E�
        yield return new WaitForSeconds(3.0f); // 确保这个时间觼E灼恋丒某中奔湟恢�

        // 加载下一关
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // 播放白屏淡出动画
        screenTransitionAnimator.FadeFromWhite();
    }
}
