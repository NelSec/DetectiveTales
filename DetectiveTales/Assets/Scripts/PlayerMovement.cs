using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float maxAngularAcceleration = 90.0f;
    private const float maxForwardAcceleration = 15.0f;
    private const float maxBackwardAcceleration = 10.0f;
    private const float maxStrafeAcceleration = 10.0f;
    private const float jumpAcceleration = 500.0f;
    private const float gravityAcceleration = 20.0f;

    private const float mouseAngularVelocityFactor = 5.0f;
    private const float maxAngularVelocity = 60.0f;
    private const float maxForwardVelocity = 4.0f;
    private const float maxBackwardVelocity = 2.0f;
    private const float maxStrafeVelocity = 3.0f;
    private const float maxJumpVelocity = 50.0f;
    private const float maxFallVelocity = 30.0f;

    private const float walkVelocityFactor = 1.0f;
    private const float runVelocityFactor = 2.0f;

    private CharacterController controller;

    private float angularAcceleration;
    private float angularVelocity;
    private float angularMotion;
    private Vector3 acceleration;
    private Vector3 velocity;
    private Vector3 motion;
    private float velocityFactor;
    private bool jump;
    private bool autoRun;
    private bool mouseWalk;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        angularAcceleration = 0f;
        angularVelocity = 0f;
        acceleration = Vector3.zero;
        velocity = Vector3.zero;
        velocityFactor = runVelocityFactor;
        jump = false;
        autoRun = false;
        mouseWalk = false;
    }

    void Update()
    {
        UpdateJump();
        UpdateVelocityFactor();
        UpdateAutoRun();
        UpdateMouseWalk();
        UpdateRotation();
        UpdateMouseLock();
    }

    private void UpdateVelocityFactor()
    {
        velocityFactor = autoRun || !Input.GetButtonDown("Walk") ?
            runVelocityFactor : walkVelocityFactor;
    }

    private void UpdateJump()
    {
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
            jump = true;
    }

    private void UpdateAutoRun()
    {
        if (Input.GetButtonDown("AutoRun"))
            autoRun = !autoRun;
        else if (autoRun && (Input.GetAxis("Forward") != 0 ||
            velocityFactor == walkVelocityFactor || mouseWalk))
            autoRun = false;
    }

    private void UpdateRotation()
    {
        if (Input.GetMouseButton(1))
            UpdateMouseRotation();
        else
            UpdateKeyRotation();
    }

    private void UpdateMouseRotation()
    {
        angularMotion = Input.GetAxis("Mouse X") * mouseAngularVelocityFactor;

        transform.Rotate(0f, angularMotion, 0f);
    }

    private void UpdateKeyRotation()
    {
        angularAcceleration = Input.GetAxis("Rotate") * maxAngularAcceleration *
            velocityFactor;

        if (angularAcceleration != 0)
        {
            angularVelocity += angularAcceleration * Time.deltaTime;
            angularVelocity = Mathf.Clamp(angularVelocity, -maxAngularVelocity *
                velocityFactor, maxAngularVelocity * velocityFactor);

            angularMotion = angularVelocity * Time.deltaTime;

            transform.Rotate(0f, angularMotion, 0f);
        }
        else
            angularVelocity = 0f;
    }

    private void UpdateMouseLock()
    {
        if (Input.GetMouseButtonDown(1))
            Cursor.lockState = CursorLockMode.Locked;
        else if (Input.GetMouseButtonUp(1))
            Cursor.lockState = CursorLockMode.None;
    }

    void FixedUpdate()
    {
        UpdateAcceleration();
        UpdateVelocity();
        UpdatePosition();
    }

    private void UpdateMouseWalk()
    {
        mouseWalk = Input.GetMouseButton(0) && Input.GetMouseButton(1) ||
            Input.GetMouseButton(2);
    }

    private void UpdateAcceleration()
    {
        acceleration.z = autoRun || mouseWalk ? 1f : Input.GetAxis("Forward");
        acceleration.z *= (acceleration.z > 0 ? maxForwardAcceleration :
            maxBackwardAcceleration) * velocityFactor;

        acceleration.x = Input.GetAxis("Strafe");
        acceleration.x *= maxStrafeAcceleration * velocityFactor;

        if (jump)
        {
            jump = false;
            acceleration.y = jumpAcceleration;
        }
        else if (controller.isGrounded)
            acceleration.y = 0f;
        else
            acceleration.y = -gravityAcceleration;
    }

    private void UpdateVelocity()
    {
        velocity += acceleration * Time.fixedDeltaTime;

        velocity.z = acceleration.z == 0f ? 0f : Mathf.Clamp(velocity.z,
            -maxBackwardVelocity * velocityFactor,
            maxForwardVelocity * velocityFactor);
        velocity.x = acceleration.x == 0f ? 0f : Mathf.Clamp(velocity.x,
            -maxStrafeVelocity * velocityFactor,
            maxStrafeVelocity * velocityFactor);
        velocity.y = acceleration.y == 0f ? -0.1f : Mathf.Clamp(velocity.y,
            -maxFallVelocity, maxJumpVelocity);
    }

    private void UpdatePosition()
    {
        motion = transform.TransformVector(velocity * Time.fixedDeltaTime);

        controller.Move(motion);
    }
}
