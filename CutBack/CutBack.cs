using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CutScene
{
    public class CutBack : MonoBehaviour
    {
        public static CutBack instance;
        public Image ima;
        private Color c = new Color(0, 0, 0, 0.01f);
        void Start()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
            }
            DontDestroyOnLoad(this);
        }
        public IEnumerator CutImageIn(UnityAction ac)
        {
            ima.raycastTarget = true;
            while (ima.color.a < 1)
            {
                ima.color = ima.color + new Color(0, 0, 0, c.a);
                yield return null;
            }
            ac();
            StartCoroutine(CutImageOut());
        }
       
        public IEnumerator CutImageOut()
        {
            while (ima.color.a > 0)
            {
                ima.color = ima.color - c;
                yield return null;
            }
            ima.raycastTarget = false;

        }
       
    }
}
