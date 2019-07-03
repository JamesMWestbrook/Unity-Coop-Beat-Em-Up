﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MageAI : NetworkBehaviour
{
    private Actor actor;
    private Rigidbody rb;


    [SerializeField] private Animator animator;
    [SerializeField] private NetworkAnimator nAnimator;

   public List<GameObject> Players;

    public float closestDistance;
    public GameObject ClosestPlayer;

    // Start is called before the first frame update
    void Start()
    {
        actor = GetComponent<Actor>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    public bool IsMoving;
    public bool Inactive = true;
    public bool IsAttacking;

    [Server]
    void FixedUpdate()
    {
        if (Input.GetButton("Submit"))
        {
            GetPlayers();
        }
        if (Inactive)
        {
            WhenInActive();
            GetClosestPlayer();
            return;
        }
        if(closestDistance > 10)
        {
            Debug.Log("Less than 10");
            animator.SetBool("Running", true);

            Vector3 pos = rb.position;
            Vector3 target = ClosestPlayer.GetComponent<Rigidbody>().position;

            pos += target * actor.MoveSpeed * Time.deltaTime;

            rb.MoveRotation(Quaternion.LookRotation(target));
            rb.MovePosition(pos);
            return;

        }
        else
        {
            if (!IsAttacking)
            {
                int i = Random.Range(0, 10);
                if (i < 10)
                {
                    animator.SetTrigger("Attack");
                    nAnimator.SetTrigger("Attack");
                }
                else
                {
                    //idle
                }
            }
            


        }
    }

    void WhenInActive()
    {
        if (closestDistance > 50)
        {
            return;
        }
        else //is closer than 50
        {
            Inactive = false;
        }
    }

    [Server]
    public void GetPlayers()
    {

        List<GameObject> players = new List<GameObject>();
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        Players.Clear();

        for(int i = 0; i < players.Count; i++)
        {
            Players.Add(players[i]);
        }
        Debug.Log("Player added");
    }

    void GetClosestPlayer()
    {
        
        if (closestDistance == 0f)
        {
            closestDistance = Vector3.Distance(Players[0].transform.position, transform.position);
            closestDistance = TurnPositive(closestDistance);
            ClosestPlayer = Players[0];

            Debug.Log("Was 0");
        }
        for(int i = 1; i < Players.Count; i++)
        {
            float _secondDistance = Vector3.Distance(   Players[i].transform.position, transform.position);
            _secondDistance = TurnPositive(_secondDistance);

            if (_secondDistance < closestDistance)
            {
                closestDistance = _secondDistance;
                ClosestPlayer = Players[i];
            }
        }
    }

    float TurnPositive(float number)
    {
        if(number < 0)
        {
            return number * -1;
        }
        else
        {
            return number;
        }
    }

}
