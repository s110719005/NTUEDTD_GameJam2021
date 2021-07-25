using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerMovement : MonoBehaviour
{
    InputManager controls;
    private bool isMoveUp = false;
    private bool isMoveDown = false;
    private bool isMoveLeft = false;
    private bool isMoveRight = false;
    [SerializeField] private float moveDuration = 1.0f;
    [SerializeField] private float hitDuration = 0.2f;
    [SerializeField] private float moveDistance = 60.0f;
    [SerializeField] private Vector3 startPostion = new Vector3(0, 0, 0);
    private Vector3 newPosition = new Vector3(0, 0, 0);
    private Vector3 hitPosition = new Vector3(0, 0, 0);
    private Vector3 originPosition = new Vector3(0, 0, 0);
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private Ease playerMoveEase = Ease.Linear;
    [SerializeField] private Ease playerHitEase = Ease.Linear;
    [SerializeField] private Ease playerHitEase2 = Ease.Linear;

    //Animation
    Animator _animator;
    private int currentAnimationState;

    private int animationIdle;
    private int animationWalkLeft;
    private int animationWalkRight;
    private int animationWalkUp;
    private int animationWalkDown;
    private float playerWalkDelay;

    void Awake()
    {

        _animator = GetComponentInChildren<Animator>();
        animationIdle = Animator.StringToHash("Player_Idle");
        animationWalkLeft = Animator.StringToHash("Player_Walk_Left");
        animationWalkRight = Animator.StringToHash("Player_Walk_Right");
        animationWalkUp = Animator.StringToHash("Player_Walk_Up");
        animationWalkDown = Animator.StringToHash("Player_Walk_Down");

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

    void ChangeAnimationState(int newAnimationState)
    {
        if (newAnimationState == currentAnimationState)
        {
            return; //一樣的話就不重新開始播ㄌ
        }
        _animator.Play(newAnimationState);

        currentAnimationState = newAnimationState;
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(startPostion, MovementManager.Instance.GameStartDelay).SetEase(playerMoveEase);
        ChangeAnimationState(animationWalkRight);
        Invoke("PlayIdleAnimation", MovementManager.Instance.GameStartDelay);//走路的動畫播一段時間才切回idle
        FindObjectOfType<AudioManager>().Play("playerWalk");
        Invoke("StopPlayerWalkAudio", MovementManager.Instance.GameStartDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveUp)
        {
            originPosition = transform.position;
            newPosition = transform.position + new Vector3(0, moveDistance, 0);
            hitPosition = transform.position + new Vector3(0, moveDistance * 0.2f, 0);
            if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleLayer))
            {
                transform.DOMove(newPosition, moveDuration).SetEase(playerMoveEase);
                ChangeAnimationState(animationWalkUp);
                Invoke("PlayIdleAnimation", moveDuration);//走路的動畫播一段時間才切回idle
                //audio
                FindObjectOfType<AudioManager>().Play("playerWalk");
                Invoke("StopPlayerWalkAudio", moveDuration);
            }
            //transform.position = Vector3.MoveTowards(transform.position,newPosition,moveDistance);
            else
            {
                DOTween.Sequence()
                .Append(transform.DOMove(hitPosition, hitDuration).SetEase(playerHitEase))
                .Append(transform.DOMove(originPosition, hitDuration).SetEase(playerHitEase2));
                FindObjectOfType<AudioManager>().Play("playerHitWall");
                ChangeAnimationState(animationWalkUp);
                Invoke("PlayIdleAnimation", hitDuration);//走路的動畫播一段時間才切回idle
            }
            isMoveUp = false;
        }
        else if (isMoveDown)
        {
            originPosition = transform.position;
            newPosition = transform.position + new Vector3(0, -moveDistance, 0);
            hitPosition = transform.position + new Vector3(0, -moveDistance * 0.2f, 0);
            if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleLayer))
            {
                transform.DOMove(newPosition, moveDuration).SetEase(playerMoveEase);
                ChangeAnimationState(animationWalkDown);
                Invoke("PlayIdleAnimation", moveDuration);//走路的動畫播一段時間才切回idle
                //audio
                FindObjectOfType<AudioManager>().Play("playerWalk");
                Invoke("StopPlayerWalkAudio", moveDuration);
            }
            else
            {
                DOTween.Sequence()
                .Append(transform.DOMove(hitPosition, hitDuration).SetEase(playerHitEase))
                .Append(transform.DOMove(originPosition, hitDuration).SetEase(playerHitEase2));
                FindObjectOfType<AudioManager>().Play("playerHitWall");
                ChangeAnimationState(animationWalkDown);
                Invoke("PlayIdleAnimation", hitDuration);
            }
            isMoveDown = false;
        }
        else if (isMoveRight)
        {
            originPosition = transform.position;
            newPosition = transform.position + new Vector3(moveDistance, 0, 0);
            hitPosition = transform.position + new Vector3(moveDistance * 0.2f, 0, 0);
            if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleLayer))
            {
                transform.DOMove(newPosition, moveDuration).SetEase(playerMoveEase);
                ChangeAnimationState(animationWalkRight);
                Invoke("PlayIdleAnimation", moveDuration);//走路的動畫播一段時間才切回idle
                //audio
                FindObjectOfType<AudioManager>().Play("playerWalk");
                Invoke("StopPlayerWalkAudio", moveDuration);
            }
            else
            {
                DOTween.Sequence()
                .Append(transform.DOMove(hitPosition, hitDuration).SetEase(playerHitEase))
                .Append(transform.DOMove(originPosition, hitDuration).SetEase(playerHitEase2));
                FindObjectOfType<AudioManager>().Play("playerHitWall");
                ChangeAnimationState(animationWalkRight);
                Invoke("PlayIdleAnimation", hitDuration);//走路的動畫播一段時間才切回idle
            }
            isMoveRight = false;
        }
        else if (isMoveLeft)
        {
            originPosition = transform.position;
            newPosition = transform.position + new Vector3(-moveDistance, 0, 0);
            hitPosition = transform.position + new Vector3(-moveDistance * 0.2f, 0, 0);
            if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleLayer))
            {
                transform.DOMove(newPosition, moveDuration).SetEase(playerMoveEase);
                ChangeAnimationState(animationWalkLeft);
                Invoke("PlayIdleAnimation", moveDuration);//走路的動畫播一段時間才切回idle
                //audio
                FindObjectOfType<AudioManager>().Play("playerWalk");
                Invoke("StopPlayerWalkAudio", moveDuration);
            }
            else
            {
                DOTween.Sequence()
                .Append(transform.DOMove(hitPosition, hitDuration).SetEase(playerHitEase))
                .Append(transform.DOMove(originPosition, hitDuration).SetEase(playerHitEase2));
                FindObjectOfType<AudioManager>().Play("playerHitWall");
                ChangeAnimationState(animationWalkLeft);
                Invoke("PlayIdleAnimation", hitDuration);//走路的動畫播一段時間才切回idle
            }

            isMoveLeft = false;
        }
    }

    void PlayIdleAnimation()
    {
        ChangeAnimationState(animationIdle);
    }
    void StopPlayerWalkAudio()
    {
        FindObjectOfType<AudioManager>().Stop("playerWalk");
    }
    public void SetIsMoveUp(bool isUp)
    {
        isMoveUp = isUp;
    }
    public void SetIsMoveDown(bool isDown)
    {
        isMoveDown = isDown;
    }
    public void SetIsMoveRight(bool isRight)
    {
        isMoveRight = isRight;
    }
    public void SetIsMoveLeft(bool isLeft)
    {
        isMoveLeft = isLeft;
    }

    void MoveUpStart()
    {
        //isMoveUp = true;
        //Debug.Log("move up pressed!");
    }
    void MoveUpCanceled()
    {

    }
    void MoveDownStart()
    {
        //isMoveDown = true;
        //Debug.Log("move up pressed!");
    }
    void MoveDownCanceled()
    {

    }
    void MoveRightStart()
    {
        //isMoveRight = true;
        //Debug.Log("move up pressed!");
    }
    void MoveRightCanceled()
    {

    }
    void MoveLeftStart()
    {
        //isMoveLeft = true;
        //Debug.Log("move up pressed!");
    }
    void MoveLeftCanceled()
    {

    }
}
