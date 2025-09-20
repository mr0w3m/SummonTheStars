using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StarData/StarDataObject")]
public class StarDataObject : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite uiIcon;
    public GameObject worldCharacterPrefab;
}
