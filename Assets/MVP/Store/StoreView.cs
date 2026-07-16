using DG.Tweening;
using UnityEngine;

public class StoreView : MonoBehaviour
{
    [SerializeField] private RectTransform _storeIcon;
    [SerializeField] private RectTransform _storePanel;

    public void ToggleStore(bool enabled)
    {
        var iconX = _storeIcon.anchoredPosition.x;
        var iconTarget = enabled ? iconX + 200 : iconX - 200;

        var panelX = _storePanel.anchoredPosition.x;
        var panelTarget = enabled ? panelX + 200 : panelX - 200;

        _storeIcon.DOMoveX(iconTarget, 0.5f);
        _storePanel.DOMoveX(panelTarget, 0.5f);
    }
}
