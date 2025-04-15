using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScroll : MonoBehaviour
{
    [SerializeField, Header("Test"), Range(0, 1)]
    private float _parallaxEffect = 0.5f;

    [SerializeField, Header("Auto Scroll Settings")]
    private float _scrollSpeed = 1f; // 背景自动滚动速度

    private GameObject _camera;
    private float _length;
    private float _startPosX;

    // Start is called before the first frame update
    void Start()
    {
        _startPosX = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
        _camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // 使背景自动滚动
        _startPosX -= _scrollSpeed * Time.deltaTime;

        // 处理视差效果
        _Parallax();
    }

    private void _Parallax()
    {
        float temp = _camera.transform.position.x * (1 - _parallaxEffect);
        float dist = _camera.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(_startPosX + dist, transform.position.y, transform.position.z);

        // 当背景滚出视图范围时，重置位置以实现无缝平铺
        if (_camera.transform.position.x > _startPosX + _length)
        {
            _startPosX += _length;
        }
        else if (_camera.transform.position.x < _startPosX - _length)
        {
            _startPosX -= _length;
        }
    }
}
