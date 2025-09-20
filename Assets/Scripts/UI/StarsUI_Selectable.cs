using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StarsUI_Selectable : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;

    private string starPowerString;

    public void Init(StarDataObject data)
    {
        starPowerString = data.id;
        _image.sprite = data.uiIcon;
        _text.text = data.displayName;
    }
}
