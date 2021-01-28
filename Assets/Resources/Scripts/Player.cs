using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        #region movement
        if (Input.GetKey("w")){
            transform.position += new Vector3((1 * Time.deltaTime) * speed, 0, 0);
        }

        if (Input.GetKey("s")){
            transform.position += new Vector3((-1 * Time.deltaTime) * speed, 0, 0);
        }

        if (Input.GetKey("a")){
            transform.position += new Vector3(0, 0, (1 * Time.deltaTime) * speed);
        }

        if (Input.GetKey("d")){
            transform.position += new Vector3(0, 0, (-1 * Time.deltaTime) * speed);
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
    }
}
