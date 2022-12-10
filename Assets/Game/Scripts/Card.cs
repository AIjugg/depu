using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public enum CardType
{
    JOKER,   //��
    SPADE,   //����
    HARTS,   //����
    CLUBS,   //÷��
    DIAMONDS,//����
}


public class Card : MonoBehaviour, IPointerClickHandler
{
    private CardType cardType;  //��ɫ
    private int cardValue;   //�Ƶĵ���
    private Vector3 targetPos;  //�Ƶ�λ��
    private bool openStatus = false;   //���ܷ񱻴򿪿�

    // ��ȡ�Ƶĵ���
    public int GetCardValue
    {
        set { 
            cardValue = value; 
        }
        get { 
            return cardValue; 
        }
    }

    // ��ȡ�ƵĻ�ɫ
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

    // ��ȡ���ܷ�򿪵�״̬
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
        // �ƿ��Դ򿪿�
        if (openStatus)
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poker/" + (CardType)cardType + cardValue.ToString());
        }
    }


    // չʾ����
    public void OpenCard()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poker/" + (CardType)cardType + cardValue.ToString());
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // ���ƶ���ָ��λ��
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 3);

        if (Vector3.Distance(transform.position, targetPos) <= 0.001f)
        {
            transform.position = targetPos;
        }

    }
}
