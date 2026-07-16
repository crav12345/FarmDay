using UnityEngine;

public class GameRoomSerializer : MonoBehaviour
{
    [SerializeField] private TileInstantiator _tileInstantiator;

    public TileInstantiator TileInstantiator => _tileInstantiator;
}
