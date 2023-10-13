using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 _camOffset = new Vector3(0f, 1.2f, -2.6f);
    [SerializeField] private Transform _target;
    
    void LateUpdate()
    {
        transform.position = _target.TransformPoint(_camOffset);
        transform.LookAt(_target);
    }
}