using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Transform OnDragParent{get; set;}
    private GameObject _towerPrefab;

    private Transform _parentObject = null;

    private void Start()
    {
        _parentObject = transform.parent;
    }

    // Set the UI image's tower relation and update its sprite
    public void SetTowerPrefab(GameObject towerPrefab)
    {
        _towerPrefab = towerPrefab;
        GetComponent<Image>().sprite = _towerPrefab.GetComponent<SpriteRenderer>().sprite;
    }

    // When tower's image is being dragged
    public void OnDrag(PointerEventData eventData)
    {
        // Follow mouse position
        transform.position = Input.mousePosition;
        transform.SetParent(OnDragParent);
    }

    // When tower's image stops being dragged (on mouse left release)
    public void OnEndDrag(PointerEventData eventData)
    {
        // Set its parent to be its original one and its local position to 0
        transform.SetParent(_parentObject);
        transform.localPosition = Vector3.zero;
        // Create tower prefab at that point (in the game world)
        if(!GameEngine.IsMouseOverLayer(5) && !GameEngine.IsMouseOutsideCameraView())
            Instantiate(_towerPrefab, GameEngine.GetMouseWorldPosition(), Quaternion.identity);
    }
}
