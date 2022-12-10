using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * ����ϴ�ơ���ʼ���ơ�����
 */
public class CardManager : MonoBehaviour
{
    private Card card;   //����һ�������͵ı���
    public GameObject cardBox;  //�ƺ�
    private List<Card> cardLibrary = new List<Card>();  //�ƿ� �������洴��������������
    private Queue<Card> cardQueue = new Queue<Card>();   //���ƶѣ���˳����

    public Button startButton;
    public Button dropButton;
    public Button upButton;

    public int playerNum = 6;
    private float speed = 0.3f;
    private int indexPlayer = 0;
    private int indexRound = 0;
    private int leftNum = 6;



    // �ֵ���λ���
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


    // ��ǰ�ǵڼ��غ�
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

    // ʣ�¼�λ��ң��������жϣ�
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
     * ���ڵ��˲�����Ҫ��С��
     */

    // ����һ����
    public void CreateCard()
    {
        // forѭ������Card����
        for (int i=2; i <= 14; i++)
        {
            for (int j=1; j <= 4; j++)
            {
                card = Instantiate(Resources.Load<Card>("Card")); //ʵ����Ԥ����
                card.gameObject.transform.position = GameObject.Find("cardBox").transform.position;
                card.gameObject.transform.rotation = Quaternion.identity;
                card.GetComponent<Card>().GetCardType = (CardType)j;   //�ƵĻ�ɫ
                card.GetComponent<Card>().GetCardValue = i;  //�Ƶ�ֵ
                // �Ƶ���ʾ
                //card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poker/" + (CardType)j + i.ToString());
                card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poker/back");
                card.transform.parent = GameObject.Find("cardBox").transform;
                card.gameObject.SetActive(false); //����
                cardLibrary.Add(card); //�����ƿ�
            }
        }
    }

    // ϴ��
    public void Shuffle()
    {
        List<Card> tempLibrary = new List<Card>();
        foreach (var cards in cardLibrary)
        {
            int cardIndex = Random.Range(0, tempLibrary.Count + 1);  //����±�
            tempLibrary.Insert(cardIndex, cards);  //�������Ʋ��뵽ָ��λ��
        }
        //cardLibrary.Clear();
        foreach (var cardss in tempLibrary)
        {
            cardQueue.Enqueue(cardss);
        }
        tempLibrary.Clear();
    }

    // ����  Э�̣�������������ʱͬʱ����
    public IEnumerator Deal()
    {
        Card cards;
        cardBox.SetActive(true);  // ��ʾ�ƺ�

        // playerNum��������ң��ͷ���ô�����ҵ��ƣ�������
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < playerNum; j++)
            {
                cards = cardQueue.Dequeue();
                cards.gameObject.SetActive(true); //����
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

        // ������+����
        for (int i = 0; i <= 7; i++)
        {
            cards = cardQueue.Dequeue();
            cards.gameObject.SetActive(true); //����

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
                // ��ʾ���ơ����ư�ť
                dropButton.gameObject.SetActive(true);
                upButton.gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(speed);
        }
    }


    // ���÷��ƺ���
    public void onDeal()
    {
        StartCoroutine(Deal());
        startButton.gameObject.SetActive(false);
    }



    /**
     *  �򿪹����������
     *  index �ڼ�����
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

        // �õ��ӽڵ�gameObject
        for (int i = 0; i < publicCard.Length; i++)
        {
            publicCard[i] = publicBox.transform.GetChild(i).gameObject;
        }

        foreach (GameObject pub in publicCard)
        {
            // ���� ��ȡ��ɫ�͵���
            pub.SendMessage("OpenCard");
        }
    }


    /**
     *  չʾ�����˵���
     */
    public void ShowOtherCard()
    {
        int playerNum = 6;

        for (int i = 1; i < playerNum; i++)
        {
            GameObject playerBox = GameObject.Find("player" + i.ToString() + "/player" + i.ToString() + "box");
            if (playerBox.transform.childCount > 0)  // �������Ʋ�չʾ
            {
                GameObject[] playerCard = new GameObject[playerBox.transform.childCount];

                // �õ��ӽڵ�gameObject
                for (int j = 0; j < playerCard.Length; j++)
                {
                    playerCard[j] = playerBox.transform.GetChild(j).gameObject;
                }

                foreach (GameObject handCard in playerCard)
                {
                    // ����
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
            // ������Ҵ���
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
