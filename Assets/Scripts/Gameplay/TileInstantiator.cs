using UnityEngine;

public class TileInstantiator : MonoBehaviour
{
    private StoreController _storeController;

    public void Initialize(StoreController storeController)
    {
        _storeController = storeController;
        _storeController.FieldBought += OnFieldBought;  // Generalize OnTileBought()
    }

    private void OnFieldBought()
    {

    }
}
