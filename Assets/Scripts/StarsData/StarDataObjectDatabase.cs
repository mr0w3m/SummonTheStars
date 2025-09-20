using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "StarData/StarDataObjectDatabase")]
public class StarDataObjectDatabase : ScriptableObject
{
    public List<StarDataObject> _starDatas;

    public StarDataObject ReturnStarData(string s)
    {
        return _starDatas.FirstOrDefault(d => d.id == s);
    }
}
