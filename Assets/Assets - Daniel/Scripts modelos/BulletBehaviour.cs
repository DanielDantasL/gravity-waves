using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    private MegamanController megamanController;

    private float speed = 3.8f;
    private float direction;
    public int damage;
    public int resistance;


    void Awake()
    {
        megamanController = GameObject.FindGameObjectWithTag("Player").GetComponent<MegamanController>();
        direction = megamanController.direction;

        if (direction == -1)
            GetComponent<SpriteRenderer>().flipX = true;
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(speed * Time.deltaTime * direction,0,0));

	}

    void OnBecameInvisible()
    {
        megamanController.bulletCount++;
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Enemy")
        {
            EnemyBehaviour enemy = c.GetComponent<EnemyBehaviour>();

            enemy.TookDamage(damage);

            if (enemy.resistance >= resistance)
            {
                Destroy(this.gameObject);
                megamanController.bulletCount++;
            }
        }
    }
}
