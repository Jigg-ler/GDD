using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Range(3.0f, 5.0f)]
    public float baseSpeed;
    [Range(2,5)]
    public int baseHealth;

    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, 2);
       // playerStats = GetComponent<PlayerStats>();
       //Debug.Log(gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {
        #region movement
        if (Input.GetKey("w")){
            transform.position += new Vector3((1 * Time.deltaTime) * baseSpeed, 0, 0);
        }

        if (Input.GetKey("s")){
            transform.position += new Vector3((-1 * Time.deltaTime) * baseSpeed, 0, 0);
        }

        if (Input.GetKey("a")){
            transform.position += new Vector3(0, 0, (1 * Time.deltaTime) * baseSpeed);
        }

        if (Input.GetKey("d")){
            transform.position += new Vector3(0, 0, (-1 * Time.deltaTime) * baseSpeed);
        }
        #endregion

        #region bounds
        if (transform.position.x > 5.4f){
            transform.position = new Vector3(5.4f, transform.position.y, transform.position.z);
        }   
        if (transform.position.x < -1.5f){
            transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -5){
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }
        if (transform.position.z > 5){
            transform.position = new Vector3(transform.position.x, transform.position.y, 5);
        }
        #endregion
        
        //Debug.Log(transform.position.z);
    }
}
