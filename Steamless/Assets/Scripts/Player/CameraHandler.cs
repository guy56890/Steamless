using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float cameraSpeed = 2;
    public float radius = 3;

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

            Vector2 direction = (playerObject.transform.position - transform.position);
            float distance = direction.magnitude;

            if (distance > radius)
            {
                Vector3 target = new Vector3(playerObject.transform.position.x,
                                            playerObject.transform.position.y,
                                            -10f);

                // smooth interpolation, never stalls
                transform.position = Vector3.Lerp(transform.position, target, cameraSpeed * Time.deltaTime);
            }


        }
    }
}
