using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private enum TileType
    {
        Building,
        Field
    }

    [SerializeField] private Image _dragIcon;
    [SerializeField] private TileBase _highlightTile;
    [SerializeField] private TileBase _tileToPlace;
    [SerializeField] private TileType _tileType;

    private RectTransform _draggingPlane;
    private Tilemap _highlightsMap;
    private Tilemap _fieldsMap;
    private Tilemap _staticItemsMap;
    private Tilemap _buildingsMap;
    private Camera _camera;
    private Vector3Int _highlightedCell;
    private bool _hasHighlightedCell;

    public void Initialize(GameRoomSerializer serializer, Camera camera)
    {
        _camera = camera;
        _highlightsMap = serializer.HighlightsMap;
        _fieldsMap = serializer.FieldsMap;
        _buildingsMap = serializer.BuildingsMap;
        _staticItemsMap = serializer.StaticItemsMap;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragIcon.enabled = true;
        SetDraggedPosition(eventData);
        SetHighlightedTile(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
        SetHighlightedTile(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragIcon.enabled = false;
        SetHighlightedTile(eventData.position);
        TryPlaceTile();
        ClearHighlightedTile();
    }

    private void OnDisable()
    {
        ClearHighlightedTile();
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

    private void SetHighlightedTile(Vector2 screenPosition)
    {
        var pointerRay = _camera.ScreenPointToRay(screenPosition);
        var tilemapPlane = new Plane(_highlightsMap.transform.forward, _highlightsMap.transform.position);

        if (!tilemapPlane.Raycast(pointerRay, out var distance))
        {
            ClearHighlightedTile();
            return;
        }

        var cell = _highlightsMap.WorldToCell(pointerRay.GetPoint(distance));

        if (_hasHighlightedCell && cell == _highlightedCell)
        {
            return;
        }

        ClearHighlightedTile();
        _highlightsMap.SetTile(cell, _highlightTile);
        _highlightedCell = cell;
        _hasHighlightedCell = true;
    }

    private void ClearHighlightedTile()
    {
        if (!_hasHighlightedCell)
        {
            return;
        }

        if (_highlightsMap != null)
        {
            _highlightsMap.SetTile(_highlightedCell, null);
        }

        _hasHighlightedCell = false;
    }

    private void TryPlaceTile()
    {
        if (!_hasHighlightedCell)
        {
            return;
        }

        var highlightedCellCenter = _highlightsMap.GetCellCenterWorld(_highlightedCell);
        var placementCell = _fieldsMap.WorldToCell(highlightedCellCenter);

        if (_fieldsMap.HasTile(placementCell))
        {
            return;
        }

        _fieldsMap.SetTile(placementCell, _tileToPlace);
    }
}
