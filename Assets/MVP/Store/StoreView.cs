using DG.Tweening;
using TMPro;
using UnityEngine;

public class StoreView : MonoBehaviour
{
    [SerializeField] private RectTransform _storeIcon;
    [SerializeField] private RectTransform _storePanel;
    [SerializeField] private TextMeshProUGUI _coinText;

    public void ToggleStore(bool enabled)
    {
        var iconTarget = Screen.width * (enabled ? 0.27f : 0.07f);
        var panelTarget = Screen.width * (enabled ? 0.15f : -0.2f);

        _storeIcon.DOMoveX(iconTarget, 0.5f);
        _storePanel.DOMoveX(panelTarget, 0.5f);
    }

    public void SetCoinText(string text)
    {
        _coinText.text = text;
    }
}
