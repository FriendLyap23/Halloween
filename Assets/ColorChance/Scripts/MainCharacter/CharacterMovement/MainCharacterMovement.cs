using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MainCharacterMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;

    private Vector3 _direction;
    private float moveHorizontal;
    private float moveVertical;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private void Awake()
    {
        _rigidbody ??= GetComponent<Rigidbody>();
        _animator ??= GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            _animator.SetBool("isSpeed", true);
        else
            _animator.SetBool("isSpeed", false);
    }

    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        _direction = new Vector3(moveHorizontal,0, moveVertical);
       
        _rigidbody.velocity = Vector3.ClampMagnitude(_direction, 1)  * _speed;

        RotateCharacter();
    }

    private void RotateCharacter() 
    {
        if (_direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
