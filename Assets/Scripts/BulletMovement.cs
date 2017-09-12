using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	float speed = 8f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Preleviamo la posizione del proiettile
		Vector2 pos = transform.position;

		//Modifica della posizione sull'asse y
		pos.y += speed * Time.deltaTime;

		//Bordo superiore della finestra di gioco
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

		//Applichiamo la modifica
		transform.position = pos;

		if (transform.position.y >= max.y) { //Abbiamo sorpassato il bordo
			Destroy(gameObject);
		}
	}
}
