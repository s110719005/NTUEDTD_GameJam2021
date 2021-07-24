using System;
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
    public delegate void OnRoundStart();
    public event OnRoundStart OnRoundStartEvent;
    private float playNextTimer = 2f;
    private bool isStart = false;
    private int currentAction;
    [SerializeField]
    private float playNextDelay = 2.0f;
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    public GameObject Player1 { get => player1; }
    public GameObject Player2 { get => player2; }
    public int currentRound = 1;
    private bool excutingRound = false;
    public bool ExcutingRound { get => excutingRound; }

    // Start is called before the first frame update
    void Start()
    {
        playerActions = new Queue<int>();
    }
    public void AddAction(int actionType)
    {
        if (excutingRound) return;
        playerActions.Enqueue(actionType);
        Debug.Log(playerActions.Count);
        //Action_MoveUp();
    }
    public void StartAction()
    {
        isStart = true;
    }
    public void ClearAction()
    {
        playerActions.Clear();
        Debug.Log(playerActions.Count);
        Debug.Log("Queue Clear!");
    }
    public void Action_MoveUp()
    {
        FindObjectOfType<PlayerMovement>().SetIsMoveUp(true);
    }

    void ActionSwitch(int actionType)
    {
        playNextDelay = 2f;
        if (currentRound == 1)
        {
            Debug.Log($"cr: {currentRound}");
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
                    SkillManager.Instance.skills[0].Use(MovementManager.Instance.Player1.transform);
                    break;
                case 5:
                    SkillManager.Instance.skills[1].Use(MovementManager.Instance.Player1.transform);
                    break;
                case 6:
                    SkillManager.Instance.skills[2].Use(MovementManager.Instance.Player1.transform);
                    break;
                default:
                    break;
            }
            Debug.Log($"cr: {currentRound}");

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
                    SkillManager.Instance.skills[0].Use(MovementManager.Instance.Player2.transform);
                    break;
                case 5:
                    SkillManager.Instance.skills[1].Use(MovementManager.Instance.Player2.transform);
                    break;
                case 6:
                    SkillManager.Instance.skills[2].Use(MovementManager.Instance.Player2.transform);
                    break;
                default:
                    break;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        //p1 Start->Btn
        //p1 Run->time
        //p2 Start->Btn
        //p2 Run->time

        if (excutingRound)
        {
            if (playNextTimer >= playNextDelay)
            {
                if (playerActions.Count != 0)
                {

                    ActionSwitch(playerActions.Dequeue());
                    playNextTimer = 0;
                }
                else
                {
                    Debug.Log($"Player{currentRound}'s Order Done.");
                    excutingRound = false;
                    currentRound = currentRound == 1 ? 2 : 1;
                    OnRoundStartEvent?.Invoke();
                    FindObjectOfType<UIManager>().OpenPanel();

                }
            }
            playNextTimer += Time.deltaTime;
        }

        if (isStart)
        {
            Debug.Log($"Start excuting Player{currentRound}'s Order.");
            isStart = false;
            excutingRound = true;
        }


        // if (playerActions.Count != 0)
        // {
        //     if (isStart)
        //     {
        //         isStart = false;
        //         openPlayNextTimer = true;
        //         currentAction = playerActions.Dequeue();
        //         ActionSwitch(currentAction);
        //     }
        //     else if (canPlayNext)
        //     {
        //         canPlayNext = false;
        //         currentAction = playerActions.Dequeue();
        //         ActionSwitch(currentAction);
        //         if (playerActions.Count == 0)
        //         {
        //             if (currentRound == 1) currentRound = 2;
        //             else currentRound = 1;
        //         }
        //     }
        // }
        // else
        // {
        //     playNextTimer = 0;
        //     openPlayNextTimer = false;
        // }
        // if (openPlayNextTimer)
        // {
        //     playNextTimer += Time.deltaTime;
        // }
        // if (playNextTimer >= playNextDelay)
        // {
        //     playNextTimer = 0;
        //     canPlayNext = true;
        // }
    }
}
