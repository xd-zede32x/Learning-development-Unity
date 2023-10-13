using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeedPlayer = 7;
    [SerializeField] private float _rotateSpeedPlayer = 75;

    private Rigidbody _rigidbody;

    private float _verticalInput;
    private float _horizontalInput;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PressingKeys();
    }

    private void FixedUpdate()
    {
        PlayerMovements();
    }

    private void PlayerMovements()
    {
        Vector3 rotation = Vector3.up * _horizontalInput;
        Quaternion angleRotate = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rigidbody.MovePosition(this.transform.position + this.transform.forward * _verticalInput * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * angleRotate);
    }

    private void PressingKeys()
    {
        _verticalInput = Input.GetAxis("Vertical") * _moveSpeedPlayer;
        _horizontalInput = Input.GetAxis("Horizontal") * _rotateSpeedPlayer;
    }
}