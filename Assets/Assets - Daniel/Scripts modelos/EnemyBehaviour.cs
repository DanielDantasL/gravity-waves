using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public int HP;
    public int resistance;

    public void TookDamage(int damage)
    {
        Debug.Log("aeeee");
        HP -= damage;

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
            
    }


}
