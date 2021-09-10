using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : Enemy
{

    [SerializeField] private Transform attackHitPos;
    public enum State { IDLE,CHASE}
    public State state;

    private Animator anim;
    private NavMeshAgent agent;
    private SkinnedMeshRenderer mesh;

    private float timeBTAttack = 1.5f;
    private float timeElapsed;

    private float distance;

    protected override void Awake()
    {
        base.Awake();
        
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        
    }

    protected override void Update()
    {
        base.Update();
        anim.SetFloat("Speed", agent.velocity.magnitude);
        
    }

    protected override void Movement()
    {
        distance = Vector3.Distance(character.transform.position, transform.position);
        switch (state)
        {
            case State.CHASE:
                
                agent.SetDestination(character.transform.position);
                
                if(agent.remainingDistance < 3.5f)
                {
                    transform.LookAt(character.transform);
                    timeElapsed += Time.deltaTime;

                    agent.isStopped = true;

                    if(timeElapsed >= timeBTAttack)
                    {
                        timeElapsed = 0;
                        anim.Play("Attack");
                    }

                }

                else
                {
                    agent.isStopped = false;
                }

                break;

            case State.IDLE:

                if(distance < 20f)
                {
                    SoundManager.instance.PlaySound("Zombie_Sound", this.transform.position);
                    OnStateChange(State.CHASE);
                }

                break;

        }
    }


    private void OnStateChange(State nextState)
    {
        state = nextState;
    }

    public override void Death()
    {
        base.Death();
        SoundManager.instance.PlaySound("Zombie_Death",this.transform.position);
        EnemyPooling.Instance.AddToPool(gameObject);
        
    }

    public void Attack()
    {
        Collider[] col = Physics.OverlapSphere(attackHitPos.position, 2f,LayerMask.GetMask("Player"));

        foreach(Collider target in col)
        {
            target.GetComponent<CharacterHealth>().TakeDamage(10);
            
        }
    }

    public void PlaySound()
    {
        SoundManager.instance.PlaySound("Zombie_Sound", this.transform.position);
    }

}
