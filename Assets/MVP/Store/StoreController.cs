using System;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public event Action FieldBought;

    [SerializeField] private StoreView _view;

    private bool _storeEnabled;

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
