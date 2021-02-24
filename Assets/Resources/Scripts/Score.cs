using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    public static int score = 0;
    public Text display;
    
    public void Setup(int score){
        gameObject.SetActive(true);
    }

    void Start()
    {
        score = 0;
        display = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Max Score is 999999999
        score = Math.Min(999999999, score);
        display.text = score.ToString();
    }
}
