using TMPro;
using UnityEngine;

public class HUDPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _HPText;
    [SerializeField] private TextMeshProUGUI _LevelText;

    public void Initialize(int HP, int level)
    {
        RefreshHPInfo(HP);
        RefreshLevelInfo(level);
    }
    public void RefreshHPInfo(int HP)
    {
        _HPText.text = "Здоровье игрока: " + HP;
    }

    public void RefreshLevelInfo(int level)
    {
        _LevelText.text = "Уровень игрока: " + level;
    }
}
