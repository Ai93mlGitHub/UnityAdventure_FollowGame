using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _radiusGoal;
    [SerializeField] public float _timerGoal;
    [SerializeField] private GameObject _player;
    [SerializeField] private UIController _uicontroller;
    [SerializeField] private GameObject _npc;
    [SerializeField] private NPCTargetControl _npcTargetControl;

    private bool _isRunning = true;
    private float _distance;
    private NPCMovement _npcMovement;
    private PlayerMovement _playerMovement;
    private KeyCode ResetKey = KeyCode.R;

    public float TimeElapsed { get; private set; } = 0f;

    private void Awake()
    {
        _npcMovement = _npc.GetComponent<NPCMovement>();
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _npc.GetComponent<CircleDrawer>().SetRadiusCircle(_radiusGoal);
    }

    public float TimerGoal
    {
        get => _timerGoal;
        private set => _timerGoal = value;
    }

    void Start()
    {
        StartResetGame();
    }

    void Update()
    {
        _distance = (_player.transform.position - _npc.transform.position).magnitude;

        if (_distance > _radiusGoal)
        {
            LoseGame();
        }

        if (_isRunning)
        {
            TimeElapsed += Time.deltaTime;

            if (TimeElapsed >= _timerGoal)
            {
                WinGame();
            }
        }

        if (Input.GetKeyDown(ResetKey))
        {
            StartResetGame();
        }
    }

    private void WinGame()
    {
        StopGame();
        _uicontroller.WinMessage();
    }

    private void LoseGame()
    {
        StopGame();
        _uicontroller.LoseMessage();
    }

    private void StopGame()
    {
        _isRunning = false;
        _npcMovement.StopMoving();
        _playerMovement.StopMoving();
    }

    private void StartResetGame()
    {
        _isRunning = true;
        TimeElapsed = 0f;
        _uicontroller.CloseAllMessage();
        _npcMovement.Restart();
        _playerMovement.Restart();
        _npcTargetControl.SetRandomCoordinateWithinBorders();
    }
}
