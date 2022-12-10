using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserAction : MonoBehaviour
{
    public Button dropButton;
    public Button upButton;

    

    /**
     *  ����
     *  �����������ƶѣ�����������
     *  ��������Ϊ����
     */
    public void Drop()
    {
        GameObject playerBox = GameObject.Find("player/player0/player0box");
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
            hand.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("poker/back");
            hand.GetComponent<Card>().GetTargetPos = new Vector3(7, -4, 0);
        }

        dropButton.gameObject.SetActive(false);
        GameObject.Find("result").SendMessage("Lose");
        GameObject.Find("player0/userInfo").SendMessage("GiveUp");
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
