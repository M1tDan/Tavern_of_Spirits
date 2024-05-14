using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] public float _moveSpeed = 4;
    private Vector3 moveDirection;

    public Animator animator;

    private void Start()
    {
         player.GetComponent<SpriteRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
    }

    private void FixedUpdate()
    {
        if (_joystick != null)
        {
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
            animator.SetInteger("IsMoving", 1);
            animator.SetFloat("HorizontalMove", _joystick.Horizontal);
        }
        else if (_joystick.Horizontal == 0f || _joystick.Vertical == 0f)
        {
            animator.SetInteger("IsMoving", 0);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector3(moveX, _rigidbody.velocity.y, moveY);

            _rigidbody.velocity = new Vector3(moveDirection.x * _moveSpeed, _rigidbody.velocity.y, moveDirection.z * _moveSpeed);

            if (moveDirection.x != 0f || moveDirection.z != 0f)
            {
                animator.SetInteger("IsMoving", 1);
                animator.SetFloat("HorizontalMove", moveDirection.x);
            }
            else
            {
                animator.SetInteger("IsMoving", 0);
            }
        }
    }
}
