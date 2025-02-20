using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharactersData characterData;

    // character attack range
    private float distance;
    private Animator animator;
    private GameObject trail;
    private TrailCollisionCatcher trailCollisionCatcher;
    private int currentHp;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        distance = characterData.AttRange * 1.6f + 0.8f;
        currentHp = characterData.Hp;
        
        trail = transform.GetChild(0).gameObject;
        trailCollisionCatcher = trail.GetComponent<TrailCollisionCatcher>();
        if(trailCollisionCatcher != null )
        trailCollisionCatcher.Att = characterData.Att;
    }

    private void Update()
    {
        CheckEnemyInZone();
    }

    private void CheckEnemyInZone()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance,LayerMask.GetMask("Zombie"));
        animator.SetBool("Can Attack", hit.collider != null);
    }

    private void Attack()
    {
        if(trail != null) trail.SetActive(true);
    }

    public void TakeDamage(int att)
    {        
        currentHp -= att;
        if (currentHp <= 0) Destroy(gameObject);
    }
}
