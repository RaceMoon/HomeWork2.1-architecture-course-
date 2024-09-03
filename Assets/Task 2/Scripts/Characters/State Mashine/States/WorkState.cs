using UnityEngine;

public class WorkState : IState
{
    private const float _timeForWork = 3;

    private float _timerTime;
    private  IStateSwithcer _stateMashine;

    private CharacterView _view;

    public WorkState(IStateSwithcer stateMashine, Character character)
    {
        _stateMashine = stateMashine;
        _view = character.CharacterView;
    }
    public void Enter()
    {
        Debug.Log("Работа началась, " + _timeForWork + " сек.");
        _timerTime = _timeForWork;
        _view.StartWork();
    }

    public void Exit()
    {
        Debug.Log("Работа закончилась");
        _view.StopWork();
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

