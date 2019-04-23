using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private GameController gc;
    private bool hardCheck;

    void Start()
    {
        hardCheck = false;

        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    public void Update()
    {
        if(hardCheck == false && gc.hardModeActivate == true)
        {
            rb.velocity = transform.forward * (speed - 6);
            hardCheck = true;
        }
    } 

}