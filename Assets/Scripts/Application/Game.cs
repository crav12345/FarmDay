using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private const string GAME_SCENE_NAME = "GameRoom";
    private const string GEOMETRY_SCENE_NAME = "Geometry";
    private const string STORE_SCENE_NAME = "Store";

    public IEnumerator Load()
    {
        yield return SceneManager.LoadSceneAsync(GAME_SCENE_NAME, LoadSceneMode.Single);
        yield return SceneManager.LoadSceneAsync(GEOMETRY_SCENE_NAME, LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync(STORE_SCENE_NAME, LoadSceneMode.Additive);

        var storeLevel = GameObject.Find(STORE_SCENE_NAME);
        var storeController = storeLevel.GetComponent<StoreController>();

        var gameRoom = GameObject.Find(GAME_SCENE_NAME);
        var gameRoomSerializer = gameRoom.GetComponent<GameRoomSerializer>();
        var tileInstantiator = gameRoomSerializer.TileInstantiator;
    }

    public void Run()
    {
        // Actually kick of logic here if I need a delay for some reason.
    }
}
