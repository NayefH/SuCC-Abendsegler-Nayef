using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool move;
    private float turnDirection;
    private Rigidbody2D rigidBody;
    public float speed = 1.0f;
    public float turnSpeed = 1.0f;
    public Bullet bulletPrefab;




    //https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
    //Awake is called either when an active GameObject that contains the script is initialized
    // when a Scene loads, or when a previously inactive GameObject is set to active
    private void Awake()
    {
        //Sucht im selben Gameobject nach dem entsprechendem Komponent
        rigidBody = GetComponent<Rigidbody2D>();
        move = false;

    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        move = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1f;
        }
        else
        {
            turnDirection = 0f;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }


    //https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
    //MonoBehaviour.FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame.
    private void FixedUpdate()

    {
        //https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
        if (move){
            rigidBody.AddForce(this.transform.up * speed);
        }
        //https://docs.unity3d.com/ScriptReference/Rigidbody.AddTorque.html torque=drehmoment
        if (turnDirection != 0){
            rigidBody.AddTorque(turnDirection * turnSpeed);
        }
    }

    private void Shoot(){
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(transform.up);
    }



}
