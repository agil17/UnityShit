using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private PlayerInputAction InputActions;
    private Vector2 movementInput;
    float speedRotate = 100.0f;
    Animator anim;

    [SerializeField]
    public float walk = 2f;
    public float run = 7f;
    private float speed;
    private bool isRunning;

    private Vector3 inputDirection;
    private Vector3 moveVector;
    private Quaternion currentRotation;

    private void Awake()
    {
        InputActions = new PlayerInputAction();
        anim = GetComponent<Animator>();
        InputActions.Player.Move.performed += context => movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        float h = movementInput.x;
        float v = movementInput.y;


        Vector3 targetInput = new Vector3(h, 0, v);

        inputDirection = Vector3.Lerp(inputDirection, targetInput, Time.deltaTime * 10f);

        Vector3 canForward = Camera.main.transform.forward;
        Vector3 canRight = Camera.main.transform.right;
        canForward.y = 0f;
        canRight.y = 0f;

        Vector3 desiredDirection = canForward * inputDirection.z + canRight * inputDirection.x;

        Move(desiredDirection);
        Turn(desiredDirection);
    }

    void Move(Vector3 desiredDirection)
    {
        moveVector.Set(desiredDirection.x, 0f, desiredDirection.z);

        if (anim.GetFloat("Speed") < 1f)
            speed = walk;
        else
            speed = run;

        moveVector = moveVector * speed * Time.deltaTime;
        transform.position += moveVector;
    }

    void Turn(Vector3 desiredDirection)
    {
        /*if ((desiredDirection.x > 0.1 || desiredDirection.x < -0.1) || (desiredDirection.z > 0.1 || desiredDirection.x < -0.1))
        {
            currentRotation = Quaternion.LookRotation(desiredDirection);
            transform.rotation = currentRotation;
        }
        else
        {
            transform.rotation = currentRotation;
        }*/
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {

            if (keyboard.aKey.isPressed)
            {
                Vector3 rotation = new Vector3(0.0f, -1.0f * Time.deltaTime * speedRotate, 0.0f);
                transform.Rotate(rotation);
            }

            if (keyboard.dKey.isPressed)
            {
                Vector3 rotation = new Vector3(0.0f, 1.0f * Time.deltaTime * speedRotate, 0.0f);
                transform.Rotate(rotation);
            }
        }
    }

    private void OnEnable()
    {
        InputActions.Enable();
    }

    private void OnDisable()
    {
        InputActions.Disable();
    }
    }
