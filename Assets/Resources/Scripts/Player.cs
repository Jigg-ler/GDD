using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameOverScript GameOverScript;
    public Score Score;

    public void GameOver()
    {
        GameOverScript.Setup(Score.score);
    }

    [SerializeField]
    Transform spawnSpot;
    [SerializeField]
    Bullet bulletPrefab;
    public Animator playerAnimator;

    [Header("Player Stats")]
    [Range(3.0f, 5.0f)]
    public float baseSpeed;
    [Range(2,5)]
    public int baseHealth;

    [Range(0.1f, 0.45f)]
    public float fireRate;
    public bool isVulnerable;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, 0);
       // playerStats = GetComponent<PlayerStats>();
       //Debug.Log(gameObject.tag);

        ShootBullet();
        //InvokeRepeating("function", seconds before start, interval in seconds)
        InvokeRepeating("ShootBullet", 0.5f, fireRate);

        playerAnimator = GetComponent<Animator>();
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
            transform.position = new Vector3(transform.position.x, transform.position.y, 1.5f);
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
        bulletGO.Init(Vector3.up, 5f, 1f, true);
    }

   void OnTriggerEnter(Collider collision) {
       if (collision.transform.tag == "Bullet" && isVulnerable)
        {
            Bullet bullet = collision.GetComponent<Bullet>();
           if (!bullet.isFromPlayer){
               Destroy(collision.gameObject);
               TakeDamage(bullet.GetDamage());
                //sets invulnerability with delay
               StartCoroutine(Invulnerable());
            }
        } 
       if (collision.transform.tag == "Enemy" && isVulnerable)
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
            //sets invulnerability with delay
            StartCoroutine(Invulnerable());
        }

        if (collision.transform.tag == "Boss" && isVulnerable)
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
            //sets invulnerability with delay
            StartCoroutine(Invulnerable());
        }
       
   }

    void TakeDamage(int damage){
        baseHealth -= damage;
        lifeDisplay.life -= 1;

        if (baseHealth <= 0){
            Destroy(gameObject);
            new WaitForSeconds(3);
            GameOver();
            Time.timeScale = 0f;
        }
    }
    //sets vulnerability to false and creates delay before setting the vulnerablity state to true again
    public IEnumerator Invulnerable()
    {
        isVulnerable = false;

        //triggers blinking animation for the player 
        playerAnimator.SetBool("isInvulnerable", true);
        //WaitForSeconds(delay in seconds)
        yield return new WaitForSeconds(3f);
        playerAnimator.SetBool("isInvulnerable", false);
        isVulnerable = true;
    }

}
