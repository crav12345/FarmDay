using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TileMapClickHandler : MonoBehaviour
{
    public event Action<string, Vector3> TilePressed;

    [SerializeField] private Tilemap _tilemap;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
#if UNITY_IOS && !UNITY_EDITOR
        var touchscreen = Touchscreen.current;

        if (touchscreen == null)
        {
            return;
        }

        foreach (var touch in touchscreen.touches)
        {
            if (touch.press.wasPressedThisFrame)
            {
                LogPressedTile(touch.position.ReadValue());
            }
        }
#else
        var mouse = Mouse.current;

        if (mouse != null && mouse.leftButton.wasPressedThisFrame)
        {
            HandleTilePress(mouse.position.ReadValue());
        }
#endif
    }

    private void HandleTilePress(Vector2 screenPosition)
    {
        var touchRay = _camera.ScreenPointToRay(screenPosition);
        var tilemapPlane = new Plane(_tilemap.transform.forward, _tilemap.transform.position);

        if (!tilemapPlane.Raycast(touchRay, out var distance))
        {
            return;
        }

        var cellPosition = _tilemap.WorldToCell(touchRay.GetPoint(distance));
        var tile = _tilemap.GetTile(cellPosition);

        if (tile == null)
        {
            return;
        }

        var worldPosition = _tilemap.GetCellCenterWorld(cellPosition);

        TilePressed?.Invoke(tile.name, worldPosition);
    }
}
