using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
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
        if(distance <= DistanceToFind || finded)
        {
            finded = true;
            agent.SetDestination(Player.transform.position);
        }
    }

    void OnPlayerSpawned()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDestroy()
    {
        EventManager.PlayerSpawned -= OnPlayerSpawned;
    }
}
