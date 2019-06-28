using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
#pragma warning disable 0649 //never assinged to and will always have default value null
    private void Start()
    {
    }

    private void Update()
    {
        
        
    }

    [SerializeField] private BoxCollider WeaponCollider;

    public void Hit()
    {
        Collider[] colliders = Physics.OverlapBox(WeaponCollider.bounds.center, WeaponCollider.bounds.extents, WeaponCollider.transform.rotation, LayerMask.GetMask("Hitbox"));
        foreach (Collider c in colliders)
        {
            if(c.transform.root == transform.root)
            {
                continue;
            }
            if (c.transform.root.GetComponent<Actor>())
            {
                c.transform.root.GetComponent<Actor>().OnHit(transform.root.GetComponent<Actor>());

            }
        }
    }

    public void AttackLine()
    {
        if (transform.root.GetComponent<VoiceLines>())
        {
            transform.root.GetComponent<VoiceLines>().Attack();
        }
    }
    public void Quote()
    {
        transform.root.GetComponent<VoiceLines>().Quote();
    }
    


}
