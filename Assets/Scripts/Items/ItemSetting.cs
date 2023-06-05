using UnityEngine;

public enum Type
{
    Weapon,
    Helm,
    Boots
}

public enum Rare
{
    Usual,
    Rare,
    Unique
}

[System.Serializable]
public class ItemSetting : MonoBehaviour
{
    public string Tag;
    public Type Type;
    public Rare Rare;
    public string Name;
    //[SerializeField] private List<Param> _params;
    public string[,] AreaInInventory = new string[4, 2]
    {
        {"-", "-"},
        {"-", "-"},
        {"-", "-"},
        {"-", "-"}
    };

}

