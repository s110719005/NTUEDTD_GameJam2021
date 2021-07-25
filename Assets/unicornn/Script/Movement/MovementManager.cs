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
        //instance = MovementManager.Instance;
        //instance = this;
        if (instance == null) instance = this;
        // var players = FindObjectsOfType<PlayerMovement>();
        // MovementManager.Instance.player1 = players[0].gameObject;
        // MovementManager.Instance.player2 = players[1].gameObject;
        //if (instance == this) DontDestroyOnLoad(this);
        else DestroyImmediate(this);
    }

    private Queue<int> playerActions;
    public delegate void OnRoundStart();
    public event OnRoundStart OnRoundStartEvent;
    public delegate void OnGameStart();
    public event OnGameStart OnGameStartEvent;
    private float gameStartDelay = 1;
    public float GameStartDelay { get => gameStartDelay; }
    private float playNextTimer = 1.6f;
    private bool isStart = false;
    private int currentAction;
    [SerializeField]
    private float playNextDelay = 1.6f;
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    public GameObject Player1 { get => player1; }
    public GameObject Player2 { get => player2; }
    public int currentRound = 1;
    private bool excutingRound = false;
    public bool ExcutingRound { get => excutingRound; }
    private int uiCount = 0;

    // Start is called before the first frame update

    void Start()
    {
        playerActions = new Queue<int>();
        StartCoroutine("WaitForGameStart");
        OnGameStartEvent?.Invoke();
    }
    IEnumerator WaitForGameStart()
    {
        yield return new WaitForSeconds(gameStartDelay);
    }
    public void AddAction(int actionType)
    {
        if (excutingRound) return;
        if (playerActions.Count == 6) return;
        playerActions.Enqueue(actionType);
        FindObjectOfType<UIManager>().SetPreviewSprite(playerActions.Count - 1, actionType);//設定UI預覽
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
        SkillManager.Instance.ResetMapSkills();
        FindObjectOfType<UIManager>().ResetPreviewSprite();//清除UI預覽
        Debug.Log(playerActions.Count);
        Debug.Log("Queue Clear!");
    }
    public void Action_MoveUp()
    {
        FindObjectOfType<PlayerMovement>().SetIsMoveUp(true);
    }
    public void ForceAddDelay(float addtime)
    {
        playNextDelay += addtime;
    }
    void ActionSwitch(int actionType)
    {
        if (currentRound == 1)
        {
            Debug.Log($"cr: {currentRound}");
            if (Player1 == null || Player2 == null)
                return;
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
                case 7:
                    playNextDelay = 0.5f;//up
                    break;
                case 8:
                    playNextDelay = 0.5f;//down
                    break;
                case 9:
                    playNextDelay = 0.5f;//right
                    break;
                case 10:
                    playNextDelay = 0.5f;//left
                    break;

                case 11:
                    playNextDelay = 0.5f;//same above
                    break;
                case 12:
                    playNextDelay = 0.5f;
                    break;
                case 13:
                    playNextDelay = 0.5f;
                    break;
                case 14:
                    playNextDelay = 0.5f;
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

                case 7:
                    playNextDelay = 0.5f;//up
                    break;
                case 8:
                    playNextDelay = 0.5f;//down
                    break;
                case 9:
                    playNextDelay = 0.5f;//right
                    break;
                case 10:
                    playNextDelay = 0.5f;//left
                    break;

                case 11:
                    playNextDelay = 0.5f;//same above
                    break;
                case 12:
                    playNextDelay = 0.5f;
                    break;
                case 13:
                    playNextDelay = 0.5f;
                    break;
                case 14:
                    playNextDelay = 0.5f;
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

                    FindObjectOfType<UIManager>().ExecutePreviewSprite(uiCount);//執行動作也處理UI預覽
                    uiCount++;
                    playNextDelay = 1.6f;//reset delay
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
                    uiCount = 0;

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
