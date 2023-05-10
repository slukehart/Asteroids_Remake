using UnityEngine;

namespace Asteroids
{
    public class BulletController : MonoBehaviour
    {
        private const float speed = 0.05f;
        private Vector3 velocity;

        public void SetDirection(Vector3 direction)
        {
            velocity = direction.normalized * speed;
        }

        void Update()
        {
            transform.position = transform.position + velocity;
        }
    }
}
