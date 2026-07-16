using UnityEngine;

public class StorePresenter : MonoBehaviour
{
    [SerializeField] private StoreView _view;

    private bool _storeEnabled;

    public void ToggleStore()
    {
        _storeEnabled = !_storeEnabled;
        _view.ToggleStore(_storeEnabled);
    }
}
