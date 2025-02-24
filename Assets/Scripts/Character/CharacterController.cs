using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharactersData characterData;

    private Animator animator;
    private GameObject trail;
    private TrailCollisionCatcher trailCollisionCatcher;
    private Vector3 startPos;
    private float distance; // character attack range
    private int currentHp;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        startPos = transform.position - new Vector3(0,0.8f,0);
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
        RaycastHit2D hit = Physics2D.Raycast(startPos, transform.right, distance,LayerMask.GetMask("Zombie"));
        animator.SetBool("Can Attack", hit.collider != null);
    }

    private void Attack()
    {
        if(trail != null) trail.SetActive(true);
    }

    public void TakeDamage(int att)
    {
        // set second layer index above base layer
        animator.SetLayerWeight(1, 1f);
        animator.SetTrigger("Hit");

        currentHp -= att;
        if (currentHp <= 0) Destroy(gameObject); 
    }
}
