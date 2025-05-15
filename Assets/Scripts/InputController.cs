using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private GameControls _gameControls;

    public event Action JumpEvent;
    public event Action JumpEventCanceled;
    public event<Vector2> MoveEvent;
    
    private void Awake()
    {
        _gameControls = new GameControls();
    }

       private void OnEnable()
       {
           _gameControls.Player.Enable();

           _gameControls.Player.Move.performed += OnMovePerformed;
           _gameControls.Player.Jump.performed += OnJumpPerformed;
           _gameControls.Player.Jump.canceled += OnJumpCanceled;
       }

       private void OnMovePerformed(InputAction.CallbackContext context)
       {
           Debug.Log("OnMovePerformed");
       }
       private void OnJumpPerformed(InputAction.CallbackContext context)
       {
           JumpEvent?.Invoke();
           Debug.Log("OnJumpPerformed");
       }

       private void OnJumpCanceled(InputAction.CallbackContext context)
       {
           Debug.Log("OnJumpCanceled");
       }
}
