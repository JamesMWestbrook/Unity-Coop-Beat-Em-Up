using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Be Sure To Include This
using UnityEngine.Experimental.Input;

public class targetController : MonoBehaviour
{
    [SerializeField] private NewControls controls;

    public Camera Cam; //Main Camera
    private enemyInView target; //Current Focused Enemy In List
    private Image image;//Image Of Crosshair

    bool lockedOn;//Keeps Track Of Lock On Status    

    //Tracks Which Enemy In List Is Current Target
    int lockedEnemy;

    //List of nearby enemies
    public static List<enemyInView> nearByEnemies = new List<enemyInView>();

    void Start()
    {
        //cam = Camera.main;
        image = GetComponent<Image>();
        
        lockedOn = false;
        lockedEnemy = 0;
    }

    private void OnEnable()
    {

        controls.Player.LockOn.performed += _ => LockOn();
        controls.Player.LockOn.Enable();

        controls.Player.SwitchLockOn.performed += _ => SwitchLockOn();
        controls.Player.SwitchLockOn.Enable();
    }

    private void OnDisable()
    {
        controls.Player.LockOn.performed -= _ => LockOn();
        controls.Player.LockOn.Disable();

        controls.Player.SwitchLockOn.performed -= _ => SwitchLockOn();
        controls.Player.SwitchLockOn.Disable();
    }


    void Update()
    {
        
        

        //Press X To Switch Targets
        if (Input.GetKeyDown(KeyCode.X))
        {
            
        }

        if (lockedOn)
        {
            if(nearByEnemies.Count >= 1)
            {

                target = nearByEnemies[lockedEnemy];

                //Determine Crosshair Location Based On The Current Target
                gameObject.transform.position = Cam.WorldToScreenPoint(target.transform.position);

                //Rotate Crosshair
                gameObject.transform.Rotate(new Vector3(0, 0, -1));
            }

        }
    }


    //Press Left Ctr to lock on
    void LockOn()
    {
        if (!lockedOn)
        {
            if (nearByEnemies.Count >= 1)
            {
                lockedOn = true;
                image.enabled = true;

                //Lock On To First Enemy In List By Default
                lockedEnemy = 0;
                target = nearByEnemies[lockedEnemy];
            }
        }
        //Turn Off Lock On When Space Is Pressed Or No More Enemies Are In The List
        else if (lockedOn || nearByEnemies.Count == 0)
        {
            lockedOn = false;
            image.enabled = false;
            lockedEnemy = 0;
            target = null;
        }

    }

    void SwitchLockOn()
    {

        if (lockedEnemy == nearByEnemies.Count - 1)
        {
            //If End Of List Has Been Reached, Start Over
            lockedEnemy = 0;
            target = nearByEnemies[lockedEnemy];
        }
        else
        {
            //Move To Next Enemy In List
            lockedEnemy++;
            target = nearByEnemies[lockedEnemy];
        }
        Debug.Log("Switching lock on working");
    }
}