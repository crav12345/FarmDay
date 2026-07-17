using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private const string GAME_SCENE_NAME = "GameRoom";
    private const string STORE_SCENE_NAME = "Store";
    private const string ORDERS_SCENE_NAME = "Orders";

    public IEnumerator Load(Camera camera)
    {
        yield return SceneManager.LoadSceneAsync(GAME_SCENE_NAME, LoadSceneMode.Single);
        yield return SceneManager.LoadSceneAsync(STORE_SCENE_NAME, LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync(ORDERS_SCENE_NAME, LoadSceneMode.Additive);

        var storeLevel = GameObject.Find(STORE_SCENE_NAME);
        var storeController = storeLevel.GetComponent<StoreController>();

        var gameRoom = GameObject.Find(GAME_SCENE_NAME);
        var gameRoomSerializer = gameRoom.GetComponent<GameRoomSerializer>();

        storeController.Initialize(gameRoomSerializer, camera);
    }

    public void Run()
    {
        // Actually kick of logic here if I need a delay for some reason.
    }
}
