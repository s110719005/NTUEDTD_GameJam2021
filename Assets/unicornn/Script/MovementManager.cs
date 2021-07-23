using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementManager : MonoBehaviour
{
    
    private Queue<int> playerActions;
    private bool canPlayNext = false;
    private int action;
    // Start is called before the first frame update
    void Start()
    {
        playerActions = new Queue<int>();
    }
    public void AddAction(int actionType){
        playerActions.Enqueue(actionType);
        Debug.Log(playerActions.Count);
        //Action_MoveUp();
    }
    public void Action_MoveUp(){
        FindObjectOfType<PlayerMovement>().SetIsMoveUp(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
