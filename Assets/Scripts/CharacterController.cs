using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharactersData characterData;

    // character attack range
    private float distance;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        distance = characterData.AttRange * 1.6f + 0.8f;
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
}
