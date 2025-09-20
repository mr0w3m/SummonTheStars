using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Rotate : MonoBehaviour
{
    [SerializeField] private Transform _playerSpritePivot;
    [SerializeField] private float _rotSpeed;

    private Quaternion _targetRotation;

    private Vector3 _rightFacing = new Vector3(-1, 1, 1);
    private Vector3 _leftFacing = new Vector3(1, 1, 1);

    private void LateUpdate()
    {
        if (Actor.i.movement.facingDirection == Direction.Right)
        {
            _targetRotation = Quaternion.Euler(0, -15, 0);
            _playerSpritePivot.localScale = _rightFacing;
        }
        else
        {
            _targetRotation = Quaternion.Euler(0, 15, 0);
            _playerSpritePivot.localScale = _leftFacing;
        }

        _playerSpritePivot.rotation = Quaternion.Slerp(_playerSpritePivot.rotation, _targetRotation, _rotSpeed * Time.deltaTime);
    }
}
