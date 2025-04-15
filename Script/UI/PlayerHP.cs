using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField, Header("HP")]
    private GameObject _playerIcon;

    private PlayerController _player;
    private float _beforeHP;
    private float count=0;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _beforeHP = _player.GetHP();
        _CreateHPIcon();
    }

    private void _CreateHPIcon()
    {
        if (_beforeHP == 0)
        {
            count = 0;
        }
        Debug.Log("hp" + count);
        if (_beforeHP < count)
        {
            count = _beforeHP;
        }
        if (count < _beforeHP)
        {
            if (count == 1)
            {
                for (int i = 1; i < _player.GetHP(); i++)
                {
                    GameObject _playerHPObj = Instantiate(_playerIcon);
                    _playerHPObj.transform.parent = transform;
                    count++;
                }
            }
            else
            {
                for (int i = 0; i < _player.GetHP(); i++)
                {
                    GameObject _playerHPObj = Instantiate(_playerIcon);
                    _playerHPObj.transform.parent = transform;
                    count++;
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        _ShowHPIcon();
        _CreateHPIcon();
    }

    private void _ShowHPIcon()
    {
        if (_beforeHP == _player.GetHP()) return;


        Image[] icons = transform.GetComponentsInChildren<Image>();//image–Õ§Œ≈‰¡–
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].gameObject.SetActive(i < _player.GetHP());
        }
        _beforeHP = _player.GetHP();
    }
}
