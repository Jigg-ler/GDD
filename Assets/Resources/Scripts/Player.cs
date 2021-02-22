using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    Transform spawnSpot;
    [SerializeField]
    Bullet bulletPrefab;

    [Header("Player Stats")]
    [Range(3.0f, 5.0f)]
    public float baseSpeed;
    [Range(2,5)]
    public int baseHealth;

    [Range(0.2f, 0.5f)]
    public float fireRate;

    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, 0);
       // playerStats = GetComponent<PlayerStats>();
       //Debug.Log(gameObject.tag);

        ShootBullet();
        //InvokeRepeating("function", seconds before start, interval in seconds)
        InvokeRepeating("ShootBullet", 0.5f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        #region movement
        if (Input.GetKey("w")){
            transform.position += new Vector3(0, 0, (-1 * Time.deltaTime) * baseSpeed);
        }

        if (Input.GetKey("s")){
            transform.position += new Vector3(0, 0, (1 * Time.deltaTime) * baseSpeed);
        }

        if (Input.GetKey("a")){
            transform.position += new Vector3((1 * Time.deltaTime) * baseSpeed, 0, 0);
        }

        if (Input.GetKey("d")){
            transform.position += new Vector3((-1 * Time.deltaTime) * baseSpeed, 0, 0);
        }
        #endregion

        #region bounds
        if (transform.position.x > 2.4f){
            transform.position = new Vector3(2.4f, transform.position.y, transform.position.z);
        }   
        if (transform.position.x < -2.4f){
            transform.position = new Vector3(-2.4f, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 1.5f){
            transform.position = new Vector3(transform.position.x, transform.position.y, -1.5f);
        }
        if (transform.position.z < -6.5f){
            transform.position = new Vector3(transform.position.x, transform.position.y, -6.5f);
        }
        #endregion
        
        //Debug.Log(transform.position.z);
    }
    void ShootBullet(){
        Bullet bulletGO = Instantiate(bulletPrefab);
        bulletGO.transform.position = spawnSpot.position;
        //parameters (direction, speed, scale, boolean isFromPlayer)
        bulletGO.Init(Vector3.down, 5f, 0.15f, true);
    }
}
