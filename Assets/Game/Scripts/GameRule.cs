using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Level
{
    HIGH,   //高牌
    DOUBLE,  //一对
    DOUBLE_TWICE,  //两对
    THREE,   //三条
    SHUNZI,  //顺子
    HOMOGAMY,  //同花
    GOURD,   //葫芦
    FOUR,    //四条
    FLUSH,   //同花顺
    ROYAL_FLUSH,   //皇家同花顺
}


/**
 * 德扑的规则
 * 
 * 想把牌用二维数组表示
 */
public class GameRule : MonoBehaviour
{
    private int lv;   //牌的最高等级
    private ArrayList publicCardArr;  // 公共牌二维数组
    private int[] typeArr;  // 按照花色排序
    private int[] valueArr;  // 按照点数排序


    // 排序
    public void getLevel()
    {
        // todo 将七张牌放到array中

        // 公共牌
        publicCardArr = new ArrayList();
        GameObject publicCard = GameObject.Find("public1");

        // 拿到子节点gameObject
        for (int j = 0; j < publicCard.transform.childCount; j++)
        {
            GameObject pub = publicCard.transform.GetChild(j).gameObject;

            //publicCardArr.Add({ });
        }




    }


    // 选取选手手牌与场上五张公共牌组合，选出最大牌面
     



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
