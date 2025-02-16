using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private int currentHp;

    private void Awake()
    {
        currentHp = enemyData.Hp;
    }

    private void Update()
    {
        EnemyMoving();
    }

    private void EnemyMoving()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(transform.position.x - 15.2f, transform.position.y, 0);
        transform.position = Vector3.MoveTowards(startPos, endPos, enemyData.Spd * Time.deltaTime);
    }

    public void TakeDamage()
    {
        currentHp -= 1;
        if(currentHp == 0) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
