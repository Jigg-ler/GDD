using System.Collections;	
using System.Collections.Generic;	
using UnityEngine;	
using UnityEngine.UI;	

public class GameOverScript : MonoBehaviour	
{	
    public Text pointsText;	

    // void Start(){
    //     gameObject.SetActive(false);
    // }
    public void Setup(int score){	
        Debug.Log("testste");
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "\nPOINTS";	
    }
}