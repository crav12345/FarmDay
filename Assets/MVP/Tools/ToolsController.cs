using UnityEngine;

public class ToolsController : MonoBehaviour
{
    [SerializeField] private ToolsView _view;

    private TileMapClickHandler[] _handlers;
    private bool _ordersEnabled;

    public void Initialize(GameRoomSerializer serializer)
    {
        _handlers = serializer.TileClickHandlers;

        foreach (var handler in _handlers)
        {
            handler.TilePressed += OnTilePressed;
        }
    }

    private void OnTilePressed(string name, Vector3 worldPosition)
    {
        switch (name)
        {
            case "orders":
                _ordersEnabled = !_ordersEnabled;
                _view.ToggleBulletin(_ordersEnabled);
                break;
            default:
                break;
        }
    }
}
