using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PLAYER" )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
        }

    }
}
