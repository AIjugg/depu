using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAction : MonoBehaviour
{
    // 手牌
    public GameObject playerBox;

    // 游戏状态
    public GameObject playStatus;

    private float upRate = 0.5f;   // 越激进越要上
    private int loseTime = 10;   // 连败次数，胜利一次清零


    /**
     *  弃牌
     *  将牌移入弃牌堆，并结束比赛
     *  联机则标记为放弃
     */
    public void Drop()
    {
        //GameObject playerBox = GameObject.Find("player/player0/player0box");
        GameObject[] handCard = new GameObject[playerBox.transform.childCount];

        // 拿到子节点gameObject
        for (int i = 0; i < handCard.Length; i++)
        {
            handCard[i] = playerBox.transform.GetChild(i).gameObject;
        }

        foreach (GameObject hand in handCard)
        {
            // 放到弃牌堆
            hand.transform.parent = GameObject.Find("dropBox").transform;
           // hand.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poker/back");
            hand.GetComponent<Card>().GetTargetPos = new Vector3(7, -4, 0);
        }

        playStatus.SendMessage("GiveUp");
        int leftPlayer = GameObject.Find("officer").GetComponent<CardManager>().GetLeftPlayer - 1;
        GameObject.Find("officer").GetComponent<CardManager>().GetLeftPlayer = leftPlayer;


    }


    /**
     *  跟牌
     */
    public void Up()
    {
        
    }


    /**
     *  叫牌操作（下注） 第几次下注
     *  下注的钱占手头资金的比例越小，跟牌的概率越大，最多要跟四次
     */
    public void UpRateCount()
    {
        if (playStatus.GetComponent<PlayerStatus>().GetStay)
        {
            int money = playStatus.GetComponent<PlayerStatus>().GetMoney;

            // 获取当前下注
            int betting = 100;

            int index = GameObject.Find("officer").GetComponent<CardManager>().GetIndexRound + 1;

            // 根据下注金额占比的跟牌概览
            float moneyRate = (money - (4f - index) * betting) / money;

            // todo 根据连败次数生成一个混乱概率（必须是正小数）
            float messRate = loseTime / 10f;

            float nowRate = Random.Range(0, 1f);

            // 跟牌
            if (nowRate < moneyRate * upRate * messRate)
            {
                Up();
            }
            else   // 不跟
            {
                Drop();
            }
        }
        int indexPlayer = GameObject.Find("officer").GetComponent<CardManager>().GetIndexPlayer + 1;
        GameObject.Find("officer").GetComponent<CardManager>().GetIndexPlayer = indexPlayer;
    }


    /**
     *  随机出一种性格
     *  保守型、激进型、稳健型
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
