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

            FindObjectOfType<UIManager>().ClosePanel();
            MovementManager.Instance.StartAction();
        }
        else if(actionType == 19)
            MovementManager.Instance.ClearAction();
        else
            MovementManager.Instance.AddAction(actionType);

    }
}
