using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This component performs player actions controlled with a different keys on the keyboard.
 */
public class PlayerActions : MonoBehaviour
{
    private GameObject Box = null;
    private Ray rayFromCameraToClickPosition;
    private Vector3 ScreenMiddle;
    private CharacterController _cc;
    [SerializeField] GameObject upDown = null;
    [SerializeField] AudioClip swapSound;
    [SerializeField] AudioClip throwSound;
    // Start is called before the first frame update
    void Start()
    {
        ScreenMiddle = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        _cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        rayFromCameraToClickPosition = Camera.main.ScreenPointToRay(ScreenMiddle);

        if (boxIsLifted())
        {
            Box = null; // box is not lifted
        }


        if (Input.GetKeyDown(KeyCode.Q))//Try to swap location with an object
        {
            SWAP();
        }

        if (Input.GetKeyDown(KeyCode.E))//Try to pick up/down an object
        {
            pickUp();
        }
        //Mouse left click && Box is not null when lifted by player
        if (Input.GetMouseButtonDown(0) && Box != null)
        {
            ThrowBox();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            pushButton();
        }
        
    }
    private void SWAP()
    {
        // this function SWAP position between the player and the box.

        RaycastHit hittedBox;
        bool hasHit = Physics.Raycast(rayFromCameraToClickPosition, out hittedBox);
        hasHit = Physics.Raycast(rayFromCameraToClickPosition, out hittedBox);
        if (hasHit)
        {
            if (hittedBox.collider.gameObject.tag == "Box")//ray hit box
            {
                AudioSource.PlayClipAtPoint(swapSound, transform.position, 1f);
                Vector3 oldPos = hittedBox.transform.position;
                hittedBox.transform.position = transform.position + new Vector3(0, 1, 0);//place the box in character position
                _cc.enabled = false; // we change _cc to false, make the Swap and then make it true again.
                transform.position = oldPos;//place the character in the box position
                _cc.enabled = true;
            }
        }
    }
    private bool boxIsLifted()
    {
        if (Box != null && !Box.GetComponent<Rigidbody>().isKinematic) // if box lifted
        {
            return true;
        }
        return false;
    }
    private void pickUp()
    {
        // This Function Pick up the box (makes it child of the player) and drop it down When E is pressed again.
        if (Box == null)// Box isn't lifted yet -> Lift the Box up
        {
            RaycastHit hittedBox;
            bool hasHit = Physics.Raycast(rayFromCameraToClickPosition, out hittedBox);
            if (hasHit && hittedBox.distance <= 4f && hittedBox.collider.gameObject.tag == "Box")//ray hit box and the box is close enough
            {
                Box = hittedBox.rigidbody.gameObject; // box isn't null now
                hittedBox.rigidbody.isKinematic = true;

                Vector3 positionForBox = Box.transform.position;
                positionForBox = Camera.main.transform.position + Camera.main.transform.forward*2;
                Box.transform.position = positionForBox;
                Box.transform.SetParent(upDown.transform); // lifting the box to character hands
                
            }
        }
        else // Leaving Box down When E is pressed again
        {
            Box.transform.SetParent(null);
            Box.GetComponent<Rigidbody>().isKinematic = false;
            Box = null;
        }
    }
    private void ThrowBox()
    {
        // this function throws the ball from the player
        AudioSource.PlayClipAtPoint(throwSound, transform.position, 1f);
        Box.transform.SetParent(null);
        Rigidbody rb = Box.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(rayFromCameraToClickPosition.direction * 10f, ForceMode.Impulse);//Throw the Box forward
        Box = null;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void pushButton()
    {
        RaycastHit hittedBox;
        bool hasHit = Physics.Raycast(rayFromCameraToClickPosition, out hittedBox);
        if (hasHit && hittedBox.distance <= 2f && hittedBox.collider.gameObject.tag == "Button")//ray hit box and the box is close enough
        {
            ButtonsScript bs = hittedBox.transform.gameObject.GetComponent<ButtonsScript>();
            bs.Click();
        }
    }
}
