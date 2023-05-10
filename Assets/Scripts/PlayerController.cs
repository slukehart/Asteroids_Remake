using UnityEngine;
using Asteroids;

public class PlayerController : MonoBehaviour
{
    private const float deltaMove = 0.02f;
    private const float deltaRotation = 1.0f;
    
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletContainer;
    [SerializeField]
    private GameObject explosionPrefab;

    private void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    private void HandleMovement()
    {
        // Movement Controls - WASD or Arrow keys
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * deltaMove);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, deltaRotation);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -deltaRotation);
        }
    }

    private void HandleShooting()
    {
        // Shoot bullet (prefabs) with space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity, bulletContainer);
            obj.GetComponent<BulletController>().SetDirection(transform.up);
        }
    }

    public void DestroyPlayer()
    {
        // Explosion, destroy game object, and show GameOver screen
        Debug.Log("Player hit an asteroid!");
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameManager.Instance?.TriggerGameOver();
        Destroy(gameObject);
    }
}
