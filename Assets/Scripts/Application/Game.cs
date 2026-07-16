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
    }

    public void Run()
    {

    }
}
