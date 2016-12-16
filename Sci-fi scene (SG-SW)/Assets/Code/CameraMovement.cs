using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float yAngleMin = -50.0f;
    public float yAngleMax = 50.0f;

    public Transform player;
    public Transform lookAt;
    public Transform camTrasform;
    public Transform weapon;

    private Camera cam;

    public float distance = 3.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;

        camTrasform = transform;
        cam = Camera.main;
    }

	// Update is called once per frame
	void Update ()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit();
		}
    }

    void LateUpdate()
    {
        //Vector3 dir = new Vector3(0, 0, -distance);
        //Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        //camTrasform.position = lookAt.position + rotation * dir;
        //camTrasform.LookAt(lookAt.position);

        //player.transform.rotation = new Quaternion(lookAt.transform.rotation.x, this.transform.rotation.y, lookAt.transform.rotation.z, this.transform.rotation.w);
        player.transform.rotation = Quaternion.Euler(new Vector3(/*lookAt.transform.rotation.eulerAngles.x*/0, transform.rotation.eulerAngles.y, /*lookAt.transform.rotation.eulerAngles.z*/0));

        //old code that rotated the weapon
        weapon.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));


        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTrasform.position = lookAt.position + rotation * dir;
        camTrasform.LookAt(lookAt.position);
    }
}
