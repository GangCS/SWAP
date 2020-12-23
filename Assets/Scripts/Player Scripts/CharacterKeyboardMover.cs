using System;
using System.Collections;
using TMPro;
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
    private Vector3 velocity;

    //RayCast
    [SerializeField] bool drawRayForDebug = true;
    [SerializeField] float rayLength = 100f;
    [SerializeField] float rayDuration = 1f;
    [SerializeField] Color rayColor = Color.white;

    private CharacterController _cc;
    private Vector3 ScreenMiddle;
    private Ray rayFromCameraToClickPosition;


    void Start()
    {
        _cc = GetComponent<CharacterController>();
        currSpeed = _speed;
        ScreenMiddle = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }
    
    
    void Update()
    {
        rayFromCameraToClickPosition = Camera.main.ScreenPointToRay(ScreenMiddle);

        if (drawRayForDebug)
            Debug.DrawRay(rayFromCameraToClickPosition.origin, rayFromCameraToClickPosition.direction * rayLength, rayColor, rayDuration);


        drawOutlineToBox(); // make the red outline if the ray is at box

        setVelocityAndDirection();
        moveCharacter();

        if (!_cc.isGrounded) //if character is NOT standing on the ground
        {
            enableGravity();
        }
        else // player is on the ground
        {
            if (Input.GetKeyDown(KeyCode.Space))//space button pressed - jump
            {
                Jump();
            }
            if(Input.GetKeyDown(KeyCode.LeftShift))//shift button pressed - walk faster
            {
                walkFaster();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))//shift button unpressed - walk regular speed
            {
                walkNormal();
            }
        }
    }
    private void setVelocityAndDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        velocity.x = x * currSpeed;
        velocity.z = z * currSpeed;
        velocity = transform.TransformDirection(velocity);
    }
    private void moveCharacter()
    {
        _cc.Move(velocity * Time.deltaTime); // Moving the character in pressed direction / Per Frame
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)//character collision
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
    private void enableGravity()
    {
        velocity.y -= _gravity * Time.deltaTime;
    }
    private void Jump()
    {
        velocity.y = 0;
        velocity.y += _jumpheight;
    }
    private void walkFaster()
    {
        currSpeed = _speed * 2;
    }
    private void walkNormal()
    {
        currSpeed = _speed;
    }
    private void drawOutlineToBox()
    {
        RaycastHit hittedBox;
        bool hasHit = Physics.Raycast(rayFromCameraToClickPosition, out hittedBox);
        if (hasHit)
        {
            if (hittedBox.transform.gameObject.tag == "Box") //ray hit box
            {
                hittedBox.transform.gameObject.GetComponent<Outline>().enabled = true; // make the red outline to the box
            }
        }
    }
}
