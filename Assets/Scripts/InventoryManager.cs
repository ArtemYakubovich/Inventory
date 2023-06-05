using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Transform _cellsAnchor;

    private string[,] _saveCells;
    private Image[,] _cells;
    [SerializeField] private Image _image;
    public Sprite _item;

    private void Start()
    {
        _saveCells = new string[5, 12];
        _cells = new Image[5, 12];
        Image[] cells = _cellsAnchor.GetComponentsInChildren<Image>();
        int count = 0;

        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int j = 0; j < _cells.GetLength(1); j++)
            {
                _saveCells[i, j] = "-";
                _cells[i, j] = cells[count];
                count++;
            }
        }
    }

    public void GetItem(Sprite sprite)
    {
        _item = sprite;
        _image.sprite = _item;
        _image.gameObject.SetActive(true);
        CheckCells();
    }
    
    public void GetSaveCells(string[,] greyArea)
    {
        for (int i = 0; i < greyArea.GetLength(0); i++)
        {
            for (int j = 0; j < greyArea.GetLength(1); j++)
            {
                if (greyArea[i, j] == "+")
                {
                    _saveCells[i, j] = "+";
                }
            }
        }
        CheckCells();
    }

    private void CheckCells()
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int j = 0; j < _cells.GetLength(1); j++)
                if (_saveCells[i, j] == "+")
                {
                    _cells[i, j].color = Color.gray;
                }
        }
    }
}