using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    private float _verticalInput;
    private float _horizontalInput;

    private Rigidbody _rb;

    public float JumpVelocity = 5f;
    private bool _isJumping;
    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _capsuleCollider;

    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;

    private GameBehaviour _gameManager;

    void Start()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            _rb = GetComponent<Rigidbody>();
        } else
        {
            this.AddComponent<Rigidbody>();
            _rb = GetComponent<Rigidbody>();
        }

        _capsuleCollider = GetComponent<CapsuleCollider>();

        _gameManager = GameObject.Find("Game_Manager")
            .GetComponent<GameBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        _isJumping |= Input.GetKeyDown(KeyCode.Space);
        _isShooting |= Input.GetMouseButtonDown(0);

        _horizontalInput = Input.GetAxis("Horizontal") * RotateSpeed;
        _verticalInput = Input.GetAxis("Vertical") * MoveSpeed;

        //this.transform.Translate(
        //    _verticalInput * Time.deltaTime * Vector3.forward
        //);

        //this.transform.Rotate(
        //    _horizontalInput * Time.deltaTime * Vector3.up
        //);
    }

    void FixedUpdate()
    {
        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(
                Vector3.up * JumpVelocity,
                ForceMode.Impulse
            );
        }

        // stop allowing jumps after a jump is peformed
        _isJumping = false;

        if (_isShooting)
        {
            GameObject newBullet = Instantiate(
                Bullet,
                this.transform.position + new Vector3(1, 0, 0),
                this.transform.rotation
            );

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * BulletSpeed;
        }

        // stop allowing shots after a shot is performed
        _isShooting = false;

        Vector3 rotation = Vector3.up * _horizontalInput;

        Quaternion angleRotation = Quaternion.Euler(
            rotation * Time.fixedDeltaTime
        );

        _rb.MovePosition(
            this.transform.position
            + (this.transform.forward * _verticalInput * Time.fixedDeltaTime)
        );

        // Any physics- or Rigidbody-related code always goes inside the FixedUpdate
        // method, rather than Update or the other MonoBehavior methods
        _rb.MoveRotation(
            _rb.rotation * angleRotation
        );
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(
            _capsuleCollider.bounds.center.x,
            _capsuleCollider.bounds.min.y,
            _capsuleCollider.bounds.center.z
        );

        bool grounded = Physics.CheckCapsule(
            _capsuleCollider.bounds.center,
            capsuleBottom,
            DistanceToGround,
            GroundLayer,
            QueryTriggerInteraction.Ignore
        );

        return grounded;
    }
}


