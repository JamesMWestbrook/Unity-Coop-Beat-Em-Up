using UnityEngine;
using System.Collections.Generic;
using Mirror;

public class Actor : NetworkBehaviour
{
    public bool IsPlayer = false;

    public Transform camera;
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
        
        HP.HP = HP.MaxHP;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
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
        if (!isLocalPlayer)
        {
            return;
        }
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
                Vector3 pos = transform.position;

                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");

                Quaternion rotation = Quaternion.Euler(0, camera.eulerAngles.y, 0);

                Vector3 target = new Vector3(x, 0, y);
                if (target.sqrMagnitude > 1)
                {
                    target.Normalize();
                }

                pos += rotation * target * MoveSpeed * Time.deltaTime;

                transform.position = pos;
                transform.rotation = Quaternion.LookRotation(target);
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
