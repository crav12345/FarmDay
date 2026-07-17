using UnityEngine;

public class ToolsView : MonoBehaviour
{
    [SerializeField] private Canvas _bulletinCanvas;

    public void ToggleBulletin(bool enabled)
    {
        _bulletinCanvas.enabled = enabled;
    }
}
