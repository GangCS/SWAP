using UnityEngine;
public class LookY : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 1f;
    Vector3 headRota;
    GameObject head;
    GameObject upDown;
    Vector3 upDownRota;
    Vector3 rotation;
    float _mouseY;

    private void Start()
    {
        GameObject sensativityScript = GameObject.Find("SensScript");
        if(sensativityScript != null)
        {
            _speedRotation = sensativityScript.GetComponent<SensHolder>().getSens();
        }
       
    }
    void Update()
    {
        _mouseY = Input.GetAxis("Mouse Y");
/*        head = GameObject.Find("Bip001 Head");
        upDown = GameObject.Find("upDown");*/
      //  headRota = head.transform.localEulerAngles;
        rotation = transform.localEulerAngles;
       // upDownRota = upDown.transform.localEulerAngles;
        rotation.x -= _mouseY * _speedRotation;
        //headRota.z += _mouseY * _speedRotation;
        //upDownRota.x -= _mouseY * _speedRotation;
        if (rotation.x <= 90f || rotation.x >= 270)
        {
            transform.localEulerAngles = rotation;
          //  head.transform.localEulerAngles = headRota;
          //  upDown.transform.localEulerAngles = upDownRota;
        }
    }
}
