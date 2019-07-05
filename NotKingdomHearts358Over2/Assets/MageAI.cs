using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MageAI : NetworkBehaviour
{
    [SerializeField] private Actor actor;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Target goToTarget;

    [SerializeField] private Animator animator;
    [SerializeField] private NetworkAnimator nAnimator;


    public List<GameObject> Players;

    [SerializeField] private float attackingDistance;

    public float closestDistance;
    public GameObject ClosestPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    public bool IsMoving;
    public bool Inactive = true;
    public bool IsAttacking;

    [Server]
    void FixedUpdate()
    {
        if (Players.Count >= 1)
        {
            if (Inactive)
            {
                WhenInActive();
                
                return;
            }
            GetClosestPlayer();
            Vector3 pos = rb.position;
            Vector3 target = ClosestPlayer.GetComponent<Rigidbody>().position;
            if (closestDistance > attackingDistance)
            {
                IsMoving = true;
                animator.SetBool("Running", true);

                goToTarget.GoToTarget(target, GetComponent<Actor>().MoveSpeed);
                transform.LookAt(target);

                return;

            }
            else
            {
                IsMoving = false;
                animator.SetBool("Running", false);
                if (!IsAttacking)
                {
                    
                    int i = Random.Range(0, 20);
                        transform.LookAt(target);

                    //int i = 11;
                    if (i < 10)
                    {
                        animator.SetTrigger("Attack");
                        nAnimator.SetTrigger("Attack");
                        IsAttacking = true;
                    }
                    else
                    {
                        //idle
                    }
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
    

    void GetClosestPlayer()
    {
        
        if (closestDistance == 0f)
        {
            Debug.Log("Was 0");
        }
        if (Players[0] != null)
        {
            closestDistance = Vector3.Distance(Players[0].transform.position, transform.position);
            closestDistance = TurnPositive(closestDistance);
            ClosestPlayer = Players[0];
        }
        for (int i = 1; i < Players.Count; i++)
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
