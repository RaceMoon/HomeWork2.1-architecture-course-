using UnityEngine;

public class GameplayMediator : MonoBehaviour
{
    [SerializeField] DefeatPanel _defeatPanel;
    [SerializeField] HUDPanel _hudPanel;
    [SerializeField] Player _player;

    private Level _level;

    private void Awake()
    {
        _player.Initialize();
        _hudPanel.Initialize(_player.CurrentHP, _player.CurrentLevel);
        _level = new Level();
    }

    private void OnEnable()
    {
        _player.HPChanged += HPChanged;
        _player.LevelChanged += LevelChanged;
        _level.Defeat += OnDefeat;
        _defeatPanel.OnRestartButtonClicked += RestartLevel;
    }

    private void OnDisable()
    {
        _player.HPChanged -= HPChanged;
        _player.LevelChanged -= LevelChanged;
        _level.Defeat -= OnDefeat;
        _defeatPanel.OnRestartButtonClicked -= RestartLevel;
    }

    private void RestartLevel()
    {
        _defeatPanel.HidePanel();
        _player.ResetValue();
        _level.RestartLevel();
    }

    private void OnDefeat()
    {
        _defeatPanel.ShowPanel();
    }

    private void HPChanged()
    {
        _hudPanel.RefreshHPInfo(_player.CurrentHP);
        _level.IsDeath(_player.CurrentHP);
    }

    private void LevelChanged()
    {
        _hudPanel.RefreshLevelInfo(_player.CurrentLevel);
    }
}
