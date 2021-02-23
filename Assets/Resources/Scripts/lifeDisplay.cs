using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeDisplay : MonoBehaviour
{
        // Start is called before the first frame update

    public static int life;
    private Text display;
    void Start()
    {
        life = 1;
        display = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Floors life to zero
        life = Math.Max(0, life);
        display.text = life.ToString();
    }
}
