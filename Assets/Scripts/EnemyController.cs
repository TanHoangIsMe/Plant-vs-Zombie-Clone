using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

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
}
