using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AwardPanel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _nameAward;
    [SerializeField]
    private Image _imageAward;

    public void SetInfoItem(GameObject item)
    { 
        _nameAward.text = item.name;
        _imageAward.color = item.GetComponent<Image>().color;
    }

    public void RetryOpenCase()
    {
        SceneManager.LoadScene(0);
    }
}
