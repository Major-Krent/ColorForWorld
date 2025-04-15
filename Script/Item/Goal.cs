using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private AudioSource goalSound;
    public ScreenTransitionAnimator screenTransitionAnimator; // ¹ØÁªµÄ ScreenTransitionAnimator ½Å±¾

    void Start()
    {
        goalSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            goalSound.Play();
            // Æô¶¯°×ÆÁ×ª³¡Ğ§¹û²¢µÈ´ıÆäÍEÉ
            StartCoroutine(HandleTransition());
        }
    }

    private IEnumerator HandleTransition()
    {
        // ²¥·Å°×ÆÁµ­ÈE¯»­
        screenTransitionAnimator.FadeToWhite();

        // µÈ´ı¶¯»­ÍEÉ
        yield return new WaitForSeconds(3.0f); // È·±£Õâ¸öÊ±¼äÓE×ÆÁµ­ÈE¯»­µÄ³ÖĞøÊ±¼äÒ»ÖÂ

        // ¼ÓÔØÏÂÒ»¹Ø
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // ²¥·Å°×ÆÁµ­³ö¶¯»­
        screenTransitionAnimator.FadeFromWhite();
    }
}
