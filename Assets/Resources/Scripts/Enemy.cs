using System;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    int baseSpeed = 2;
    System.Random rnd = new System.Random();
    float timer;
    int direction = 0;
    int prevDirection;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region movement
        if (timer > 2){
            timer = 0;
            prevDirection = direction;
            direction = rnd.Next(-1,2);
            while (prevDirection == direction){
                direction = rnd.Next(-1,2);
            }
        }
        else{
            timer += Time.deltaTime;
        }

        #region bounds
        if (transform.position.z > 5 || transform.position.z < -5){
            direction = -direction;
        }
        transform.position += new Vector3((-1 * Time.deltaTime) * baseSpeed, 0, (direction * Time.deltaTime) * baseSpeed);
        if (transform.position.x < -8){
            Destroy(gameObject);
        }
        #endregion
        #endregion

        //Debug.Log(direction);

    }

    void OnTriggerEnter(Collider collision) {

        if (collision.gameObject.tag == "Player"){
            Debug.Log("BOOMYHAHA");
            Destroy(gameObject);
        }
    }
}
