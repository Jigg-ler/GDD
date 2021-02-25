using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject[] players;
    private GameObject player;

    // public GameOverScript GameOverScript;
    // public Score Score;

    // Start is called before the first frame update
    void Start()
    {
        //randomizes the player's avatar per session
        player = players[Random.Range(0,players.Length)];
        if (player.name == "avatar_1"){
            Instantiate(player, new Vector3(0, 0, 0),
						Quaternion.identity);
        }
        else if (player.name == "avatar_2"){
            Instantiate(player, new Vector3(-1.88f, 0, 0),
						Quaternion.identity);
        }
        else if (player.name == "avatar_3"){
            Instantiate(player, new Vector3(1.85f, 0, 0),
						Quaternion.identity);
        }
        //player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
