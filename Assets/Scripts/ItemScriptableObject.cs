using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "CaseItem/New Item", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    [SerializeField]
    private string _nameItem;
    [SerializeField]
    private Color _colorItem;
    [SerializeField]
    private float _dropoutPercentage;

    public string NameItem
    {
        get
        {
            return _nameItem;
        }   
    }

    public Color ColorItem
    {
        get
        {
            return _colorItem;
        }
    }

    public float DropoutPercentage
    {
        get
        {
            return _dropoutPercentage;
        }
    }
}
