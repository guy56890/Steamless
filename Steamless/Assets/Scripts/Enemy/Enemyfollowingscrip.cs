using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfollowingscrip : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public SpriteRenderer spriteRenderer;

    float oldX = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (oldX < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        oldX = transform.position.x;

    }
}
