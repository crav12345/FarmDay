using DG.Tweening;
using TMPro;
using UnityEngine;

public class StoreView : MonoBehaviour
{
    [SerializeField] private RectTransform _storeIcon;
    [SerializeField] private RectTransform _storePanel;
    [SerializeField] private TextMeshProUGUI _coinText;

    private float _storePanelX;
    private float _storeIconX;

    private void Start()
    {
        _storePanelX = _storePanel.position.x;
        _storeIconX = _storeIcon.position.x;
    }

    public void ToggleStore(bool enabled)
    {
        var iconTarget = enabled ? _storeIconX + 310 : _storeIconX;

        var panelTarget = enabled ? _storePanelX + 550 : _storePanelX;

        _storeIcon.DOMoveX(iconTarget, 0.5f);
        _storePanel.DOMoveX(panelTarget, 0.5f);
    }

    public void SetCoinText(string text)
    {
        _coinText.text = text;
    }
}
