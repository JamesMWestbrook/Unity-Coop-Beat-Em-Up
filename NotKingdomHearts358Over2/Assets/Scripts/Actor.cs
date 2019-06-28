using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mirror;

public class Actor : NetworkBehaviour
{
    public bool IsPlayer = false;

    public bool IsAttacking = false;
    private Animator animator;
    [SerializeField] private List<AnimationClip> attacks;


    
    public float MoveSpeed = 5f;
    private Rigidbody rb;
    public Hp HP;

    // Use this for initialization
    void Start()
    {
        if (HP == null)
        {
            HP = transform.Find("hp").GetComponent<Hp>();
        }
        else
        {
            
        }
        HP.HP = HP.MaxHP;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer && !IsPlayer)
        {
            return;
        }

        if (Input.GetButtonDown("Submit"))
        {
            animator.SetTrigger("Attack");
            IsAttacking = true;
        }

        


    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            /*
            float HorInput = Input.GetAxisRaw("Horizontal");
            float VertInput = Input.GetAxisRaw("Vertical");
            Vector3 movement = new Vector3(HorInput, 0.0f, VertInput);
            if(movement != Vector3.zero) transform.rotation = Quaternion.LookRotation(movement);

            transform.position += (Vector3.forward * Time.deltaTime * MoveSpeed) * Input.GetAxis("Vertical");
            transform.position += (Vector3.right * Time.deltaTime * MoveSpeed) * Input.GetAxis("Horizontal");
            */

            if (!IsAttacking)
            {
                //reading the input:
                float horizontalAxis = Input.GetAxisRaw("Horizontal");
                float verticalAxis = Input.GetAxisRaw("Vertical");

                //assuming we only using the single camera:
                var camera = Camera.main;

                //camera forward and right vectors:
                var forward = camera.transform.forward;
                var right = camera.transform.right;

                //project forward and right vectors on the horizontal plane (y = 0)
                forward.y = 0f;
                right.y = 0f;
                forward.Normalize();
                right.Normalize();

                //this is the direction in the world space we want to move:
                var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;

                //now we can apply the movement:
                transform.Translate(desiredMoveDirection * MoveSpeed * Time.deltaTime);

                //apply transformation
                Vector3 movement = new Vector3(horizontalAxis, 0.0f, verticalAxis);
                if (movement != Vector3.zero) transform.rotation = Quaternion.LookRotation(movement);
            }
            
        }
    }

    public void OnHit(Actor attacker)
    {
        GetComponent<Animator>().SetTrigger("Damage");
        HP.HP -= 10;

        HP.HPBar.fillAmount = HP.HP / HP.MaxHP;
    }


    private bool IsState(string stateName = "Idle")
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
