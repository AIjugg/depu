using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // �Ƿ�ͣ���ڳ���
    public bool stay = true;

    // ӵ�еĽ��
    public int money = 10000;

    public GameObject getOut;

    /**
     *  ��ȡ����Ƿ��ڳ�
     */
    public bool GetStay
    {
        set {
            stay = value;
        }
        get {
            return stay;
        }
    }


    /**
     *  ��ȡ����Ƿ��ڳ�
     */
    public int GetMoney
    {
        set
        {
            money = value;
        }
        get
        {
            return money;
        }
    }


    private void GiveUp()
    {
        stay = false;
        getOut.gameObject.SetActive(true);
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
