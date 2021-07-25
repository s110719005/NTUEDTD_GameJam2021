using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="player1"){
            FindObjectOfType<AudioManager>().Play("win");
            FindObjectOfType<UIManager>().WinP1();
        }
        else if(other.tag=="player2"){
            FindObjectOfType<AudioManager>().Play("win");
            FindObjectOfType<UIManager>().WinP2();

        }
    }
}
