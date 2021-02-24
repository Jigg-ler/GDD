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
    [Range(.5f, 4.0f)]
    public float baseSpeed;
    //////////////////////////////////////////
    [Range(3, 20)]    
    public int health;
    //////////////////////////////////////////
    [Range(0.4f, 1)]
    public float fireRate;
    #endregion

    System.Random rnd = new System.Random();
    float timer;

    void Start()
    {
        // baseSpeed = baseSpeed - 0.5f * tier;     
        // health =  health + (health * tier);
        // fireRate = fireRate + 0.5f * tier;

        //gets the script 'Score' of the game object 'scoreDisplay' and stores it as 'score'
        Score Score = GameObject.Find("scoreDisplay").GetComponent<Score>();

        //if (transform.tag == "ShootingEnemy"){
        if (bulletPrefab != null){
            //InvokeRepeating("function", seconds before start, interval in seconds)
            InvokeRepeating("ShootBullet", 0.5f, fireRate);
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
        //enemies have diff dimensions depending on their tier because of their transform.scale
        if (transform.position.z > ( 4 + (int)Math.Pow(3, tier) )){
            Destroy(gameObject);
        }
        #endregion
        #endregion

        //Debug.Log(direction);

    }
    void Die(){
        if (tier == 2){
            EnemySpawner spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
            new WaitForSeconds(3);
            spawner.bossInplay = false;
        }
        Destroy(gameObject);
    }

    void TakeDamage(int damage){
        health -= damage;

        if (health <= 0){

            //scoring || 100, 400, 1000
            Score.score += 100 + ( 100 * (int)Math.Pow(3, tier));
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
