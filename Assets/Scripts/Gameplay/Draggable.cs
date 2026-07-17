using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _dragIcon;

    private RectTransform _draggingPlane;
    private Tilemap _highlightsMap;

    public void Initialize(GameRoomSerializer serializer)
    {
        _highlightsMap = serializer.HighlightsMap;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragIcon.enabled = true;
        SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragIcon.enabled = false;
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        if (data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
        {
            _draggingPlane = data.pointerEnter.transform as RectTransform;
        }

        var dragIconRt = _dragIcon.rectTransform;

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_draggingPlane, data.position, data.pressEventCamera, out Vector3 globalMousePos))
        {
            dragIconRt.position = globalMousePos;
            dragIconRt.rotation = _draggingPlane.rotation;
        }
    }
}
