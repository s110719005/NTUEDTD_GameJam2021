using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrigger : MonoBehaviour
{
    [SerializeField]
    private int actionType = 0;
    // Start is called before the first frame update
    
    public void TriggerAction(){
        FindObjectOfType<MovementManager>().AddAction(actionType);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
