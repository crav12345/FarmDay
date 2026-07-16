using UnityEngine;

#if !UNITY_EDITOR && UNITY_IOS
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 _xRange = new(-10f, 10f);
    [SerializeField] private Vector2 _yRange = new(-10f, 10f);
    [SerializeField] private Vector2 _zoomRange = new(1f, 5f);
    [SerializeField] private Camera _camera;

    private void OnEnable() => EnhancedTouchSupport.Enable();
    private void OnDisable() => EnhancedTouchSupport.Disable();

    private void Update()
    {
        var touches = Touch.activeTouches;

        if (touches.Count == 1)
        {
            var worldUnits = 2f * _camera.orthographicSize / Screen.height;
            var fingerDelta = touches[0].delta;
            var delta = -fingerDelta * worldUnits;
            var position = transform.position + (Vector3)delta;

            position.x = Mathf.Clamp(position.x, _xRange.x, _xRange.y);
            position.y = Mathf.Clamp(position.y, _yRange.x, _yRange.y);
            transform.position = position;

            return;
        }

        if (touches.Count <= 1)
        {
            return;
        }

        var touchA = touches[0];
        var touchB = touches[1];
        var currFingerDistance = Vector2.Distance(touchA.screenPosition, touchB.screenPosition);
        var prevFingerDistance = Vector2.Distance(touchA.screenPosition - touchA.delta, touchB.screenPosition - touchB.delta);
        var pinch = currFingerDistance - prevFingerDistance;
        var targetZoom = _camera.orthographicSize - pinch * _camera.orthographicSize / Screen.height;

        _camera.orthographicSize = Mathf.Clamp(targetZoom, _zoomRange.x, _zoomRange.y);
    }
}
#endif

#if UNITY_EDITOR || !UNITY_IOS
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 _xRange = new(-10f, 10f);
    [SerializeField] private Vector2 _yRange = new(-10f, 10f);
    [SerializeField] private Vector2 _zoomRange = new(1f, 5f);
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _zoomSpeed = 2f;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard == null)
        {
            return;
        }

        var input = new Vector2(
            (keyboard.dKey.isPressed ? 1f : 0f) - (keyboard.aKey.isPressed ? 1f : 0f),
            (keyboard.wKey.isPressed ? 1f : 0f) - (keyboard.sKey.isPressed ? 1f : 0f));
        var delta = input.normalized * (_moveSpeed * Time.deltaTime);
        var position = transform.position + (Vector3)delta;

        position.x = Mathf.Clamp(position.x, _xRange.x, _xRange.y);
        position.y = Mathf.Clamp(position.y, _yRange.x, _yRange.y);
        transform.position = position;

        var zoomIn = keyboard.equalsKey.isPressed || keyboard.numpadPlusKey.isPressed;
        var zoomOut = keyboard.minusKey.isPressed || keyboard.numpadMinusKey.isPressed;
        var zoomDelta = ((zoomOut ? 1f : 0f) - (zoomIn ? 1f : 0f)) * _zoomSpeed * Time.deltaTime;
        var targetZoom = _camera.orthographicSize + zoomDelta;

        _camera.orthographicSize = Mathf.Clamp(targetZoom, _zoomRange.x, _zoomRange.y);
    }
}
#endif
