using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private int _countOfResourcePerSecond = 1;

    private float _baseTimer = 1f;
    private float _timer = 1f;

    private void OnTriggerStay(Collider other)
    {
        if (other != null && other != this)
        {
            if (_timer < 0f)
            {
                Debug.Log("Начислено " + _countOfResourcePerSecond + " золота");
                _timer = _baseTimer;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }
}
