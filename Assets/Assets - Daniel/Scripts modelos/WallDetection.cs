using UnityEngine;
using System.Collections;

public class WallDetection : MonoBehaviour {

    public MegamanController megamanController;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            megamanController.onWall = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            megamanController.onWall = false;
        }
    }
}
