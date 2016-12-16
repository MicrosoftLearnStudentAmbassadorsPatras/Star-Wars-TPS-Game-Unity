using UnityEngine;
using System.Collections;

public class LaserSpawner : MonoBehaviour {

    public GameObject lazerShot;
    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Quaternion laserRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            Vector3 laserRotation = new Vector3(transform.rotation.eulerAngles.x + 90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            Instantiate(lazerShot, transform.position, Quaternion.Euler(laserRotation));
            audio.Play();
        }

    }
}
