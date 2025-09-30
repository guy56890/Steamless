using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float grappleLength;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private float grappleRange;
    [SerializeField] private LineRenderer rope;


    private Vector3 grapplePoint;
    private SpringJoint2D Joint;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Joint = gameObject.GetComponent<SpringJoint2D>();
        rb = gameObject.gameObject.GetComponent<Rigidbody2D>();

        Joint.enabled = false;
        rope.enabled = false;    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = clickPosition - transform.position;

            RaycastHit2D hit = Physics2D.Raycast(
            origin: transform.position,
            direction: direction.normalized,
            distance: grappleRange,
            layerMask: grappleLayer
            );

            print(hit.collider);

            if (hit.collider != null)
            {

                grapplePoint = hit.point;
                grapplePoint.z = 0;
                Joint.connectedAnchor = grapplePoint;
                Joint.enabled = true;
                Joint.distance = grappleLength;

                rope.SetPosition(0, grapplePoint);
                rope.SetPosition(1, transform.position);
                rope.enabled = true;

            }


        }

        if (Input.GetMouseButtonUp(1))
        {
            Joint.enabled = false;
            rope.enabled = false;
        }

        if(rope.enabled)
        {
            rope.SetPosition(1, transform.position);
        }

    }
}
