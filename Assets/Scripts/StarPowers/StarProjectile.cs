using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarProjectile : MonoBehaviour
{
    //check collision with ground layer
    //spawn AOE at place where contacted ground

    [SerializeField] private GameObject _collisionPfx;
    [SerializeField] private float _castForwardLength = 0.2f;
    [SerializeField] private float _castSize = 0.1f;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private LayerMask _targetLayerMask;




    private void FixedUpdate()
    {
        Physics.SphereCast(transform.position, _castSize, transform.forward, out RaycastHit hitInfo, _castForwardLength, _targetLayerMask);
        if (hitInfo.collider != null)
        {
            Instantiate(_collisionPfx, hitInfo.point, Quaternion.identity);

            Destroy(this.gameObject);
        }

        //move forwards with increased speed as it goes, but for now let's do just move forwards
        Vector3 targetPosition = transform.position + (transform.forward * _movementSpeed);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
    }

    /*Reserved for StarPower_Comet
    private void SpawnAOE(Vector3 pos)
    {
        float randomRot = Random.Range(0, 360);
        GameObject go = Instantiate(_aoePrefab, pos, Quaternion.Euler(0, randomRot, 0));
        go.transform.SetParent(null);
    }
    */
}
