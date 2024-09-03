using System;
using UnityEngine;

public class Level
{
    public Action Defeat;

    public Level()
    {
        Start();
    }

    public void RestartLevel()
    {
        Start();
    }

    public void IsDeath(int HP)
    {
        if (HP < 0)
        {
           OnDefeat();
        }
    }

    private void Start()
    {
        Debug.Log("������� ��������");
    }
    private void OnDefeat()
    {
        Defeat?.Invoke();
    }

}
