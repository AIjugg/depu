using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;

    public void Win()
    {
        win.gameObject.SetActive(true);
    }


    public void Lose()
    {
        lose.gameObject.SetActive(true);
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
