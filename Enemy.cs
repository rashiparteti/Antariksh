using UnityEngine;

public class Alien : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject enemyShipPrefab;
    [SerializeField] private Detonator explosionPrefab;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void TakeDamage(int damage, Vector3 hitPosition)
    {
        Alienship(hitPosition);
        ExplodeAndDestroy(hitPosition);
        Destroy(gameObject);
        // Destroy the alien ship
    }

    


    private void Alienship(Vector3 hitPosition)
    {
        if (enemyShipPrefab != null)
        {
            Instantiate(enemyShipPrefab, _transform.position, _transform.rotation);
        }
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, hitPosition, Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ExplodeAndDestroy(collision.contacts[0].point);
        }
    }

   
    private void ExplodeAndDestroy(Vector3 position)
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, position, Quaternion.identity);
        }
        Destroy(gameObject); // Destroy the alien ship
    }
}
