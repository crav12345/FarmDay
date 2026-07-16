using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 _xRange = new(-10f, 10f);
    [SerializeField] private Vector2 _yRange = new(-10f, 10f);
    [SerializeField] private Vector2 _zoomRange = new(1f, 5f);
    [SerializeField] private Camera _camera;

#if UNITY_IOS
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
#endif
}
