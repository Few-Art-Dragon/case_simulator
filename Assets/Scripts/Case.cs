using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case : MonoBehaviour
{
    [SerializeField]
    private GameObject _panelWithAward;
    [SerializeField]
    private GameObject[] _items;
    [SerializeField]
    private ScrollItems _scrollItems;

    private AwardPanel _awardPanel;
    private ItemBase _itemBase;
    private bool _caseIsClosing = true;

    private void Awake()
    {
        _itemBase = GetComponent<ItemBase>();
        _awardPanel = _panelWithAward.GetComponent<AwardPanel>();
    }

    private void Start()
    {
        _scrollItems.CalculateDirection(_items);
    }

    private void Update()
    {
        if (!_panelWithAward.activeSelf && _scrollItems.CheckOnFinishScrolling())
        {
            _panelWithAward.SetActive(true);
            _awardPanel.SetInfoItem(_items[_items.Length-3]);
        }
    }

    public void OpenCase()
    {
        if (_caseIsClosing)
        {
            _caseIsClosing = false;
            gameObject.SetActive(true);
            SpawnItems();
        }      
    }

    private void SpawnItems()
    {
        const int defaultPercantage = 100;
        foreach(var item in _items)
        {
            for (int i= 0; i < _itemBase.GetCountItems(); i++)
            {
                ItemScriptableObject itemScriptableObject = _itemBase.GetScriptableObject(i);
                int randomNum = RandomDropout();
                float dropoutPercentage = defaultPercantage - itemScriptableObject.DropoutPercentage;
                if (randomNum > dropoutPercentage)
                {
                    item.GetComponent<Image>().color = itemScriptableObject.ColorItem;
                    item.name = itemScriptableObject.NameItem;
                    break;
                }
            }          
        }
    }

    private int RandomDropout()
    {
        return Random.Range(1, 101);
    }
}
