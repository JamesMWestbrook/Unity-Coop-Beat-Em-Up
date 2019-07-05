using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    [SerializeField] private MageAI mageAI;
    private Actor actor;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered");
        actor = other.GetComponent<Actor>();
        if (!mageAI.Players.Contains(other.gameObject))
        {
            mageAI.Players.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("player exited");
        mageAI.Players.Remove(other.gameObject);
    }
    
}
