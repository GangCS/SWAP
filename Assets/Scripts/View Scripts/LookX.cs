using UnityEngine;
public class LookX : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 1f;

    private void Start()
    {
        GameObject sensativityScript = GameObject.Find("SensScript");
        if (sensativityScript != null)
        {
            _speedRotation = sensativityScript.GetComponent<SensHolder>().getSens();
        }
    }
    void Update()
    {
        if (!PauseScript.gameIsPaused)
        {
            float _mouseX = Input.GetAxis("Mouse X");
            Vector3 rotation = transform.localEulerAngles;
            rotation.y += _mouseX * _speedRotation;
            transform.localEulerAngles = rotation;
        }
    }
}
