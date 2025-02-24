using UnityEngine;

public class TrailCollisionCatcher : MonoBehaviour
{
    private int att;
    public int Att { set { att = value; } }

    private void OnParticleCollision(GameObject other)
    {
        EnemyController controller = other.GetComponent<EnemyController>();
        if (controller != null) controller.TakeDamage(att);

        gameObject.SetActive(false);
    }
}
