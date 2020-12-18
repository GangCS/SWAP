using System.Collections;
using UnityEngine;


/**
 * This component moves a player controlled with a CharacterController using the keyboard.
 */
[RequireComponent(typeof(CharacterController))]
public class CharacterKeyboardMover : MonoBehaviour
{
    [Tooltip("Speed of player keyboard-movement, in meters/second")]
    [SerializeField] float _speed = 3.5f;
    private float currSpeed;
    [SerializeField] float _gravity = 9.81f;
    [SerializeField] float _jumpheight = 100f;
    //RayCast
    [SerializeField] bool drawRayForDebug = true;
    [SerializeField] float rayLength = 100f;
    [SerializeField] float rayDuration = 1f;
    [SerializeField] Color rayColor = Color.white;
    [SerializeField] GameObject upDown = null;
    private GameObject Box = null;
    private CharacterController _cc;
    [SerializeField]
    Texture2D crosshairImage;
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        currSpeed = _speed;
    }
        void OnGUI()
        {
        /* float xMin = Input.mousePosition.x-7;
         float yMin = Input.mousePosition.y-8;*/
        float xMin = (Screen.width - Input.mousePosition.x) - (crosshairImage.width / 4);
        float yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 4);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width/4, crosshairImage.height/4), crosshairImage);
        }
    
    Vector3 velocity;
    void Update()
    {
        Ray rayFromCameraToClickPosition = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (drawRayForDebug)
            Debug.DrawRay(rayFromCameraToClickPosition.origin, rayFromCameraToClickPosition.direction * rayLength, rayColor, rayDuration);

        RaycastHit hitInfo;
        bool hasHit = Physics.Raycast(rayFromCameraToClickPosition, out hitInfo);
        if (hasHit)
        {
            if(hitInfo.transform.gameObject.tag == "Box")
            {
                // hitInfo.
                hitInfo.transform.gameObject.GetComponent<Outline>().enabled = true;
            }
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        velocity.x = x * currSpeed;
        velocity.z = z * currSpeed;
        if (!_cc.isGrounded)
        {
            velocity.y -= _gravity * Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = 0;
                velocity.y += _jumpheight;
            }
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                currSpeed =_speed* 2;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                currSpeed = _speed;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            //
            rayFromCameraToClickPosition = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (drawRayForDebug)
                Debug.DrawRay(rayFromCameraToClickPosition.origin, rayFromCameraToClickPosition.direction * rayLength, rayColor, rayDuration);

            hasHit = Physics.Raycast(rayFromCameraToClickPosition, out hitInfo);
            if (hasHit)
            {
              //hitInfo.
              if(hitInfo.collider.gameObject.tag == "Box")
              {
                    Vector3 oldPos = hitInfo.transform.position;
                    
                    hitInfo.transform.position = transform.position + new Vector3(0, 1, 0);
                    _cc.enabled = false;
                    transform.position = oldPos;
                    _cc.enabled = true;
                }
            }
        }
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Box == null)
            {
                rayFromCameraToClickPosition = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (drawRayForDebug)
                    Debug.DrawRay(rayFromCameraToClickPosition.origin, rayFromCameraToClickPosition.direction * rayLength, rayColor, rayDuration);

                hasHit = Physics.Raycast(rayFromCameraToClickPosition, out hitInfo);
                if (hasHit && hitInfo.distance <= 4f && hitInfo.collider.gameObject.tag == "Box")
                {
                    Box = hitInfo.rigidbody.gameObject;
                    hitInfo.rigidbody.isKinematic = true;
                    Vector3 pos = Box.transform.position;
                    pos.y = 1;
                    Box.transform.position = pos;
                    Box.transform.SetParent(upDown.transform);
                }
            }
           else
            {
                Debug.Log("ELSE");
                Box.transform.SetParent(null);
                Box.GetComponent<Rigidbody>().isKinematic = false;
                Box = null;
            }
        }
        if(Box!=null && Input.GetMouseButtonDown(0))
        {
            Box.transform.SetParent(null);
            Rigidbody rb = Box.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(rayFromCameraToClickPosition.direction * 15f, ForceMode.Impulse);
            Box = null;
           
        }
       
        
        velocity = transform.TransformDirection(velocity);
        _cc.Move(velocity * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag != "Floor")
        {
            Rigidbody body = hit.collider.attachedRigidbody;
            // no rigidbody
            if (body == null || body.isKinematic)
            {
                return;
            }

            // We dont want to push objects below us
            if (hit.moveDirection.y < -0.3)
            {
                return;
            }

            // Calculate push direction from move direction,
            // we only push objects to the sides never up and down
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            // If you know how fast your character is trying to move,
            // then you can also multiply the push velocity by that.

            // Apply the push
            body.velocity = pushDir * currSpeed;

        }
    }
}
