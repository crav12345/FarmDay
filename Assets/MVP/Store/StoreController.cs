using UnityEngine;

public class StoreController : MonoBehaviour
{
    [SerializeField] private StoreView _view;
    [SerializeField] private Draggable[] _draggables;

    private bool _storeEnabled;

    public void Initialize(GameRoomSerializer serializer, Camera camera)
    {
        foreach (var draggable in _draggables)
        {
            draggable.Initialize(serializer, camera);
        }
    }

    public void ToggleStore()
    {
        _storeEnabled = !_storeEnabled;
        _view.ToggleStore(_storeEnabled);
    }
}
