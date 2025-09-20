using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardObject : MonoBehaviour
{
    [SerializeField] private bool _isolateYRot = false;

    private void LateUpdate()
    {
        if (_isolateYRot)
        {
            Vector3 directionToCamera = Actor.i.cameraController.cameraTransform.position - transform.position;
            directionToCamera.y = 0;
            transform.rotation = Quaternion.LookRotation(directionToCamera);
        }
        else
        {
            transform.LookAt(Actor.i.cameraController.transform.position, Vector3.up);
        }
    }
}
