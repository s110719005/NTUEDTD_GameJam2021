using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrigger : MonoBehaviour
{
    [SerializeField]
    private int actionType = 0;
    // Start is called before the first frame update

    public void TriggerAction()
    {
        if (actionType == 20){

            //FindObjectOfType<UIManager>().ClosePanel();
            FindObjectOfType<MovementManager>().StartAction();
        }
        else if(actionType == 19)
            FindObjectOfType<MovementManager>().ClearAction();
        else
            FindObjectOfType<MovementManager>().AddAction(actionType);

    }
}
