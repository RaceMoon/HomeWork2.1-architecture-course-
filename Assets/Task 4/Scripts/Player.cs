using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action HPChanged;
    public Action LevelChanged;

    [SerializeField] private int _baseHP;
    [SerializeField] private int _baseXP;
    [SerializeField] private int _XPForLevelUp;

    public int CurrentHP { get; private set; }
    public int CurrentXP { get; private set; }
    public int CurrentLevel { get; private set; }

    private void OnValidate()
    {
        if (_baseXP < _XPForLevelUp)
        {
            _baseXP = _XPForLevelUp;
        }
    }
    public void Initialize()
    {
        CurrentHP = _baseHP;
        CurrentXP = _baseXP;
        CurrentLevel = CheckLevel();
    }

    public void TakeDamage(int damage)
    {
        int newHPValue;

        if (damage > 0)
        {
            newHPValue = CurrentHP - damage;
            ChangeHP(newHPValue);
        }
    }

    public void AddXP(int value)
    {
        int newXPValue;
        if (value > 0)
        {
            newXPValue = CurrentXP + value;

            ChangeXP(newXPValue);

        }
    }

    public void ResetValue()
    {
        ChangeHP(_baseHP);
        ChangeXP(_baseXP);
    }

    private void ChangeHP(int value)
    {
        CurrentHP = value;
        HPChanged?.Invoke();
    }

    private void ChangeXP(int value)
    {
        CurrentXP = value;

        if (CheckLevel() != CurrentLevel)
        {
            ChangeLevel();
        }
    }

    private void ChangeLevel()
    {
        CurrentLevel = CheckLevel();
        LevelChanged?.Invoke();
    }

    private int CheckLevel()
    {
        return Math.DivRem(CurrentXP, _XPForLevelUp, out int result);
    }
}

