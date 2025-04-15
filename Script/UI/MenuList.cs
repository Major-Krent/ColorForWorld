using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuList : MonoBehaviour
{
    public GameObject menuList;

    [SerializeField] private bool menukeys = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menukeys)
        {
            if (Input.GetButtonDown("MenuList"))
            {
                menuList.SetActive(true);
                menukeys = false;
                Time.timeScale = 0;
            }
            
        }
        else if (Input.GetButtonDown("MenuList"))
        {
            menuList.SetActive(false);
            menukeys = true;
            Time.timeScale = 1;
        }
    }

    public void Return()
    {
        menuList.SetActive(false);
        menukeys = true;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Scene currentScene=SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        menuList.SetActive(false);
        Time.timeScale = 1;
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
