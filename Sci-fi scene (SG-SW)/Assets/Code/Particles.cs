using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {

    public float timeOfDeath;

    // Use this for initialization
    void Start()
    {
        Invoke("Die", timeOfDeath);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
