using UnityEngine;
using System.Collections;

public class HealthIA : MonoBehaviour {
    public int health = 10;
    public GameObject loot;

    public void applyDamage(int dmg)
    {
        health -= dmg;
        if (health < 1)
        {
            // spawn loot
            if (loot)
                Instantiate(loot, transform.position, transform.rotation);

            // DEATH
            EnemyManager.instance.removeEnemy(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
