using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CubeFindingRay _cubeFindingRay;

    private InputController _inputController;

    private void Awake()
    {
        _inputController = new InputController();
    }

    private void OnEnable()
    {
        _inputController.Enable();
        _inputController.ScorerActionMap.Activating.performed += OnClick;
    }

    private void OnDisable()
    {
        _inputController.ScorerActionMap.Activating.performed -= OnClick;
        _inputController.Disable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        _cubeFindingRay.CreateRay();
    }
}
