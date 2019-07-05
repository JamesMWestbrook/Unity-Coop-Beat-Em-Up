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


    
    [SyncVar] public int HP = 50;
    [SyncVar] public int MaxHP = 50;

    public GameObject[] enemies;

    // Use this for initialization
    void Start()
    {
        
        IsAttacking = false;
        HP = MaxHP;

        enemies = GameObject.FindGameObjectsWithTag("enemy");
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<enemyInView>().cam = camera.GetComponent<Camera>();
        }
        
        GameObject canvasCam = GameObject.Find("Image");
        canvasCam.GetComponent<targetController>().cam = camera.GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer && !BetaTesting || !IsPlayer)
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
        if (!isLocalPlayer && !BetaTesting || !IsPlayer)
        {
            return;
        }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (!IsAttacking)
            {
                Vector3 pos = rb.position;

                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");

                Quaternion rotation = Quaternion.Euler(0, camera.eulerAngles.y, 0);

                Vector3 target = new Vector3(x, 0, y);
                if (target.sqrMagnitude > 1)
                {
                    target.Normalize();
                }
                target = rotation * target;
                pos +=  target * MoveSpeed * Time.deltaTime;

                rb.MoveRotation(Quaternion.LookRotation(target));
                rb.MovePosition(pos);
            }

        }

    }

    public void OnHit(Actor attacker)
    {

        GetComponent<Animator>().SetTrigger("Damage");
        GetComponent<NetworkAnimator>().SetTrigger("Damage");
        HP -= 10;
        Debug.Log(HP);
        gameObject.SetActive(false);
        //HP.HPBar.fillAmount = HP.HP / HP.MaxHP;
    }


    private bool IsState(string stateName = "Idle")
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    [Server]
    public void Target(Actor target)
    {

    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        
        List<GameObject> _enemies = new List<GameObject>();
       _enemies.AddRange( GameObject.FindGameObjectsWithTag("enemy"));
        for(int i = 0; i < _enemies.Count; i++) {
            //_enemies[i].GetComponent<MageAI>().PlayerIDs.Add(netId);
        }
        
        
    }

}
