using System.Collections;
using UnityEngine;

/// <summary>
/// Starts all application parent systems.
/// </summary>
public class Application : MonoBehaviour
{
    [SerializeField] private Game _game;

    private void Start()
    {
        DontDestroyOnLoad(this);
        StartCoroutine(BootstrapCoroutine());
    }

    private IEnumerator BootstrapCoroutine()
    {
        yield return _game.Load();

        _game.Run();
    }
}
