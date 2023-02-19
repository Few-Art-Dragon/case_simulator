using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScrollItems : MonoBehaviour
{
    [SerializeField]
    [Range (10f, 180)]
    private float _minOffsetScroll, _maxOffsetScroll;

    private float _speedScroll;
    private Vector3 _position;
    private Vector3 _direction;
    private float _stepSpeed = 0.003f;
    private bool _scrollingIsFinish = false;

    private void Awake()
    {
        _position = GetComponent<RectTransform>().localPosition;
    }

    private void Update()
    {  
        transform.localPosition = Vector3.Lerp(transform.localPosition, _direction, _speedScroll * Time.deltaTime);
        if (_speedScroll < 1f)
        {
            _speedScroll += _stepSpeed;
        }
        CheckpositionScroll();
    }

    public void CalculateDirection(GameObject[] items)
    {
        var widthItem = items[0].GetComponent<RectTransform>().sizeDelta.x;
        var widthScroll = GetComponent<RectTransform>().sizeDelta.x;
        var countItemsInCase = items.Length;
        var distanceBetweenItems = (widthScroll - (widthItem * countItemsInCase)) / countItemsInCase;
        _direction = new Vector3(_position.x - ( ( (countItemsInCase-1) * widthItem) + ( (countItemsInCase-1) * distanceBetweenItems) ) - CalculateOffsetScroll(), _position.y, _position.z);
    }

    public bool CheckOnFinishScrolling()
    {
        return _scrollingIsFinish;
    }

    private float CalculateOffsetScroll()
    {
       return Random.Range(_minOffsetScroll, _maxOffsetScroll);
    }

    private void CheckpositionScroll()
    {
        if (Mathf.Floor(transform.localPosition.x) == Mathf.Floor(_direction.x))
        {
            _scrollingIsFinish = true;
        }
    }

}
