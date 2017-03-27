using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject projectile;
	public float projectileSpeed = 10f;
	public float health = 300f;
	public float shotsPerSeconds = 5f;

	void Update() {
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability) {
			Debug.Log (probability);
			Fire ();
		}
	}

	void Fire() {
		Vector3 startPosition = transform.position + new Vector3 (0, -1f, 0);
		GameObject missile = Instantiate (projectile, startPosition, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, projectileSpeed);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Destroy(gameObject);
			}
		}
	}


}
