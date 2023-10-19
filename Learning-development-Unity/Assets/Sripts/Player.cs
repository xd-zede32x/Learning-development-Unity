using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeedPlayer = 7;
    [SerializeField] private float _rotateSpeedPlayer = 75;
    [SerializeField] private float _distanceToGround = 0.1f;
    [SerializeField] LayerMask _groundLayer;

    [Range(0, 3)]
    [SerializeField] private float _velocityJump = 1.2f;
    [SerializeField] private float _bulletSpeed = 100f;
    [SerializeField] private GameObject _bullet;

    private float _verticalInput;
    private Rigidbody _rigidbody;
    private float _horizontalInput;
    private GameManager _gameManager;
    private CapsuleCollider _capsuleCollider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        PressingKeys();
        Shot();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        Jump();
    }   

    private void PlayerMovement()
    {
        Vector3 rotation = Vector3.up * _horizontalInput;
        Quaternion angleRotate = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rigidbody.MovePosition(this.transform.position + this.transform.forward * _verticalInput * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * angleRotate);
    }

    private void Jump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _velocityJump, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Vector3 _capsuleBottom = new Vector3(_capsuleCollider.bounds.center.x,
            _capsuleCollider.bounds.min.y, _capsuleCollider.bounds.center.z);

        bool _grounded = Physics.CheckCapsule(_capsuleCollider.bounds.center, _capsuleBottom,
            _distanceToGround, _groundLayer, QueryTriggerInteraction.Ignore);

        return _grounded;
    }

    private void Shot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject _newBullet = Instantiate(_bullet, this.transform.position + new Vector3(1, 0, 0), Quaternion.identity) as GameObject;
            Rigidbody _rigidbodyBullet = _newBullet.GetComponent<Rigidbody>();

            _rigidbodyBullet.velocity = this.transform.forward * _bulletSpeed;
            Destroy(_newBullet, 5);
        }
    }

    private void PressingKeys()
    {
        _verticalInput = Input.GetAxis("Vertical") * _moveSpeedPlayer;
        _horizontalInput = Input.GetAxis("Horizontal") * _rotateSpeedPlayer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _gameManager.HealthPlayer -= 2;
        }
    }
}   