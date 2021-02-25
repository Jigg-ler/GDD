using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{

    public float wait_time = 7f;


    void Start()
    {
        StartCoroutine(intro_duration());
    }

    IEnumerator intro_duration()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene(1);
    }

}
