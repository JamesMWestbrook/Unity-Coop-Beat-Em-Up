using UnityEngine;

public class StateMachineEdits : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.gameObject.GetComponent<Actor>().IsAttacking = false;
    }
}
