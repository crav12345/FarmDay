using System;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public event Action FieldBought;

    [SerializeField] private StoreView _view;
    [SerializeField] private Draggable[] _draggables;

    private bool _storeEnabled;

    public void Initialize(GameRoomSerializer serializer)
    {
        foreach (var draggable in _draggables)
        {
            draggable.Initialize(serializer);
        }
    }

    public void ToggleStore()
    {
        _storeEnabled = !_storeEnabled;
        _view.ToggleStore(_storeEnabled);
    }

    public void BuyField()
    {
        FieldBought?.Invoke();
    }
}
