using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left,
    Right
}

public class A_Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float _moveSpeed;
    private float _leftStickMovementCutoff = 0.1f;

    public Direction facingDirection;

    private void Update()
    {
        if (!Actor.i.paused)
        {
            ReadMovementInput();

        }
    }

    private void ReadMovementInput()
    {
        if (Mathf.Abs(Actor.i.input.LSX) > _leftStickMovementCutoff || Mathf.Abs(Actor.i.input.LSY) > _leftStickMovementCutoff)
        {
            if (Actor.i.input.LSX > 0)
            {
                facingDirection = Direction.Right;
            }
            else
            {
                facingDirection = Direction.Left;
            }

            Vector3 direction = new Vector3(Actor.i.input.LSX, 0, Actor.i.input.LSY);

            _rb.velocity = direction.normalized * _moveSpeed * Time.deltaTime;
        }
    }
}
