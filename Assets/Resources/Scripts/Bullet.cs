using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float speed;

    int damage = 1;

    Vector3 dir;
    public bool isFromPlayer;

    public void Init(Vector3 myDir, float mySpeed, float scale, bool __isFromPlayer){
        dir = myDir;
        speed = mySpeed;
        transform.localScale *= scale;
        isFromPlayer = __isFromPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (dir * speed * Time.deltaTime);
        //deletes a bullet if out of bounds
        if (transform.position.z >= 2.5f || transform.position.z <= -8){
            Destroy(gameObject);
        }
    }

    public int GetDamage(){
        return damage;
    }

    public void SetDamage(int val){
        damage = val;
    }
}
