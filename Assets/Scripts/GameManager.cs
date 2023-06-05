using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    
    public void OpenCloseInventory(bool flag)
    {
        _inventory.SetActive(flag);
    }
}
