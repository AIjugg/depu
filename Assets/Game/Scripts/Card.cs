using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public enum CardType
{
    JOKER,   //王
    SPADE,   //黑桃
    HARTS,   //红心
    CLUBS,   //梅花
    DIAMONDS,//方块
}


public class Card : MonoBehaviour, IPointerClickHandler
{
    private CardType cardType;  //花色
    private int cardValue;   //牌的点数
    private Vector3 targetPos;  //牌的位置
    private bool openStatus = false;   //牌能否被打开看

    // 获取牌的点数
    public int GetCardValue
    {
        set { 
            cardValue = value; 
        }
        get { 
            return cardValue; 
        }
    }

    // 获取牌的花色
    public CardType GetCardType
    {
        set {
            cardType = value;
        }

        get {
            return cardType;
        }
    }


    public Vector3 GetTargetPos
    {
        set
        {
            targetPos = value;
        }

        get
        {
            return targetPos;
        }
    }

    // 获取牌能否打开的状态
    public bool GetOpenStatus
    {
        set
        {
            openStatus = value;
        }

        get
        {
            return openStatus;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // 牌可以打开看
        if (openStatus)
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poker/" + (CardType)cardType + cardValue.ToString());
        }
    }


    // 展示卡牌
    public void OpenCard()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poker/" + (CardType)cardType + cardValue.ToString());
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // 牌移动到指定位置
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 3);

        if (Vector3.Distance(transform.position, targetPos) <= 0.001f)
        {
            transform.position = targetPos;
        }

    }
}
