using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public float enemyLife;
    public NavMeshAgent agent;
    public Animation anim;
    public Transform[] target;
    private int currentTarget;
    public Transform Player;
    private BoxCollider hitbox;

    void Start()
    {
        anim=GetComponent<Animation>();
        agent=GetComponent<NavMeshAgent>();
        //Player = GameObject.FindGameObjectsWithTag("Player").transform;
        hitbox = agent.GetComponent<BoxCollider>();
    }


    void Update()
    {
        if (enemyLife > 0)
        {
            hitbox.enabled = anim.IsPlaying("Anim_Attack");
            agent.SetDestination(target[0].position);
        }
        
    }
}
