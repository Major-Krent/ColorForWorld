using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainManager : MonoBehaviour
{
    [SerializeField, Header("¥²©`¥à¥ª©`¥Ð©`UI")]
    private GameObject _gameOverUI;

    private GameObject _player;

    private bool _bShowUI;
    // Start is called before the first frame update
    void Start()
    {
        _player=FindObjectOfType<PlayerController>().gameObject;
        _bShowUI = false;
    }

    // Update is called once per frame
    void Update()
    {
        _ShowGameOverUI();
    }
    private void _ShowGameOverUI()
    {
        if (_player != null) return;
        _gameOverUI.SetActive(true);

        _bShowUI = true;
    }

    //public void OnRestart(InputAction.CallbackContext context)
    //{
    //    if (!_bShowUI || !context.performed) return;
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}
