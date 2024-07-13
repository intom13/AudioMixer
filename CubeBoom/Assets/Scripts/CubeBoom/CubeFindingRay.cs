using UnityEngine;

public class CubeFindingRay : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Ray _ray;

    private float _visibleRayDistance = 10f;

    public void CreateRay()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(_ray.origin, _ray.direction * _visibleRayDistance, Color.red);

        if(Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            Transform hittenObject = hit.transform;

            if (hittenObject.TryGetComponent(out CubeSeparator cubeSeparator))
            {
                cubeSeparator.CheckDivisionChance();
            }
        }
    }
}
