using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundImpact : MonoBehaviour
{
    // Start is called before the first frame update

    public Collider2D groundCollider;
    CameraHandler camHandler;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("ground collision");
    }

}
