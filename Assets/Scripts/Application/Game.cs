using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private const string GAME_SCENE_NAME = "GameRoom";
    private const string STORE_SCENE_NAME = "Store";
    private const string TOOLS_SCENE_NAME = "Tools";

    public IEnumerator Load(Camera camera)
    {
        yield return SceneManager.LoadSceneAsync(GAME_SCENE_NAME, LoadSceneMode.Single);
        yield return SceneManager.LoadSceneAsync(STORE_SCENE_NAME, LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync(TOOLS_SCENE_NAME, LoadSceneMode.Additive);

        var gameRoom = GameObject.Find(GAME_SCENE_NAME);
        var gameRoomSerializer = gameRoom.GetComponent<GameRoomSerializer>();

        var storeLevel = GameObject.Find(STORE_SCENE_NAME);
        var storeController = storeLevel.GetComponent<StoreController>();

        var toolsLevel = GameObject.Find(TOOLS_SCENE_NAME);
        var toolsController = toolsLevel.GetComponent<ToolsController>();

        storeController.Initialize(gameRoomSerializer, camera);
        toolsController.Initialize(gameRoomSerializer);
    }

    public void Run()
    {
        // Actually kick of logic here if I need a delay for some reason.
    }
}
