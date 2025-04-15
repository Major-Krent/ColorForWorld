using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private AudioSource goalSound;
    public ScreenTransitionAnimator screenTransitionAnimator; // ������ ScreenTransitionAnimator �ű�

    void Start()
    {
        goalSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            goalSound.Play();
            // ��������ת��Ч�����ȴ���́E�
            StartCoroutine(HandleTransition());
        }
    }

    private IEnumerator HandleTransition()
    {
        // ���Ű�����ȁE���
        screenTransitionAnimator.FadeToWhite();

        // �ȴ�����́E�
        yield return new WaitForSeconds(3.0f); // ȷ�����ʱ��ӁE�����ȁE����ĳ���ʱ��һ��

        // ������һ��
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // ���Ű�����������
        screenTransitionAnimator.FadeFromWhite();
    }
}
