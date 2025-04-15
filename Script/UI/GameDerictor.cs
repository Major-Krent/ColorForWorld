using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDerictor : MonoBehaviour
{
    public static GameDerictor Instance;
    public SpriteRenderer targetSpriteRenderer; // sprite drag and drop
    private void Awake()
    {
        // 确保这个类的单例模式
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeSpriteColor(Color color)
    {
        if (targetSpriteRenderer != null)
        {
            targetSpriteRenderer.color = color;
        }
    }
}
