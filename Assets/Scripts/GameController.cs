using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _radiusGoal;
    [SerializeField] private float _timerGoal;
    [SerializeField] private GameObject _player;
    [SerializeField] private UIController _uicontroller;
    [SerializeField] private GameObject _npc;

    private bool _isRunning = true;
    private float _timeElapsed = 0f;
    private float _distance;
    private NPCMovement _npcMovement;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _npcMovement = _npc.GetComponent<NPCMovement>();
        _playerMovement = _player.GetComponent<PlayerMovement>();
    }

    public float RadiusGoal
    {
        get { return _radiusGoal; }
        private set { _radiusGoal = value; }
    }

    public float TimeElapsed
    {
        get { return _timeElapsed; }
        private set { _timeElapsed = value; }
    }

    public float TimerGoal
    {
        get { return _timerGoal; }
        private set { _timerGoal = value; }
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
            _timeElapsed += Time.deltaTime;

            if (_timeElapsed >= _timerGoal)
            {
                WinGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
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
        _timeElapsed = 0f;
        _uicontroller.CloseAllMessage();
        _npcMovement.Restart();
        _playerMovement.Restart();
    }
}
