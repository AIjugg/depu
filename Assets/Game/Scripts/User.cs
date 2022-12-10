using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class User : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    // 查看用户信息
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("你的鼠标悬停在了：" + name + " " + tag + " 开始于：" + Time.time);
    }

    // 隐藏用户信息
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("你的鼠标离开了：" + name + " " + tag + " 结束于：" + Time.time);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
