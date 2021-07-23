using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager controls;
    private bool isMoveUp = false;
    private bool isMoveDown = false;
    private bool isMoveLeft = false;
    private bool isMoveRight = false;
    [SerializeField]
    private float moveSpeed = 5.0f;
    void Awake(){
        controls = new InputManager();
        
            //角色移動
            controls.Player.Move_Up.performed += ctx => MoveUpStart();
            controls.Player.Move_Up.canceled += ctx => MoveUpCanceled();

            controls.Player.Move_Down.performed += ctx => MoveDownStart();
            controls.Player.Move_Down.canceled += ctx => MoveDownCanceled();

            controls.Player.Move_Right.performed += ctx => MoveRightStart();
            controls.Player.Move_Right.canceled += ctx => MoveRightCanceled();

            controls.Player.Move_Left.performed += ctx => MoveLeftStart();
            controls.Player.Move_Left.canceled += ctx => MoveLeftCanceled();

            
    }
    void OnEnable()
    {
        controls.Player.Enable();
    }
    void OnDisable()
    {
        controls.Player.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoveUp){
            transform.position += new Vector3(0,moveSpeed * Time.deltaTime,0);
            isMoveUp = false;
        }
        else if(isMoveDown){
            transform.position += new Vector3(0,-moveSpeed * Time.deltaTime,0);
            isMoveDown = false;
        }
        else if(isMoveRight){
            transform.position += new Vector3(moveSpeed * Time.deltaTime,0,0);
            isMoveRight = false;
        }
        else if(isMoveLeft){
            transform.position += new Vector3(-moveSpeed * Time.deltaTime,0,0);
            isMoveLeft = false;
        }
    }

    void MoveUpStart(){
        isMoveUp = true;
        //Debug.Log("move up pressed!");
    }
    void MoveUpCanceled(){

    }
    void MoveDownStart(){
        isMoveDown = true;
        //Debug.Log("move up pressed!");
    }
    void MoveDownCanceled(){

    }
    void MoveRightStart(){
        isMoveRight = true;
        //Debug.Log("move up pressed!");
    }
    void MoveRightCanceled(){

    }
    void MoveLeftStart(){
        isMoveLeft = true;
        //Debug.Log("move up pressed!");
    }
    void MoveLeftCanceled(){

    }
}
