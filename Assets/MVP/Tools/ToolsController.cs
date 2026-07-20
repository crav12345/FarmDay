using UnityEngine;

public class ToolsController : MonoBehaviour
{
    [SerializeField] private ToolsView _view;

    private TileMapClickHandler[] _handlers;
    private bool _ordersEnabled;
    private bool _fieldBubbleEnabled;

    public void Initialize(GameRoomSerializer serializer)
    {
        _handlers = serializer.TileClickHandlers;

        foreach (var handler in _handlers)
        {
            handler.TilePressed += OnTilePressed;
        }
    }

    public void CloseBulletin()
    {
        _ordersEnabled = false;
        _view.ToggleBulletin(_ordersEnabled);
    }

    private void OnTilePressed(string name, Vector3 worldPosition)
    {
        if (_ordersEnabled)
        {
            return;
        }

        switch (name)
        {
            case "orders":
                _ordersEnabled = true;
                _view.ToggleBulletin(_ordersEnabled);
                break;
            case "plowed_field_0":
                _fieldBubbleEnabled = true;
                worldPosition = Camera.main.WorldToScreenPoint(worldPosition);

                _view.ToggleFieldBubble(_fieldBubbleEnabled, worldPosition);
                break;
            default:
                break;
        }
    }
}
