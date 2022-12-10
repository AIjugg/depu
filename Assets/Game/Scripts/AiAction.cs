using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAction : MonoBehaviour
{
    // ����
    public GameObject playerBox;

    // ��Ϸ״̬
    public GameObject playStatus;

    private float upRate = 0.5f;   // Խ����ԽҪ��
    private int loseTime = 10;   // ���ܴ�����ʤ��һ������


    /**
     *  ����
     *  �����������ƶѣ�����������
     *  ��������Ϊ����
     */
    public void Drop()
    {
        //GameObject playerBox = GameObject.Find("player/player0/player0box");
        GameObject[] handCard = new GameObject[playerBox.transform.childCount];

        // �õ��ӽڵ�gameObject
        for (int i = 0; i < handCard.Length; i++)
        {
            handCard[i] = playerBox.transform.GetChild(i).gameObject;
        }

        foreach (GameObject hand in handCard)
        {
            // �ŵ����ƶ�
            hand.transform.parent = GameObject.Find("dropBox").transform;
           // hand.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poker/back");
            hand.GetComponent<Card>().GetTargetPos = new Vector3(7, -4, 0);
        }

        playStatus.SendMessage("GiveUp");
        int leftPlayer = GameObject.Find("officer").GetComponent<CardManager>().GetLeftPlayer - 1;
        GameObject.Find("officer").GetComponent<CardManager>().GetLeftPlayer = leftPlayer;


    }


    /**
     *  ����
     */
    public void Up()
    {
        
    }


    /**
     *  ���Ʋ�������ע�� �ڼ�����ע
     *  ��ע��Ǯռ��ͷ�ʽ�ı���ԽС�����Ƶĸ���Խ�����Ҫ���Ĵ�
     */
    public void UpRateCount()
    {
        if (playStatus.GetComponent<PlayerStatus>().GetStay)
        {
            int money = playStatus.GetComponent<PlayerStatus>().GetMoney;

            // ��ȡ��ǰ��ע
            int betting = 100;

            int index = GameObject.Find("officer").GetComponent<CardManager>().GetIndexRound + 1;

            // ������ע���ռ�ȵĸ��Ƹ���
            float moneyRate = (money - (4f - index) * betting) / money;

            // todo �������ܴ�������һ�����Ҹ��ʣ���������С����
            float messRate = loseTime / 10f;

            float nowRate = Random.Range(0, 1f);

            // ����
            if (nowRate < moneyRate * upRate * messRate)
            {
                Up();
            }
            else   // ����
            {
                Drop();
            }
        }
        int indexPlayer = GameObject.Find("officer").GetComponent<CardManager>().GetIndexPlayer + 1;
        GameObject.Find("officer").GetComponent<CardManager>().GetIndexPlayer = indexPlayer;
    }


    /**
     *  �����һ���Ը�
     *  �����͡������͡��Ƚ���
     *  
     */
    private void RandomCharacter()
    {
        upRate = 0.5f;
    }


    // Start is called before the first frame update
    void Start()
    {
        RandomCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
