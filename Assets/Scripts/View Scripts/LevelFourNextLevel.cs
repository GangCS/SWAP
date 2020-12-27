using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFourNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float time = 5f;
    [SerializeField] GameObject Player;

    [SerializeField] Transform Pos1;
    [SerializeField] Transform Pos2;
    [SerializeField] GameObject Door;
    private float currTime;
    private bool OneTime = false;
    private bool done = false;
    private Vector3 playerPos;
    void Start()
    {
        currTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-currTime >= time)
        {
           
            if (!OneTime)
            {
                Door.GetComponent<RotatingDoor>().performAction();
                LerpFirstPos();
            }
        }
        if(OneTime && !done)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, playerPos, 2f * Time.deltaTime);
        }

    }
    private void LerpFirstPos()
    {
        //Make sounds from the narrator
        Player.GetComponent<CharacterController>().enabled = false;
        //Player.transform.position = Vector3.Lerp(Player.transform.position, Pos1.position, 2f*Time.deltaTime);
        playerPos = Pos1.position;
        Invoke("LerpSecondPos", 2f);
        OneTime = true;
      
    }
    private void LerpSecondPos()
    {
        //Player.transform.position = Vector3.Lerp(Player.transform.position, Pos2.position, 2f*Time.deltaTime);
        playerPos = Pos2.position;
        Invoke("closeDoor", 2f);
    }
    private void closeDoor()
    {
        Player.GetComponent<CharacterController>().enabled = true;
        Door.GetComponent<RotatingDoor>().undoAction();
        playerPos = Player.transform.position;
        done = true;
        Invoke("transferNextLevel", 2f);
    }
    private void transferNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
