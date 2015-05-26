using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour 
{
	public float attackRange;
	public float attackDamage;

	Animator animator;
	NavMeshAgent agent;
	public GameObject target;


	enum State
	{
		Idle,
		Chase,
		Dead,
		Attack,
		Damage
	};

	State state;
	
	void Start()
	{
		animator = GetComponentInChildren<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update()
	{
		switch(state)
		{
		case State.Attack:
			UpdateAttack();
			break;
		case State.Chase:
			UpdateChase();
			break;
		case State.Damage:
			UpdateDamage();
			break;
		case State.Dead:
			UpdateDead();
			break;
		case State.Idle:
			UpdateIdle();
			break;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			target = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			target = null;
		}
	}

	void UpdateAttack()
	{
		AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (0);
		if(info.IsName ("Main.Idle"))
		{
			state = State.Idle;
			animator.SetBool("TargetSpottedBool", false);
		}
	}

	void UpdateChase()
	{
		if(target == null)
		{
			state = State.Idle;
			animator.SetBool("TargetSpottedBool", false);
			agent.Stop ();
		}
		else
		{
			float distance = Vector3.Distance (transform.position, target.transform.position);
			if(distance <= attackRange)
			{
				state = State.Attack;
				animator.SetTrigger ("AttackTrigger");
				agent.Stop ();
			}
			else
			{
				agent.SetDestination (target.transform.position);
			}
		}
	}

	void UpdateDamage()
	{
		Health health = GetComponent<Health> ();
		AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (0);
		if(health.isAlive == false)
		{
			animator.SetBool("AliveBool", false);
			if(info.IsName ("Main.Dead"))
			{
				state = State.Dead;
			}
		}
		else
		{
			if(info.IsName ("Main.Idle"))
			{
				state = State.Idle;
				animator.SetBool("TargetSpottedBool", false);
			}
		}
	}

	void UpdateDead()
	{
		AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (0);
		if(info.normalizedTime >1)
		{
			ScoreTracker.Instance.AddScore(100);
			DestroyObject(gameObject);
		}
	}

	void UpdateIdle()
	{
		if(target != null)
		{
			state = State.Chase;
			animator.SetBool("TargetSpottedBool", true);
		}
	}

	public void OnAttackEvent()
	{
		if(target != null)
		{
			float distance = Vector3.Distance (transform.position, target.transform.position);
			if(distance <= attackRange)
			{
				target.SendMessage ("TakeDamage", attackDamage);
				DamageHUD.Instance.OnPlayerHit();
			}
		}
	}

	public void DamageRecieved()
	{
		if(state != State.Dead)
		{
			state = State.Damage;
			animator.SetTrigger ("HurtTrigger");
			agent.Stop ();
		}
	}
}
