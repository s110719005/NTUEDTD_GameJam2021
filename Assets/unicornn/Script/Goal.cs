using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log("in");
        if(other.tag=="player1"){
            FindObjectOfType<UIManager>().WinP1();
            Debug.Log("p1");
        }
        else if(other.tag=="player2"){
            FindObjectOfType<UIManager>().WinP2();

        }
    }
}
