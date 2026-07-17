using UnityEngine;

public class StoreController : MonoBehaviour
{
    [SerializeField] private StoreView _view;
    [SerializeField] private Draggable[] _draggables;

    private bool _storeEnabled;
    private int _coins = 30;

    public void Initialize(GameRoomSerializer serializer, Camera camera)
    {
        foreach (var draggable in _draggables)
        {
            draggable.Initialize(serializer, camera);
            draggable.Purchased += OnPurchased;
        }
    }

    public void ToggleStore()
    {
        _storeEnabled = !_storeEnabled;
        _view.ToggleStore(_storeEnabled);
    }

    private void OnPurchased(int cost)
    {
        _coins -= cost;
        _view.SetCoinText(_coins.ToString());

        foreach (var draggable in _draggables)
        {
            if (draggable.Cost > _coins)
            {
                draggable.Button.interactable = false;
            }
        }
    }
}
