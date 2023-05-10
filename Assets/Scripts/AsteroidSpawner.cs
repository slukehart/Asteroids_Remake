using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        private const int NUM_ASTEROIDS = 4;
        private const float MAX_SPEED = 0.01f;

        [SerializeField]
        private List<GameObject> asteroidPrefabs;

        private void Start()
        {
            if (asteroidPrefabs.Count == 0) return;

            Vector3 maxPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            Vector3 minPos = Camera.main.ViewportToWorldPoint(Vector3.zero);

            for (int i = 0; i < NUM_ASTEROIDS; i++)
            {
                SpawnRandomAsteroid(minPos, maxPos);
            }
        }

        private void SpawnRandomAsteroid(Vector3 minPos, Vector3 maxPos)
        {
            // Spawn random prefab
            int randomIndex = Random.Range(0, asteroidPrefabs.Count);
            GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex], transform);

            // Set random position
            Vector3 randomPos = new Vector3(
                Random.Range(minPos.x, maxPos.x),
                Random.Range(minPos.y, maxPos.y)
            );
            asteroid.transform.position = randomPos;

            // Set random velocity vector
            float randomSpeed = Random.Range(0, MAX_SPEED);
            float randomAngle = Random.Range(0, 2 * Mathf.PI);
            Vector3 direction = new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
            asteroid.GetComponent<AsteroidController>()?.Setup(randomSpeed * direction);
        }
    }
}
