using UnityEngine;

public class CubeScaleChanger : MonoBehaviour
{
    public void ChangeScale(Vector3 scale)
    {
        transform.localScale = scale / 2;
    }
}
