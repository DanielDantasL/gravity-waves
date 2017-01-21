using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {

    Rigidbody2D rgbd2D;
    public float force_y;


	void Awake () {
        rgbd2D = GetComponent<Rigidbody2D>();
    }
	
	void Update () {

        UpdateRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rgbd2D.AddRelativeForce(new Vector2(0, force_y));
            //rgbd2D.velocity = (new Vector2(0, 8));

        }
    }

    void UpdateRotation()
    {
        float rotationZ = 2*Mathf.PI*Mathf.Atan(rgbd2D.velocity.x/ rgbd2D.velocity.y);
        transform.rotation = new Quaternion(0, 0, -rotationZ, 1);
    }
}
