using System;
using UnityEngine;
using UnityEngine.UI;


public class DefeatPanel : MonoBehaviour
{
    public Action OnRestartButtonClicked;

    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartClick);
    }

    private void OnRestartClick()
    {
        OnRestartButtonClicked?.Invoke();
    }
    public void HidePanel() => gameObject.SetActive(false);
    public void ShowPanel() => gameObject.SetActive(true);
}
