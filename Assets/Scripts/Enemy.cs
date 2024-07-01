using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour,IDamageble
{
    PlayerLevel playerLevel;
    public float HealthPoints = 100f;
    public float ExpForKill = 50f;
    Animator _animator;
    public float PlayerRadius = 0.75f;
    GameObject Player;
    bool finded = false;
    float distance = 0f;
    public float DistanceToFind = 10f;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake()
    {
      agent =  GetComponent<NavMeshAgent>();
        EventManager.PlayerSpawned += OnPlayerSpawned;
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        OnPlayerSpawned();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Player != null)
        {
            distance = Vector3.Distance(transform.position, Player.transform.position);
            FindDestination();
        }
    }

    public void FindDestination()
    {
        if((distance <= DistanceToFind || finded) && distance >= PlayerRadius)
        {
            finded = true;
            agent.SetDestination(Player.transform.position);
            _animator.SetBool("PlayerFinded", true);
            _animator.SetBool("Attack", false);
        }
        if (distance <= PlayerRadius)
        {
            agent.SetDestination(transform.position);
            _animator.SetBool("Attack", true);
        }
     }

    void OnPlayerSpawned()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = Player.GetComponent<PlayerLevel>();
    }

    private void OnDestroy()
    {
        EventManager.PlayerSpawned -= OnPlayerSpawned;
    }

    public void DamageTaken(float damage)
    {
        if (HealthPoints - damage > 0) HealthPoints -= damage;
        else Die();
    }

    public void Die()
    {
        if (playerLevel != null) playerLevel.ExpirienceGet(ExpForKill);
        Destroy(gameObject);
    }
}
