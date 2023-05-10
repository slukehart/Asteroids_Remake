using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    private Vector3 velocity;

    public void Setup(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    public void DestroyAsteroid()
    {
        Debug.Log("An asteroid was blown up!");
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position += velocity;
    }
}
