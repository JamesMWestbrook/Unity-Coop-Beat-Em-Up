using UnityEngine;
using System.Collections.Generic;
using Mirror;

public class Actor : NetworkBehaviour
{
    public bool IsPlayer = false;
    public bool BetaTesting = false;

    public Transform camera;

    public bool IsAttacking = false;
    [SerializeField] private Animator animator;
    [SerializeField] private NetworkAnimator networkAnimator;
    [SerializeField] private List<AnimationClip> attacks;


    
    public float MoveSpeed = 5f;
    [SerializeField] private Rigidbody rb;
    public Hp HP;

    // Use this for initialization
    void Start()
    {
        if (HP == null)
        {
            HP = transform.Find("hp").GetComponent<Hp>();
        }
        
        HP.HP = HP.MaxHP;
        //camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer && !BetaTesting)
        {
            return;
        }

        if (Input.GetButtonDown("Submit"))
        {
            animator.SetTrigger("Attack");
            networkAnimator.SetTrigger("Attack");
            IsAttacking = true;
        }


        

    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer && !BetaTesting)
        {
            return;
        }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
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

        //HP.HPBar.fillAmount = HP.HP / HP.MaxHP;
    }


    private bool IsState(string stateName = "Idle")
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

}
