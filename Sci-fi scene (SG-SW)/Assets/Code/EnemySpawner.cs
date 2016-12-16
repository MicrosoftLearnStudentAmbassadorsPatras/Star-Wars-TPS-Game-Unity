using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy = new GameObject();
    public Vector3 rndPositon = new Vector3();
    //public int n;

    public static int enemyCount = 0;
    public const int enemyLimit = 10;

    // Use this for initialization
    void Start()
    {
        Invoke("Spawn", Random.Range(0.5f, 2f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        float rand1 = Random.Range(-10f, 30f);
        float rand2 = Random.Range(-10f, 30f);

        rndPositon.Set(this.transform.position.x + rand1, this.transform.position.y, this.transform.position.z + rand2);

        Instantiate(enemy, rndPositon, Quaternion.Euler(Random.Range(0, 10), 0, Random.Range(0, 10)));
        enemyCount++;
        if (enemyCount < enemyLimit)
        {
            Invoke("Spawn", Random.Range(0.04f, 0.05f));
            print("spawning another " + (enemyLimit - enemyCount) + " enemies");
        }
    }
}
