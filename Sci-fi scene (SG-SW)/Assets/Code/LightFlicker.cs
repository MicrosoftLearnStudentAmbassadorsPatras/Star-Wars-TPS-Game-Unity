using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        resetFlickers();
        resetToggleTimer();

        //emitter.enableEmission = false;
	}

    Random rand = new Random();

    int flickers = 0;
    int maxFlickers = 0;

    float nextToggle = 0.0f;

    float elapsedTime = 0.0f;

    bool isFlickering = true;


	// Update is called once per frame
	void Update () {
        elapsedTime += (float)Time.deltaTime;
        checkFlicker();
	}

    public Light lamp;

    public ParticleSystem emitter;

    void checkFlicker()
    {
        if (elapsedTime > nextToggle)
        {
            flickers++;
            if (flickers > maxFlickers)
            {
                isFlickering = !isFlickering; //toggle the value


                //emitter.enableEmission = !emitter.enableEmission;

                //emitter.Emit(30);
                //emitter.loop = !isFlickering;
                if (isFlickering) emitter.Play();
                //emitter.emissionRate = 10000000.0f;
                
                resetFlickers();
            }
            else
            {
                toggleLight();
            }
            resetToggleTimer();
            elapsedTime = 0;
        }
    }

    void resetToggleTimer()
    {
        this.nextToggle = getRandomFloat() / 1000;
        if (isFlickering == true)
        {
            nextToggle /= 10.0f;
        }
    }

    void toggleLight()
    {
        lamp.intensity = 1.09f - lamp.intensity;
    }

    void resetFlickers()
    {
        if(isFlickering)
            maxFlickers = Random.Range(2,6);
        else
            maxFlickers = Random.Range(2, 4);
        flickers = 0;
    }

    float getRandomFloat()
    {
        return (float)Random.Range(500, 1200);
    }

}
