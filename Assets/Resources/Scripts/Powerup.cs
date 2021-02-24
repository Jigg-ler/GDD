using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Powerup Effect")]
    [Tooltip("1 = Life, 2 = Damage, 3 = Fire Rate, 4 = Speed")]
    [Range(1,4)]
    public int powerupType;

    [Header("GUI Elements to be Modified")]
    [SerializeField]
    lifeDisplay lifeDisplay;
    //[SerializeField]
    //coinsDisplay

    int damage;

    void Start()
    {
        //Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        // player.baseHealth += 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.down * 1.5f * Time.deltaTime);
        if (transform.position.z > 3){
            Destroy(gameObject);
        }
    }

    public void Effect(Player player)
    {
        Debug.Log("najfsaiofmafas");
        switch (powerupType)
        {
            //LIFE
            case 1:
                player.baseHealth += 1;
                lifeDisplay.life += 1;
                break;
            //DAMAGE
            case 2:
                damage = player.bulletPrefab.GetDamage();
                player.bulletPrefab.SetDamage(damage + 1);
                break;
            //FIRE RATE
            case 3:
                player.fireRate -= .5f;
                break;
            //SPEED
            case 4:
                player.baseSpeed += .3f;
                break;
            
        }

        //insert sfx
    }
}
