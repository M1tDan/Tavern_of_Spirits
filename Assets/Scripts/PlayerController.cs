using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private float lastHorizontalMove = 1f; // 1 for right, -1 for left

    public Animator animator;

    public GameObject[] imageButtons;
    private CookingScript _cookingButtons;

    private void Start()
    {
        animator.SetInteger("IsMoving", 0);
        animator.SetFloat("AnimSpeed", 1);
        player.GetComponent<SpriteRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;

        _cookingButtons = GetComponent<CookingScript>();
    }

    private void FixedUpdate()
    {
        // Сбрасываем направление движения
        moveDirection = Vector3.zero;

        HandleJoystickInput();
        HandleKeyboardInput();

        // Нормализация направления движения
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        // Установка скорости перемещения
        _rigidbody.velocity = new Vector3(moveDirection.x * _moveSpeed, _rigidbody.velocity.y, moveDirection.z * _moveSpeed);

        // Обновление состояния анимации
        if (moveDirection.x != 0f || moveDirection.z != 0f)
        {
            animator.SetInteger("IsMoving", 1);
            if (moveDirection.x != 0f)
            {
                lastHorizontalMove = moveDirection.x;
            }
            animator.SetFloat("HorizontalMove", lastHorizontalMove);
        }
        else
        {
            animator.SetInteger("IsMoving", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (imageButtons[0].activeSelf == true)
            {
                return;
            }
            else if (imageButtons[1].activeSelf == true)
            {
                _cookingButtons.TakeCooking1();
            }
            else if (imageButtons[2].activeSelf == true)
            {
                _cookingButtons.TakeCooking2();
            }
            else if (imageButtons[3].activeSelf == true)
            {
                _cookingButtons.TakeCooking3();
            }
            else if (imageButtons[4].activeSelf == true)
            {
                _cookingButtons.TakeCooking4();
            }
            else if (imageButtons[5].activeSelf == true)
            {
                _cookingButtons.TakeCooking5();
            }
            else if (imageButtons[6].activeSelf == true)
            {
                _cookingButtons.ServeOrderFromHeadToChair();
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _cookingButtons.AddOrder();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveSpeed = 6;
            animator.SetFloat("AnimSpeed", 1.5f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _moveSpeed = 4;
            animator.SetFloat("AnimSpeed", 1f);
        }
    }

    private void HandleJoystickInput()
    {
        if (_joystick != null && (_joystick.Horizontal != 0f || _joystick.Vertical != 0f))
        {
            moveDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        }
    }

    private void HandleKeyboardInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0f || moveY != 0f)
        {
            moveDirection = new Vector3(moveX, 0, moveY);
        }
    }
}
