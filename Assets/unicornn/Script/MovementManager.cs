using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SkillSystem;
public class MovementManager : MonoBehaviour
{
    static MovementManager instance = null;
    public static MovementManager Instance
    {
        get { return instance ?? (instance = FindObjectOfType(typeof(MovementManager)) as MovementManager); }
    }
    private void Awake()
    {
        instance = MovementManager.Instance;
        if (instance == null) instance = this as MovementManager;
        if (instance == this) DontDestroyOnLoad(this);
        else DestroyImmediate(this);
    }

    private Queue<int> playerActions;
    private bool canPlayNext = false;
    private float playNextTimer = 0;
    private bool openPlayNextTimer = false;
    private int action;
    private bool isStart = false;
    private int currentAction;
    [SerializeField]
    private float playNextDelay = 2.0f;
    public GameObject Player1;
    public GameObject Player2;
    public int currentRound = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerActions = new Queue<int>();
    }
    public void AddAction(int actionType)
    {
        playerActions.Enqueue(actionType);
        Debug.Log(playerActions.Count);
        //Action_MoveUp();
    }
    public void StartAction()
    {
        isStart = true;
    }
    public void Action_MoveUp()
    {
        FindObjectOfType<PlayerMovement>().SetIsMoveUp(true);
    }

    void ActionSwitch(int actionType)
    {
        if (currentRound == 1)
        {
            switch (actionType)
            {
                case 0:
                    //FindObjectOfType<PlayerMovement>().SetIsMoveUp(true);
                    Player1.GetComponent<PlayerMovement>().SetIsMoveUp(true);
                    Debug.Log(playerActions.Count);
                    break;
                case 1:
                    Player1.GetComponent<PlayerMovement>().SetIsMoveDown(true);
                    Debug.Log(playerActions.Count);
                    break;
                case 2:
                    Player1.GetComponent<PlayerMovement>().SetIsMoveRight(true);
                    Debug.Log(playerActions.Count);
                    break;
                case 3:
                    Player1.GetComponent<PlayerMovement>().SetIsMoveLeft(true);
                    Debug.Log(playerActions.Count);
                    break;
                case 4:
                    SkillManager.Instance.TriggerSkill(0);
                    break;


                default:
                    break;
            }
        }
        else if (currentRound == 2)
        {
            switch (actionType)
            {
                case 0:
                    //FindObjectOfType<PlayerMovement>().SetIsMoveUp(true);
                    Player2.GetComponent<PlayerMovement>().SetIsMoveUp(true);
                    Debug.Log(playerActions.Count);
                    break;
                case 1:
                    Player2.GetComponent<PlayerMovement>().SetIsMoveDown(true);
                    Debug.Log(playerActions.Count);
                    break;
                case 2:
                    Player2.GetComponent<PlayerMovement>().SetIsMoveRight(true);
                    Debug.Log(playerActions.Count);
                    break;
                case 3:
                    Player2.GetComponent<PlayerMovement>().SetIsMoveLeft(true);
                    Debug.Log(playerActions.Count);
                    break;
                case 4:
                    SkillManager.Instance.TriggerSkill(0);
                    break;
                default:
                    break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerActions.Count != 0)
        {
            if (isStart)
            {
                isStart = false;
                openPlayNextTimer = true;
                currentAction = playerActions.Dequeue();
                ActionSwitch(currentAction);
            }
            else if (canPlayNext)
            {
                canPlayNext = false;
                currentAction = playerActions.Dequeue();
                ActionSwitch(currentAction);
                if (playerActions.Count == 0)
                {
                    if (currentRound == 1) currentRound = 2;
                    else currentRound = 1;
                }
            }
        }
        else
        {
            playNextTimer = 0;
            openPlayNextTimer = false;
        }
        if (openPlayNextTimer)
        {
            playNextTimer += Time.deltaTime;
        }
        if (playNextTimer >= playNextDelay)
        {
            playNextTimer = 0;
            canPlayNext = true;
        }
    }
}
