using UnityEngine;
using UnityEngine.UI;

public class ToolsView : MonoBehaviour
{
    [SerializeField] private Canvas _bulletinCanvas;
    [SerializeField] private Image _fieldBubble;

    public void ToggleBulletin(bool enabled)
    {
        _bulletinCanvas.enabled = enabled;
    }

    public void ToggleFieldBubble(bool enabled, Vector3 worldPosition)
    {
        _fieldBubble.rectTransform.position = worldPosition + new Vector3(-0.5f, 0.5f);
        _fieldBubble.enabled = enabled;
    }
}
