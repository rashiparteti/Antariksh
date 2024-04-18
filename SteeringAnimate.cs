using UnityEngine;

public class SteeringAnimate : MonoBehaviour
{
    [SerializeField]
    Transform _joystick;

    [SerializeField]
    Vector3 _joystickRange = new Vector3(20f, 25f, 32f);

    [SerializeField]
    Transform _throttle;

    [SerializeField]
    float _throttleRange = 30f;

    [SerializeField]
    float animationSpeed = 5f;

    void Update()
    {
        AnimateSteering();
        AnimateThrottle();
    }

    void AnimateSteering()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float pitchInput = Input.GetAxis("Pitch");
        float rollInput = Input.GetAxis("Roll");

        float pitch = Mathf.Clamp(pitchInput, -1f, 1f) * _joystickRange.x;
        float yaw = Mathf.Clamp(horizontalInput, -1f, 1f) * _joystickRange.y;
        float roll = Mathf.Clamp(rollInput, -1f, 1f) * _joystickRange.z;

        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
        _joystick.localRotation = Quaternion.Slerp(_joystick.localRotation, targetRotation, Time.deltaTime * animationSpeed);
    }

    void AnimateThrottle()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float throttleValue = Mathf.Clamp(verticalInput, 0f, 1f) * _throttleRange;

        Quaternion targetRotation = Quaternion.Euler(throttleValue, 0f, 0f);
        _throttle.localRotation = Quaternion.Slerp(_throttle.localRotation, targetRotation, Time.deltaTime * animationSpeed);
    }
}