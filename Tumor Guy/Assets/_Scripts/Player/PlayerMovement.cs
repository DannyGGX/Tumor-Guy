using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float movementSpeed = 5;
    private Vector2 moveDirection;
    [Space]
    [Header("Dash")]
    [SerializeField] private float dashSpeed = 10;
    [SerializeField] private float dashDuration = 1;
    [SerializeField] private float dashCoolDown = 0.7f;
    private bool isDashing = false;
    private bool canDash = true;
    [SerializeField] private GameObject playerBody;
    [SerializeField] private string playerDashTag;
    [Space]
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 15;
    [SerializeField] private Camera camera;
    private Quaternion rotation;
    private const float ROTATION_OFFSET = -90;

    private PlayerStats stats;

    private void OnEnable()
    {
        stats = new PlayerStats();
        //SetStats();

    }
    private void OnDisable()
    {
        
    }

    private void Update()
    {
        if(GameManager.Instance.ControlsEnabled == false)
            return;

        GetInputs();
    }

    private void FixedUpdate()
    {
        if (isDashing) return;
        Move();
        RotateTowardsMouse();
    }

    private void GetInputs()
    {
        if (isDashing)
            return;

        moveDirection = GetMovementInputs();

        if(canDash && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(nameof(Dash));
        }

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
        Vector2 direction = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + ROTATION_OFFSET;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Move()
    {
        rigidbody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed) * Time.fixedDeltaTime;
    }
    private void RotateTowardsMouse()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        playerBody.tag = playerDashTag; // To not take damage from bullets
        rigidbody.velocity = transform.up * dashSpeed;
        //rigidbody.AddForce(new Vector2(transform.up.x * dashSpeed, transform.up.y * dashSpeed));
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        playerBody.tag = "Player";
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }

    private void SetStats()
    {
        float[] currentStats = stats.GetStats(GameManager.Instance.KnockOutAmount);


    }
}
