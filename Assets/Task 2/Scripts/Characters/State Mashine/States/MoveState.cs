using UnityEngine;

public class MoveState : IState
{
    private const float _radiusOfCheckColliedr = 1f;

    private IStateSwithcer _stateMachine;
    private CharacterController _characterController;
    private Vector3 _destination;
    private float _speed;
    private CharacterView _view;

    public MoveState(IStateSwithcer stateMachine, Character character, Vector3 destination, IMover mover)
    {
        _stateMachine = stateMachine;
        _destination = destination;
        _characterController = character.Controller;
        _speed = mover.Speed;
        _view = character.CharacterView;
    }

    public void Enter()
    {
        Debug.Log("Движение началось");
        _characterController.transform.rotation = Quaternion.LookRotation(_destination - _characterController.transform.position);
        _view.StartWalk();
    }

    public void Exit()
    {
        Debug.Log("Движение закончилось");
        _view.StopWalk();
    }

    public void Update()
    {
        _characterController.Move((_destination - _characterController.transform.position).normalized * _speed * Time.deltaTime);

        Collider[] colliders = Physics.OverlapSphere(_characterController.transform.position, _radiusOfCheckColliedr);

        foreach (Collider collider in colliders)
        {
            // реализация логики других коллайдеров (ловушка, лава и т.д.)
            if (isCame())
            {
                if (collider.TryGetComponent(out Resource resource))
                {
                    _stateMachine.SwitchState<WorkState>();
                }
                else if (collider.TryGetComponent(out RestPlace restPlace))
                {
                    _stateMachine.SwitchState<RestState>();
                }
            }
        }
    }
    private bool isCame()
    {
        if (Vector3.Distance(_characterController.transform.position, _destination) <= _radiusOfCheckColliedr || _characterController.velocity == Vector3.zero)
            return true;
        else
            return false;
    }
}
