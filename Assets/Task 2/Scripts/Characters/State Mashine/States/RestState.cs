using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestState : IState
{
    private const float _timeForRest = 3;

    private float _timerTime;
    private IStateSwithcer _stateMashine;

    private CharacterView _view;

    public RestState(IStateSwithcer stateMashine, Character character)
    {
        _stateMashine = stateMashine;
        _view = character.CharacterView;
    }
    public void Enter()
    {
        Debug.Log("Отдых начался, " + _timeForRest + " сек.");
        _timerTime = _timeForRest;
        _view.StartRest();
    }

    public void Exit()
    {
        Debug.Log("Отдых закончился");
        _view.StopRest();
    }

    public void Update()
    {
        if (_timerTime < 0)
        {
            _stateMashine.SwitchState<MoveState>();
        }
        else
        {
            _timerTime -= Time.deltaTime;
        }
    }
}
