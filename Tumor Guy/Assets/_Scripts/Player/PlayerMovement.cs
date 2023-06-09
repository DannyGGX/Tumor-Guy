using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float movementSpeed = 5;
    private Vector2 moveDirection;

    [Space]
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 15;
    [SerializeField] private Camera camera;
    private Quaternion rotation;
    private const float ROTATION_OFFSET = -90;


    private void Update()
    {
        if(GameManager.Instance.ControlsEnabled == false)
            return;

        GetInputs();
    }

    private void FixedUpdate()
    {
        Move();
        RotateTowardsMouse();
    }

    private void GetInputs()
    {
        moveDirection = GetMovementInputs();
        rotation = GetRotationInput();
    }
    private Vector2 GetMovementInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        return new Vector2(moveX, moveY).normalized;
    }
    private Quaternion GetRotationInput()
    {
        Vector2 direction = camera.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + ROTATION_OFFSET;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Move()
    {
        rigidbody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed) * Time.fixedDeltaTime;
    }
    private void RotateTowardsMouse()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
    }

    private void Dash()
    {

    }
}
