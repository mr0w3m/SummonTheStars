using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPower_Mini : MonoBehaviour
{

    [SerializeField] private Transform _attackStartPos;
    [SerializeField] private Transform _attackEndPos;
    [SerializeField] private GameObject _starShotPrefab;
    [SerializeField] private float _castRadius;

    public bool _shootInFrontOfYou;

    private void Start()
    {
        Actor.i.input.BDown += FireStar;
    }


    private void FireStar()
    {
        //set the position of a point around the player
        Vector3 randomPositionAroundPlayer = UnityEngine.Random.insideUnitSphere * _castRadius;
        randomPositionAroundPlayer = randomPositionAroundPlayer + transform.position;
        randomPositionAroundPlayer = new Vector3(randomPositionAroundPlayer.x, 0, randomPositionAroundPlayer.y);

        if (_shootInFrontOfYou)
        {
            randomPositionAroundPlayer = _attackEndPos.position;
        }

        //set rotation of projectile
        Vector3 targetDirection = randomPositionAroundPlayer - _attackStartPos.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        GameObject go = Instantiate(_starShotPrefab, _attackStartPos.position, targetRotation);
    }
}
