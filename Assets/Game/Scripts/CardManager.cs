using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 管理洗牌、初始发牌、弃牌
 */
public class CardManager : MonoBehaviour
{
    private Card card;   //定义一张牌类型的变量
    public GameObject cardBox;  //牌盒
    private List<Card> cardLibrary = new List<Card>();  //牌库 用来保存创建出来的所有牌
    private Queue<Card> cardQueue = new Queue<Card>();   //发牌堆，按顺序发牌

    public Button startButton;
    public Button dropButton;
    public Button upButton;

    public int playerNum = 6;
    private float speed = 0.3f;
    private int indexPlayer = 0;
    private int indexRound = 0;
    private int leftNum = 6;



    // 轮到哪位玩家
    public int GetIndexPlayer
    {
        set
        {
            indexPlayer = value;
        }
        get
        {
            return indexPlayer;
        }
    }


    // 当前是第几回合
    public int GetIndexRound
    {
        set
        {
            indexRound = value;
        }
        get
        {
            return indexRound;
        }
    }

    // 剩下几位玩家（仅单机判断）
    public int GetLeftPlayer
    {
        set
        {
            leftNum = value;
        }
        get
        {
            return leftNum;
        }
    }

    /**
     * 由于德扑并不需要大小王
     */

    // 创建一副牌
    public void CreateCard()
    {
        // for循环创建Card对象
        for (int i=2; i <= 14; i++)
        {
            for (int j=1; j <= 4; j++)
            {
                card = Instantiate(Resources.Load<Card>("Card")); //实例化预制牌
                card.gameObject.transform.position = GameObject.Find("cardBox").transform.position;
                card.gameObject.transform.rotation = Quaternion.identity;
                card.GetComponent<Card>().GetCardType = (CardType)j;   //牌的花色
                card.GetComponent<Card>().GetCardValue = i;  //牌的值
                // 牌的显示
                //card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poker/" + (CardType)j + i.ToString());
                card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poker/back");
                card.transform.parent = GameObject.Find("cardBox").transform;
                card.gameObject.SetActive(false); //禁用
                cardLibrary.Add(card); //存入牌库
            }
        }
    }

    // 洗牌
    public void Shuffle()
    {
        List<Card> tempLibrary = new List<Card>();
        foreach (var cards in cardLibrary)
        {
            int cardIndex = Random.Range(0, tempLibrary.Count + 1);  //随机下标
            tempLibrary.Insert(cardIndex, cards);  //把这张牌插入到指定位置
        }
        //cardLibrary.Clear();
        foreach (var cardss in tempLibrary)
        {
            cardQueue.Enqueue(cardss);
        }
        tempLibrary.Clear();
    }

    // 发牌  协程，在主程序运行时同时运行
    public IEnumerator Deal()
    {
        Card cards;
        cardBox.SetActive(true);  // 显示牌盒

        // playerNum数量的玩家，就发这么多个玩家的牌，发两轮
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < playerNum; j++)
            {
                cards = cardQueue.Dequeue();
                cards.gameObject.SetActive(true); //启用
                switch (j)
                {
                    case 0:
                        cards.transform.parent = GameObject.Find("player/player" + j.ToString() + "/player" + j.ToString() + "box").transform;
                        cards.GetTargetPos = new Vector3(-1.8f + 1.1f * i, -4, 0);
                        cards.GetOpenStatus = true;
                        break;
                    case 1:
                        cards.transform.parent = GameObject.Find("player/player" + j.ToString() + "/player" + j.ToString() + "box").transform;
                        cards.GetTargetPos = new Vector3(-8.5f + 0.3f * i, 0.5f, 0);
                        break;
                    case 2:
                        cards.transform.parent = GameObject.Find("player/player" + j.ToString() + "/player" + j.ToString() + "box").transform;
                        cards.GetTargetPos = new Vector3(-5.7f + 0.3f * i, 4, 0);
                        break;
                    case 3:
                        cards.transform.parent = GameObject.Find("player/player" + j.ToString() + "/player" + j.ToString() + "box").transform;
                        cards.GetTargetPos = new Vector3(0.3f + 0.3f * i, 4, 0);
                        break;
                    case 4:
                        cards.transform.parent = GameObject.Find("player/player" + j.ToString() + "/player" + j.ToString() + "box").transform;
                        cards.GetTargetPos = new Vector3(6.2f + 0.3f * i, 4, 0);
                        break;
                    case 5:
                        cards.transform.parent = GameObject.Find("player/player" + j.ToString() + "/player" + j.ToString() + "box").transform;
                        cards.GetTargetPos = new Vector3(7 + 0.3f * i, -1, 0);
                        break;
                }
                yield return new WaitForSeconds(speed);
            }
        }

        // 公共牌+弃牌
        for (int i = 0; i <= 7; i++)
        {
            cards = cardQueue.Dequeue();
            cards.gameObject.SetActive(true); //启用

            if (i == 0 || i == 4 || i == 6)
            {
                cards.transform.parent = GameObject.Find("dropBox").transform;
                cards.GetTargetPos = new Vector3(7, -4, 0);
            } 
            else if (i == 1)
            {
                cards.transform.parent = GameObject.Find("public/public1").transform;
                cards.GetTargetPos = new Vector3(-4, 0, 0);
            } 
            else if (i == 2)
            {
                cards.transform.parent = GameObject.Find("public/public1").transform;
                cards.GetTargetPos = new Vector3(-2, 0, 0);
            }
            else if (i == 3)
            {
                cards.transform.parent = GameObject.Find("public/public1").transform;
                cards.GetTargetPos = new Vector3(0, 0, 0);
            }
            else if (i == 5)
            {
                cards.transform.parent = GameObject.Find("public/public2").transform;
                cards.GetTargetPos = new Vector3(2, 0, 0);
            }
            else if (i == 7)
            {
                cards.transform.parent = GameObject.Find("public/public3").transform;
                cards.GetTargetPos = new Vector3(4, 0, 0);
                // 显示弃牌、叫牌按钮
                dropButton.gameObject.SetActive(true);
                upButton.gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(speed);
        }
    }


    // 调用发牌函数
    public void onDeal()
    {
        StartCoroutine(Deal());
        startButton.gameObject.SetActive(false);
    }



    /**
     *  打开公共区域盖牌
     *  index 第几张牌
     */
    public void ShowPublic(int index)
    {
        if (index > 3)
        {
            return;
        }
        else if (index == 3)
        {
            upButton.gameObject.SetActive(false);
        }

        GameObject publicBox = GameObject.Find("public/public" + index.ToString());
        GameObject[] publicCard = new GameObject[publicBox.transform.childCount];

        // 拿到子节点gameObject
        for (int i = 0; i < publicCard.Length; i++)
        {
            publicCard[i] = publicBox.transform.GetChild(i).gameObject;
        }

        foreach (GameObject pub in publicCard)
        {
            // 翻开 获取花色和点数
            pub.SendMessage("OpenCard");
        }
    }


    /**
     *  展示其他人的牌
     */
    public void ShowOtherCard()
    {
        int playerNum = 6;

        for (int i = 1; i < playerNum; i++)
        {
            GameObject playerBox = GameObject.Find("player" + i.ToString() + "/player" + i.ToString() + "box");
            if (playerBox.transform.childCount > 0)  // 还有手牌才展示
            {
                GameObject[] playerCard = new GameObject[playerBox.transform.childCount];

                // 拿到子节点gameObject
                for (int j = 0; j < playerCard.Length; j++)
                {
                    playerCard[j] = playerBox.transform.GetChild(j).gameObject;
                }

                foreach (GameObject handCard in playerCard)
                {
                    // 翻开
                    handCard.SendMessage("OpenCard");
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        CreateCard();
        Shuffle();
        startButton.onClick.AddListener(() => {
            onDeal();
        });
        dropButton.onClick.AddListener(() => {
            GameObject.Find("Canvas").SendMessage("Drop");
            //Drop();
        });

        upButton.onClick.AddListener(() => {
            if (indexRound < 3 && indexPlayer == 0)
            {
                indexPlayer++;
            }
            else
            {
                upButton.gameObject.SetActive(false);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (indexPlayer > 5)
        {
            // 重置玩家次序
            indexPlayer = 0;
            indexRound++;

            if (indexRound < 4)
            {
                ShowPublic(indexRound);
            } else
            {
                GameObject.Find("result").SendMessage("Win");
            }
            if (leftNum <= 1)
            {
                GameObject.Find("result").SendMessage("Win");
                return;
            }

        } else if (indexPlayer > 0)
        {
            GameObject.Find("player" + indexPlayer.ToString()).SendMessage("UpRateCount");
        }
    }
}
