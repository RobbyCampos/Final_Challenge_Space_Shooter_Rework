using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroller : MonoBehaviour {

    public float scrollSpeed;
    public float tilesizeZ;

    private Vector3 startPosition;
    private GameController gCobj;

    public void Start()
    {
        gCobj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        startPosition = transform.position;
    }

    private void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tilesizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        //if (gCobj.hardModeActivate == true)
        //{
        //    if (scrollSpeed >= -1)
        //    {
        //        scrollSpeed = scrollSpeed + -.01f;
        //    }
        //}

        if (gCobj.winCondition == true)
        {
            if (scrollSpeed >= -100)
            {
                scrollSpeed = scrollSpeed + -.01f;
            }
        }
    }
}
