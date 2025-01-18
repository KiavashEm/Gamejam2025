using UnityEngine;
using UnityEngine.AI;

public class NavMeshClickToMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject targetDestination;
    public string opposingNpcTag; // Tag assigned to the opposing NPCs

    void Update()
    {
        
            Vector3 target = targetDestination.transform.position;
            agent.SetDestination(target);
     
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        //Debug.Log(collision.collider.name);

        if (collision.collider.tag == opposingNpcTag)
        {
            agent.isStopped = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == opposingNpcTag)
        {
            //agent.isStopped = false;
        }
    }
}
