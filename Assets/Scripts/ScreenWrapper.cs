using UnityEngine;

namespace Asteroids
{
    public class ScreenWrapper : MonoBehaviour
    {
        private Vector3 maxPos;
        private Vector3 minPos;

        private void Start()
        {
            // (1,1) top right of screen, (0,0) bottom left
            maxPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            minPos = Camera.main.ViewportToWorldPoint(Vector3.zero);
        }

        private void Update()
        {
            // Wrap x-axis
            if (transform.position.x < minPos.x)
            {
                transform.position = new Vector3(maxPos.x, transform.position.y, 0f);
            }
            else if (transform.position.x > maxPos.x)
            {
                transform.position = new Vector3(minPos.x, transform.position.y, 0f);
            }

            // Wrap y-axis
            if (transform.position.y < minPos.y)
            {
                transform.position = new Vector3(transform.position.x, maxPos.y, 0f);
            }
            else if (transform.position.y > maxPos.y)
            {
                transform.position = new Vector3(transform.position.x, minPos.y, 0f);
            }
        }
    }
}
