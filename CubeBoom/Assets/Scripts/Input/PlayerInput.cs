using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CubeFindingRay _cubeFindingRay;

    private InputController _inputController;

    private void Awake()
    {
        _inputController = new InputController();

        _inputController.ScorerActionMap.Activating.performed += OnClick;
    }

    private void OnEnable()
    {
        _inputController.Enable();
    }

    private void OnDisable()
    {
        _inputController.Disable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("Click");
        _cubeFindingRay.CreateRay();
    }
}
