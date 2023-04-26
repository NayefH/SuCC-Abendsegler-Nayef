using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbod;
    public float speed = 500.0f;
    public float maxLifeTime = 10.0f;

    private void Awake()
    {
        rigidbod = GetComponent<Rigidbody2D>();

    }



    public void Project(Vector2 direction)
    {
        rigidbod.AddForce(direction * speed);
        Destroy(this.gameObject, this.maxLifeTime);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnColllision2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
