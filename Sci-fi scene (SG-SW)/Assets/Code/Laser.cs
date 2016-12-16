using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{

    public float speed, timeOfDeath;
    Rigidbody rb;
    public GameObject particlesystem = new GameObject();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

        Instantiate(particlesystem, gameObject.transform.position, Quaternion.identity/*Quaternion.Euler(transform.rotation.eulerAngles.x + 90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z)*/);

        Destroy(gameObject);
    }
}
