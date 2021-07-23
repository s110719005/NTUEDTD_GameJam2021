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
    [SerializeField]
    private float moveDistance = 60.0f;

    private Vector3 newPosition = new Vector3(0,0,0);
    [SerializeField]
    private LayerMask obstacleLayer;
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
            newPosition = transform.position + new Vector3(0,moveDistance,0);
            if(!Physics2D.OverlapCircle(newPosition,0.2f,obstacleLayer))
                transform.position = Vector3.MoveTowards(transform.position,newPosition,moveDistance);

            isMoveUp = false;
        }
        else if(isMoveDown){
            newPosition = transform.position + new Vector3(0,-moveDistance,0);
            if(!Physics2D.OverlapCircle(newPosition,0.2f,obstacleLayer))
                transform.position = Vector3.MoveTowards(transform.position,newPosition,moveDistance);
            
            isMoveDown = false;
        }
        else if(isMoveRight){
            newPosition = transform.position + new Vector3(moveDistance,0,0);
            if(!Physics2D.OverlapCircle(newPosition,0.2f,obstacleLayer))
                transform.position = Vector3.MoveTowards(transform.position,newPosition,moveDistance);
            
            isMoveRight = false;
        }
        else if(isMoveLeft){
            newPosition = transform.position + new Vector3(-moveDistance,0,0);
            if(!Physics2D.OverlapCircle(newPosition,0.2f,obstacleLayer))
                transform.position = Vector3.MoveTowards(transform.position,newPosition,moveDistance);
            
            isMoveLeft = false;
        }
    }
    public void SetIsMoveUp(bool isUp){
        isMoveUp = isUp;
    }
    public void SetIsMoveDown(bool isDown){
        isMoveDown = isDown;
    }
    public void SetIsMoveRight(bool isRight){
        isMoveRight = isRight;
    }
    public void SetIsMoveLeft(bool isLeft){
        isMoveLeft = isLeft;
    }

    void MoveUpStart(){
        //isMoveUp = true;
        //Debug.Log("move up pressed!");
    }
    void MoveUpCanceled(){

    }
    void MoveDownStart(){
        //isMoveDown = true;
        //Debug.Log("move up pressed!");
    }
    void MoveDownCanceled(){

    }
    void MoveRightStart(){
        //isMoveRight = true;
        //Debug.Log("move up pressed!");
    }
    void MoveRightCanceled(){

    }
    void MoveLeftStart(){
        //isMoveLeft = true;
        //Debug.Log("move up pressed!");
    }
    void MoveLeftCanceled(){

    }
}
