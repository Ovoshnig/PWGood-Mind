using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private int _value;

    private void OnValidate()
    {
        Application.targetFrameRate = _value;
    }
}
