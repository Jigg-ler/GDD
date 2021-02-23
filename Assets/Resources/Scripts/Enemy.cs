using System;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform spawnSpot;
    [SerializeField]
    Bullet bulletPrefab;

    // Start is called before the first frame update
    #region Stats
    [Header("Enemy Stats")]
    //////////////////////////////////////////
    [Range(0,2)]
    public int tier;
    //////////////////////////////////////////  
    [Range(1.0f, 4.0f)]
    public float baseSpeed;
    //////////////////////////////////////////
    [Range(90,150)]    
    public int health;
    //////////////////////////////////////////
    [Range(0.2f, 0.5f)]
    public float fireRate;
    #endregion

    System.Random rnd = new System.Random();
    float timer;
    int prevDirection;

    void Start()
    {
        baseSpeed = baseSpeed - 0.5f * tier;
        health = health + (health / 2 * tier);
        fireRate = fireRate + 0.5f * tier;

        if (transform.tag == "ShootingEnemy"){
            //InvokeRepeating("function", seconds before start, interval in seconds)
            InvokeRepeating("ShootBullet", 0.5f, 0.8f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        #region movement
        // if (timer > 2){
        //     timer = 0;
        //     prevDirection = direction;
        //     direction = rnd.Next(-1,2);
        //     while (prevDirection == direction){
        //         direction = rnd.Next(-1,2);
        //     }
        // }
        // else{
        //     timer += Time.deltaTime;
        // }

        #region bounds
        transform.Translate (Vector3.forward * baseSpeed * Time.deltaTime);
        if (transform.position.z > 5){
            Destroy(gameObject);
        }
        #endregion
        #endregion

        //Debug.Log(direction);

    }
    void Die(){
        Destroy(gameObject);
    }

    void TakeDamage(int damage){
        Debug.Log(health);
        health -= damage;

        if (health <= 0){
            Die();
        }
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.transform.tag == "Bullet"){
            Bullet bullet = collision.GetComponent<Bullet>();
            if (bullet.isFromPlayer){
                Destroy(collision.gameObject);
                TakeDamage(bullet.GetDamage());
            }
            
        }
    }

    void ShootBullet(){
        Bullet bulletGO = Instantiate(bulletPrefab);
        bulletGO.transform.position = spawnSpot.position;
        //parameters (direction, speed, scale, boolean isFromPlayer)
        bulletGO.Init(Vector3.up, 5f, 1f, false);
    }
}
