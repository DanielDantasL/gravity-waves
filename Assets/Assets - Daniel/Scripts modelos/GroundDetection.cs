using UnityEngine;
using System.Collections;

public class GroundDetection : MonoBehaviour {

    public MegamanController megamanController;
    
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Solid")
        {
            megamanController.onGround = true;
            megamanController.anim.SetBool("onGround", true);

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Solid")
        {
            megamanController.onGround = false;
            megamanController.anim.SetBool("onGround", false);

        }
    }
}
