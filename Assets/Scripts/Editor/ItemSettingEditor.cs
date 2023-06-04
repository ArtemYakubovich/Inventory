using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemSetting))]
public class ItemSettingEditor : Editor
{
    private ItemSetting _itemSetting;

    private void OnEnable()
    {
        _itemSetting = (ItemSetting)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical("box");
        _itemSetting.Tag = EditorGUILayout.TextField("Tag", _itemSetting.Tag);
        EditorGUILayout.EndVertical();
        
        EditorGUILayout.BeginVertical("box");
        
        if (GUILayout.Button("SHOW", GUILayout.Height(30), GUILayout.Width(100)))
        {
            Show();
        }
        for (int i = 0; i < _itemSetting.AreaInInventory.GetLength(0); i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < _itemSetting.AreaInInventory.GetLength(1); j++)
            {
                if (GUILayout.Button(_itemSetting.AreaInInventory[i,j], GUILayout.Height(15), GUILayout.Width(15)))
                {
                    if (_itemSetting.AreaInInventory[i, j] == "-")
                    {
                        _itemSetting.AreaInInventory[i,j] = "+";
                    }
                    else if (_itemSetting.AreaInInventory[i, j] == "+")
                    {
                        _itemSetting.AreaInInventory[i,j] = "-";
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        
        EditorGUILayout.EndVertical();
    }

    private void Show()
    {
        string showString = string.Empty;
        
        for (int i = 0; i < _itemSetting.AreaInInventory.GetLength(0); i++)
        {
            for (int j = 0; j < _itemSetting.AreaInInventory.GetLength(1); j++)
            {
                showString += _itemSetting.AreaInInventory[i, j];
            }

            showString += '\n';
        }
        
        Debug.Log(showString);
    }
}