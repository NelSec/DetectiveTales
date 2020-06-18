using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float maxAngularAcceleration = 2000.0f;
    private const float maxForwardAcceleration = 10.0f;
    private const float maxBackwardAcceleration = 10.0f;
    private const float maxStrafeAcceleration = 10.0f;
    private const float gravityAcceleration = 20.0f;

    private const float maxAngularVelocity = 100.0f;
    private const float maxForwardVelocity = 2.0f;
    private const float maxBackwardVelocity = 2.0f;
    private const float maxStrafeVelocity = 3.0f;
    //private const float maxFallVelocity = 30.0f;

    private const float walkVelocityFactor = 2.0f;
    private const float runVelocityFactor = 4.0f;

    private CharacterController controller;

    private float angularAcceleration;
    private float angularVelocity;
    private float angularMotion;
    private Vector3 acceleration;
    private Vector3 velocity;
    private Vector3 motion;
    private float velocityFactor;

    public Animator characterAnim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        angularAcceleration = 0f;
        angularVelocity = 0f;
        acceleration = Vector3.zero;
        velocity = Vector3.zero;
        velocityFactor = runVelocityFactor;
    }

    void Update()
    {
        UpdateVelocityFactor();
        UpdateRotation();
        CheckForMovement();
    }

    private void UpdateVelocityFactor()
    {
        velocityFactor =
            !Input.GetButton("Walk") ? walkVelocityFactor : runVelocityFactor;
    }

    private void UpdateRotation()
    {
        UpdateKeyRotation();
    }

    private void UpdateKeyRotation()
    {
        angularAcceleration = Input.GetAxis("Horizontal") * 
            maxAngularAcceleration * velocityFactor;

        if (angularAcceleration != 0)
        {
            angularVelocity += angularAcceleration * Time.deltaTime;
            angularVelocity = Mathf.Clamp(
                angularVelocity, -maxAngularVelocity * 
                velocityFactor, maxAngularVelocity * velocityFactor);

            angularMotion = angularVelocity * Time.deltaTime;

            transform.Rotate(0f, angularMotion, 0f);
        }
        else
            angularVelocity = 0f;
    }

    void FixedUpdate()
    {
        UpdateAcceleration();
        UpdateVelocity();
        UpdatePosition();
    }

    private void UpdateAcceleration()
    {
        acceleration.z = Input.GetAxis("Vertical");
        acceleration.z *= (
            acceleration.z > 0 ? maxForwardAcceleration :
            maxBackwardAcceleration) * velocityFactor;

        acceleration.x *= maxStrafeAcceleration * velocityFactor;

        /*if (controller.isGrounded)
            acceleration.y = 0f;
        else
            acceleration.y = -gravityAcceleration;*/
    }

    private void UpdateVelocity()
    {
        velocity += acceleration * Time.fixedDeltaTime;

        velocity.z = acceleration.z == 0f ? 0f : Mathf.Clamp(
            velocity.z, -maxBackwardVelocity * 
            velocityFactor, maxForwardVelocity * velocityFactor);
        velocity.x = acceleration.x == 0f ? 0f : Mathf.Clamp(
            velocity.x, -maxStrafeVelocity * 
            velocityFactor, maxStrafeVelocity * velocityFactor);
        /*velocity.y = acceleration.y == 0f ? -0.1f : Mathf.Clamp(
            velocity.y, -maxFallVelocity, maxFallVelocity);*/
    }

    private void UpdatePosition()
    {
        motion = transform.TransformVector(velocity * Time.fixedDeltaTime);

        controller.Move(motion);
    }

    void CheckForMovement()
    {
        if (velocityFactor != 0.1)
            characterAnim.SetBool("Walking", true);
        else if (velocityFactor < 0.1)
            characterAnim.SetBool("Walking", false);

    }
}
