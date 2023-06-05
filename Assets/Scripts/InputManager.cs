using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private bool _inventoryFlag;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryFlag = !_inventoryFlag;
            _gameManager.OpenCloseInventory(_inventoryFlag);
        }
    }
}
