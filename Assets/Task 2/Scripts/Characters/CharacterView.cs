using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private Animator _animator;

    private const string IsRest = "IsRest";
    private const string IsWalk = "IsWalk";
    private const string IsWork = "IsWork";

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartRest() => _animator.SetBool(IsRest, true);
    public void StopRest() => _animator.SetBool(IsRest, false);
    public void StartWalk() => _animator.SetBool(IsWalk, true);
    public void StopWalk() => _animator.SetBool(IsWalk, false);
    public void StartWork() => _animator.SetBool(IsWork, true);
    public void StopWork() => _animator.SetBool(IsWork, false);

}
