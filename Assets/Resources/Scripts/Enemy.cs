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
    int baseSpeed = 2;
    System.Random rnd = new System.Random();
    float timer;
    int direction = 0;
    int prevDirection;
    int health = 100;

    void Start()
    {
        //InvokeRepeating("function", seconds before start, interval in seconds)
        InvokeRepeating("ShootBullet", 0.5f, .8f);
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
    void Die(){
        Destroy(gameObject);
    }

    void TakeDamage(int damage){
        health -= damage;

        if (health <= 0){
            Die();
        }
    }

    void OnTriggerEnter(Collider collision) {

        if (collision.CompareTag("Bullet")){
            Bullet bullet = collision.GetComponent<Bullet>();
            if (bullet.isFromPlayer){
                TakeDamage(bullet.GetDamage());
            }
        }
    }

    void ShootBullet(){
        Bullet bulletGO = Instantiate(bulletPrefab);
        bulletGO.transform.position = spawnSpot.position;
        //parameters (direction, speed, scale, boolean isFromPlayer)
        bulletGO.Init(Vector2.down, 5f, 0.15f, false);
    }
}
