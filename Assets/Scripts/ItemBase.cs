using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField]
    public ItemScriptableObject[] _items;

    public ItemScriptableObject GetScriptableObject(int num)
    {
        return _items[num];
    }

    public int GetCountItems()
    {
        return _items.Length;
    }
}
