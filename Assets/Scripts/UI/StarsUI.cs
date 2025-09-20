using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsUI : MonoBehaviour
{
    [SerializeField] private RectTransform _starsHolder;
    [SerializeField] private GameObject _starsUIPrefab;
    [SerializeField] private StarDataObjectDatabase _starPowerDataBase;

    private List<StarsUI_Selectable> _selectableStars;

    private void Initialize(List<string> stars)
    {
        //load UI
        //foreach in A_Stars
        foreach(StarsUI_Selectable uiElement in _selectableStars)
        {
            Destroy(uiElement.gameObject);
        }

        foreach(string s in stars)
        {
            GameObject go = Instantiate(_starsUIPrefab, _starsHolder);
            go.GetComponent<StarsUI_Selectable>().Init(_starPowerDataBase.ReturnStarData(s));

        }
    }
}
