using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharactersData characterData;

    // character attack range
    private float distance;
    private Animator animator;
    private ParticleSystem particleSystem;

    private void Awake()
    {
        distance = characterData.AttRange * 1.6f + 0.8f;
        animator = GetComponent<Animator>();
        Transform child = transform.GetChild(0);
        if (child != null)
            particleSystem = child.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        CheckEnemyInZone();
    }

    private void CheckEnemyInZone()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance,LayerMask.GetMask("Zombie"));

        if (hit.collider == null)
            animator.SetBool("Can Attack", false);
        else
            animator.SetBool("Can Attack", true);      
    }

    private void Attack()
    {
        if(particleSystem != null)
            particleSystem.Play();
    }
}
