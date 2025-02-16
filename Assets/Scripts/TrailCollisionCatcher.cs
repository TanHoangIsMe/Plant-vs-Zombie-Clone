using UnityEngine;

public class TrailCollisionCatcher : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        EnemyController controller = other.GetComponent<EnemyController>();
        if (controller != null) controller.TakeDamage();

        gameObject.SetActive(false);
    }
}
