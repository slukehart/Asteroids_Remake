using UnityEngine;

namespace Asteroids
{
    public class DestroyOffscreen : MonoBehaviour
    {
        private Vector3 maxPos;
        private Vector3 minPos;
        private float bufferSpace = 1;

        private void Start()
        {
            maxPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            minPos = Camera.main.ViewportToWorldPoint(Vector3.zero);
        }

        private void Update()
        {
            // Check if offscreen (with some added buffer)
            if (transform.position.x < minPos.x - bufferSpace ||
                transform.position.x > maxPos.x + bufferSpace ||
                transform.position.y < minPos.y - bufferSpace ||
                transform.position.y > maxPos.y + bufferSpace)
            {
                Destroy(gameObject);
            }
        }
    }
}
