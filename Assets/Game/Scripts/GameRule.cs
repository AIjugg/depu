using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Level
{
    HIGH,   //����
    DOUBLE,  //һ��
    DOUBLE_TWICE,  //����
    THREE,   //����
    SHUNZI,  //˳��
    HOMOGAMY,  //ͬ��
    GOURD,   //��«
    FOUR,    //����
    FLUSH,   //ͬ��˳
    ROYAL_FLUSH,   //�ʼ�ͬ��˳
}


/**
 * ���˵Ĺ���
 * 
 * ������ö�ά�����ʾ
 */
public class GameRule : MonoBehaviour
{
    private int lv;   //�Ƶ���ߵȼ�
    private ArrayList publicCardArr;  // �����ƶ�ά����
    private int[] typeArr;  // ���ջ�ɫ����
    private int[] valueArr;  // ���յ�������


    // ����
    public void getLevel()
    {
        // todo �������Ʒŵ�array��

        // ������
        publicCardArr = new ArrayList();
        GameObject publicCard = GameObject.Find("public1");

        // �õ��ӽڵ�gameObject
        for (int j = 0; j < publicCard.transform.childCount; j++)
        {
            GameObject pub = publicCard.transform.GetChild(j).gameObject;

            //publicCardArr.Add({ });
        }




    }


    // ѡȡѡ�������볡�����Ź�������ϣ�ѡ���������
     



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
