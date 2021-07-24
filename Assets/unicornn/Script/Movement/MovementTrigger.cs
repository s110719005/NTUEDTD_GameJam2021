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
        if (actionType == 20)
            FindObjectOfType<MovementManager>().StartAction();
        else
            FindObjectOfType<MovementManager>().AddAction(actionType);

    }
}
