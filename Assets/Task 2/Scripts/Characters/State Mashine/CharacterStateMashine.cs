using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterStateMashine : IStateSwithcer
{
    private Queue<Vector3> _placesForWork;
    private Vector3 _placeForRest;
    private Vector3 _destination;

    private List<IState> _states;
    private IState _currentState;

    private Character _character;
    private IMover _mover;

    private CharacterController _characterController;
    public CharacterController CharacterController { get { return _characterController; } }
    public Vector3 Destination { get { return _destination; } }

    public CharacterStateMashine(Character character, IMover mover)  //List<Transform> placesForWork, Vector3 placeForRest, CharacterController characterController
    {
        _character = character;
        _mover = mover;
        _placesForWork = new Queue<Vector3>();

        foreach (Transform place in character.PlacesForWork)
        {
            _placesForWork.Enqueue(place.position);
        }

        _placeForRest = character.PlaceForRest.transform.position;
        _characterController = character.Controller;
        SetDestination(_placeForRest);

        _states = new List<IState>()
        {
            new MoveState(this, character, _destination, mover),
            new RestState(this, character),
            new WorkState(this, character)
       };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        if (state.GetType() == typeof(MoveState))
        {

            if (_currentState.GetType() == typeof(RestState))
            {
                SetDestination(_placesForWork.Peek());
                _placesForWork.Dequeue();
                _placesForWork.Enqueue(_destination);
            }
            else if (_currentState.GetType() == typeof(WorkState))
            {
                SetDestination(_placeForRest);
            }

            _states.Remove(state);
            state = new MoveState(this, _character, _destination, _mover);
            _states.Add(state);

        }
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    private void SetDestination(Vector3 newDestination)
    {
        _destination = new Vector3(newDestination.x, 0, newDestination.z);
    }

}
