using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// ================================
//* 功能描述：Test  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/7 9:29:16
// ================================
namespace Assets.JackCheng.UI事件穿透
{
    public class Test : MonoBehaviour
    {
        void OnEnable()
        {
            UGUIEventTest.onClick += OnClick;
        }

        void OnDisable()
        {
            UGUIEventTest.onClick -= OnClick;
        }

        private Button btn;
        void Start() {
            btn = gameObject.GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(OnClick);
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log(gameObject.name + "Clicked --");
        }

        private void OnClick()
        {
            Debug.Log(gameObject.name + "Clicked --");
        }
    }
}
