using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class User : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    // �鿴�û���Ϣ
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("��������ͣ���ˣ�" + name + " " + tag + " ��ʼ�ڣ�" + Time.time);
    }

    // �����û���Ϣ
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("�������뿪�ˣ�" + name + " " + tag + " �����ڣ�" + Time.time);
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
