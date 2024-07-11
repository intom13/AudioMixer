using UnityEngine;

public class CubeScaleChanger : MonoBehaviour
{
    private readonly float _reductionScale = 2f;

    public void ChangeScale(Vector3 scale)
    {
        transform.localScale = scale / _reductionScale;
    }
}
