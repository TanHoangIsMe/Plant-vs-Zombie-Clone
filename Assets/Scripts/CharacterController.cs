using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharactersData characterData;

    // character attack range
    private float distance;
    private Animator animator;
    private GameObject trail;
    private int currentHp;

    private void Awake()
    {
        distance = characterData.AttRange * 1.6f + 0.8f;
        animator = GetComponent<Animator>();
        trail = transform.GetChild(0).gameObject;
        currentHp = characterData.Hp;
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

    public void TakeDamage()
    {        
        currentHp -= 1;
        Debug.Log(gameObject.name + "-" + currentHp);
        if (currentHp == 0) Destroy(gameObject);
    }
}
