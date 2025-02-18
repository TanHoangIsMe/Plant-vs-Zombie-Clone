using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    private List<CharacterController> targetsList;
    private Animator animator;
    private int currentHp;
    private bool canMove;

    private void Awake()
    {
        targetsList = new List<CharacterController>();
        animator = GetComponent<Animator>();
        currentHp = enemyData.Hp;
        canMove = true;
    }

    private void Update()
    {
        EnemyMoving(canMove);
    }

    private void EnemyMoving(bool canMove)
    {
        if (!canMove) return;

        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(transform.position.x - 15.2f, transform.position.y, 0);
        transform.position = Vector3.MoveTowards(startPos, endPos, enemyData.Spd * Time.deltaTime);
    }

    public void ContinueMoving()
    {
        canMove = !canMove;
        animator.SetBool("Can Attack", false);
    }

    public void TakeDamage()
    {
        if(currentHp == 0) Destroy(gameObject);
    }

    private void Attack()
    {
        if (targetsList.Count > 0)
            targetsList[targetsList.Count - 1].TakeDamage();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            targetsList.Add(collision.gameObject.GetComponent<CharacterController>());

            animator.SetBool("Can Attack", true);
            canMove = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            targetsList.RemoveAt(targetsList.Count - 1);

            if(targetsList.Count == 0)
            {
                animator.SetBool("Can Attack", false);
                canMove = true;               
            }
        }
    }
}
