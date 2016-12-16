using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLights : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject lights1_1;
    public GameObject lights1_2;
    public GameObject lights2_1;
    public GameObject lights2_2;
    public GameObject lights3_1;
    public GameObject lights3_2;

    int index = 0;

    float elapsed = 0.0f;

    public static float period = 0.5f;

	// Update is called once per frame
	void Update () {
        elapsed += Time.deltaTime;

        if (elapsed >= period)
        {
            elapsed = 0.0f;
            increaseLightIndex();
        }
	}

    void increaseLightIndex()
    {
        index++;
        index %= 3;

        switch (index)
        {
            case 0:
                {
                    lights1_1.SetActive(true);
                    lights1_2.SetActive(true);
                    lights2_1.SetActive(false);
                    lights2_2.SetActive(false);
                    lights3_1.SetActive(false);
                    lights3_2.SetActive(false);
                    break;
                }
            case 1:
                {
                    lights1_1.SetActive(false);
                    lights1_2.SetActive(false);
                    lights2_1.SetActive(true);
                    lights2_2.SetActive(true);
                    lights3_1.SetActive(false);
                    lights3_2.SetActive(false);
                    break;
                }
            case 2:
                {
                    lights1_1.SetActive(false);
                    lights1_2.SetActive(false);
                    lights2_1.SetActive(false);
                    lights2_2.SetActive(false);
                    lights3_1.SetActive(true);
                    lights3_2.SetActive(true);
                    break;
                }
        }
    }

}
