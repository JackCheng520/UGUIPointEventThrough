using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

// ================================
//* 功能描述：UGUIEventTest  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/7 9:23:05
// ================================
namespace Assets.JackCheng.UI事件穿透
{
    
    public class UGUIEventTest : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        public delegate void OnClick();
        public static event OnClick onClick;
        //监听按下
        public void OnPointerDown(PointerEventData eventData)
        {
            //PassEvent(eventData, ExecuteEvents.pointerDownHandler);
        }

        //监听抬起
        public void OnPointerUp(PointerEventData eventData)
        {
            //PassEvent(eventData, ExecuteEvents.pointerUpHandler);
        }

        //监听点击
        public void OnPointerClick(PointerEventData eventData)
        {
            //PassEvent(eventData, ExecuteEvents.submitHandler);
            PassEvent(eventData, ExecuteEvents.pointerClickHandler);
        }


        //把事件透下去
        public void PassEvent<T>(PointerEventData data, ExecuteEvents.EventFunction<T> function)
            where T : IEventSystemHandler
        {
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(data, results);
            GameObject current = data.pointerCurrentRaycast.gameObject;
            Debug.Log("current -- "+current.name);
            for (int i = 0; i < results.Count; i++)
            {
                if (current != results[i].gameObject)
                {
                    Debug.Log(results[i].gameObject.name);
                    onClick();
                    //ExecuteEvents.Execute(results[i].gameObject, data, function);
                    //RaycastAll后ugui会自己排序，如果你只想响应透下去的最近的一个响应，这里ExecuteEvents.Execute后直接break就行。
                }
            }
        }



    }
}
