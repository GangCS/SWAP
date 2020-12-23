using UnityEngine;
public class LookY : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 1f;

    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
        Vector3 rotation = transform.localEulerAngles;
        rotation.x -= _mouseY * _speedRotation;
        if (rotation.x <= 90f || rotation.x >= 270)
        {
            transform.localEulerAngles = rotation;
        }
    }
}
