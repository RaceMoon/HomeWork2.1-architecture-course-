using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, IMover
{
    [SerializeField] private CharacterView _characterView;
    [SerializeField] private Transform _placeForRest;
    [SerializeField] private List<Transform> _placesForWork;
    [SerializeField] private float _speed;

    private CharacterStateMashine _stateMashine;
    private CharacterController _controller;

    public float Speed { get { return _speed; } set { } }
    public Transform PlaceForRest {  get { return _placeForRest; } }
    public List<Transform> PlacesForWork { get {  return _placesForWork; } }
    public CharacterController Controller => _controller;
    public CharacterView CharacterView => _characterView;

    private void Awake()
    {
        _characterView.Initialize();
        _controller = GetComponent<CharacterController>();
        _stateMashine = new CharacterStateMashine(this, this);
    }

    private void Update()
    {
        _stateMashine.Update();
    }
}
