using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // 是否还停留在场上
    public bool stay = true;

    // 拥有的金币
    public int money = 10000;

    public GameObject getOut;

    /**
     *  获取玩家是否在场
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
     *  获取玩家是否在场
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
