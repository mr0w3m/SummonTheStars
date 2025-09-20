using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_CameraController : MonoBehaviour
{

    [SerializeField] private Transform _yaw;
    [SerializeField] private Transform _pitch;
    [SerializeField] private Transform _roll;
    [SerializeField] private Transform _dolly;

    [SerializeField] private float _defaultPitch = 27.5f;
    [SerializeField] private float _pitchSpeed;
    [SerializeField] private float _yawSpeed;
    
    
    [SerializeField] private float _dollySpeed;
    [SerializeField] private float _minDollyZPos;
    [SerializeField] private float _maxDollyZPos;

    [SerializeField] private float _maxPitch;
    [SerializeField] private float _minPitch;
    

    public Transform cameraTransform;

    private float _leftStickMovementCutoff = 0.02f;
    private Quaternion _targetRotation;
    private Quaternion _targetYawRotation;
    private Vector3 _targetDollyZposition;

    private void LateUpdate()
    {
        if (!Actor.i.paused)
        {
            if (Actor.i.input.MouseMode)
            {
                ReadCameraMouseInput();
            }
            else
            {
                ReadCameraInput();
            }
            //ReadYaw();
        }
    }

    private void ReadYaw()
    {
        if (Actor.i.movement.facingDirection == Direction.Right)
        {
            _targetYawRotation = Quaternion.Euler(0, 30, 0);
        }
        else
        {
            _targetYawRotation = Quaternion.Euler(0, -30, 0);
        }

        _yaw.rotation = Quaternion.Slerp(_yaw.rotation, _targetYawRotation, _yawSpeed * Time.deltaTime);
    }

    private void ReadCameraInput()
    {
        //read camera inputs

        //wip dolly pull in when looking up
        if (Mathf.Abs(Actor.i.input.RSY) > _leftStickMovementCutoff)
        {
            float xRotation = Util.MapValue(Actor.i.input.RSY, -1, 1, _minPitch, _maxPitch);
            xRotation = Mathf.Clamp(xRotation, _minPitch, _maxPitch);
            _targetRotation = Quaternion.Euler(xRotation, 0, 0);

            //float zPos = Util.MapValue(Actor.i.input.RSY, 0, -1, _minDollyZPos, _maxDollyZPos);
        }
        else
        {
            _targetRotation = Quaternion.Euler(_defaultPitch, 0, 0);
        }

        _pitch.rotation = Quaternion.Slerp(_pitch.rotation, _targetRotation, _pitchSpeed * Time.deltaTime);
        //_dolly.position = Vector3.MoveTowards(_dolly.position, _targetDollyZposition, _dollySpeed *Time.deltaTime);
    }

    private void ReadCameraMouseInput()
    {
        Vector2 mousePos = Input.mousePosition;

        if (mousePos.y > Screen.height*0.75f)
        {
            _targetRotation = Quaternion.Euler(_minPitch, 0, 0);
        }
        else
        {
            _targetRotation = Quaternion.Euler(_defaultPitch, 0, 0);
        }

        _pitch.rotation = Quaternion.Slerp(_pitch.rotation, _targetRotation, _pitchSpeed * Time.deltaTime);
    }
}
