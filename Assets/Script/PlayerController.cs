using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour, IPlayerActions
{
    [SerializeField] float _moveSpeed = 5.0f;
    [SerializeField] float _rotationSpeed = 1f;
    private InputSystem_Actions _actions;
    private Rigidbody _rb;
    private Animator _animator;
    private Vector2 _moveInput;

    private void Awake()
    {
        _actions = new();
        _actions.Enable();
        _actions.Player.SetCallbacks(this);
    }

    private void OnDisable()
    {
        _actions.Player.RemoveCallbacks(this);
        _actions.Disable();
        _actions.Dispose();
        _actions = null;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_moveInput != Vector2.zero)
        {
            Vector3 direction = new Vector3(_moveInput.x, 0f, _moveInput.y);
            //Quaternion toRote = Quaternion.LookRotation(direction,Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation,toRote,_rotationSpeed);
            //this.transform.forward = direction;
            transform.forward = Vector3.Lerp(transform.forward, direction, _rotationSpeed * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_moveInput.x, 0f, _moveInput.y);
        _rb.linearVelocity = movement * _moveSpeed;
        //Debug.Log($"movement{movement} moveSpeed{_moveSpeed} moveInput{_moveInput.magnitude}");
    }
    private void LateUpdate()
    {
        _animator.SetFloat("MoveSpeed",_moveInput.magnitude);
        //Debug.Log(_rb.linearVelocity.magnitude);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        // throw new System.NotImplementedException();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }
}
