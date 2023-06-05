using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

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

        if (GUILayout.Button("Show And Save", GUILayout.Height(30), GUILayout.Width(100)))
        {
            ShowAndSave();
        }

        for (int i = 0; i < _itemSetting.AreaInInventory.GetLength(0); i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < _itemSetting.AreaInInventory.GetLength(1); j++)
            {
                if (GUILayout.Button(_itemSetting.AreaInInventory[i, j], GUILayout.Height(30), GUILayout.Width(30)))
                {
                    if (_itemSetting.AreaInInventory[i, j] == "-")
                    {
                        _itemSetting.AreaInInventory[i, j] = "+";
                    }
                    else if (_itemSetting.AreaInInventory[i, j] == "+")
                    {
                        _itemSetting.AreaInInventory[i, j] = "-";
                    }
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndVertical();

        //if(GUI.changed) SetObjectDirty(_itemSetting.gameObject);
    }

    public static void SetObjectDirty(GameObject obj)
    {
        EditorUtility.SetDirty(obj);
        EditorSceneManager.MarkSceneDirty(obj.scene);
    }

    private void ShowAndSave()
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