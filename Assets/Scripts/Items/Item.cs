using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Transform _inventoryAnchor;
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private ItemSetting _itemSetting;
    
    private void OnMouseDown()
    {
        _itemSetting = GetComponent<ItemSetting>();
        GetItem();
    }

    private void Start()
    {
        _inventoryManager = _inventoryAnchor.GetComponent<InventoryManager>();
    }

    public void GetItem()
    {
        gameObject.transform.SetParent(_inventoryAnchor);
        gameObject.SetActive(false);
        _inventoryManager.GetItem(_sprite);
        _inventoryManager.GetSaveCells(_itemSetting.AreaInInventory);
    }
}
