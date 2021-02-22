using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float speed;

    Vector2 dir;
    public bool isFromPlayer;

    public void Init(Vector2 myDir, float mySpeed, float scale, bool __isFromPlayer){
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
        if (transform.position.x >= 20f){
            Destroy(gameObject);
        }
    }
}
