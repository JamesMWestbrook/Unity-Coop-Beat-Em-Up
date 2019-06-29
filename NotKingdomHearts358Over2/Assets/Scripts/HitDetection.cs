using UnityEngine;

public class HitDetection : MonoBehaviour
{
#pragma warning disable 0649 //never assinged to and will always have default value null

    [SerializeField] private BoxCollider WeaponCollider;

    public void Hit()
    {
        Collider[] colliders = Physics.OverlapBox(WeaponCollider.bounds.center, WeaponCollider.bounds.extents, WeaponCollider.transform.rotation, LayerMask.GetMask("Hitbox"));

        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].transform.root == transform.root)
            {
                continue;
            }
            Debug.Log(colliders[i].name);
            if (colliders[i].transform.root.GetComponent<Actor>())
            {
                colliders[i].transform.root.GetComponent<Actor>().OnHit(transform.root.GetComponent<Actor>());

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
