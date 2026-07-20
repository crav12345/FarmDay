using UnityEngine;
using UnityEngine.UI;

public class ToolsView : MonoBehaviour
{
    [SerializeField] private Canvas _bulletinCanvas;
    [SerializeField] private Image _fieldBubble;

    private Camera _camera;
    private Vector3 _fieldPosition;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        if (_fieldBubble.enabled)
        {
            PositionFieldBubble();
        }
    }

    public void ToggleBulletin(bool enabled)
    {
        _bulletinCanvas.enabled = enabled;
    }

    public void ToggleFieldBubble(bool enabled, Vector3 worldPosition)
    {
        _fieldPosition = worldPosition;
        _fieldBubble.enabled = enabled;

        if (enabled)
        {
            PositionFieldBubble();
        }
    }

    private void PositionFieldBubble()
    {
        _fieldBubble.rectTransform.position = _camera.WorldToScreenPoint(_fieldPosition) + Vector3.up * Screen.height * 0.1f;
    }
}
