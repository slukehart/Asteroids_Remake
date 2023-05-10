using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ExplosionController : MonoBehaviour
    {
        private ParticleSystem particles;

        private void Awake()
        {
            particles = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            // Cleanup particle system
            if (!particles.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
