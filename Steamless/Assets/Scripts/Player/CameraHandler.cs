using System.Collections;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float cameraSpeed = 2;
    public float radius = 3;
    public float yOffset = 1f;

    CircleCollider2D trigger;
    GameObject playerObject;

    void Start()
    {
        trigger = GetComponent<CircleCollider2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (playerObject != null)
        {

            Vector3 desiredPos = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);

            Vector2 direction = (playerObject.transform.position - desiredPos);
            float distance = direction.magnitude;

            if (distance > radius)
            {
                Vector3 target = new Vector3(playerObject.transform.position.x,
                                            playerObject.transform.position.y + yOffset,
                                            -10f);

                // smooth interpolation, never stalls
                transform.position = Vector3.Lerp(transform.position, target, cameraSpeed * Time.deltaTime);
            }


        }
    }

    IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while ( elapsed < duration )
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
