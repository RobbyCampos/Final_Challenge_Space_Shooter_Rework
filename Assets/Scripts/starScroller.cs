using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starScroller : MonoBehaviour {


    private float hSliderValue = 1.0F;
    private ParticleSystem ps;
    private GameController gCobj;

    void Start () {

        gCobj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        ps = GetComponent<ParticleSystem>();
    }

	void Update ()
    {

        var main = ps.main;
        main.simulationSpeed = hSliderValue;

        if (gCobj.winCondition == true)
        {
            if (hSliderValue <= 25)
            {
                hSliderValue += Time.deltaTime;
            }
        }

	}
}
