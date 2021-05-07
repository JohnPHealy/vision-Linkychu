using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	public Vector3 t_target;
	public GameObject CollisionExplosion;
	public float speed;

	void Update () 
	{
		float step = speed + Time.deltaTime;
		
		if (t_target != null)
        {
			if (transform.position == t_target)
			{
				explode();
				return;
			}

			transform.position = Vector3.MoveTowards(transform.position, t_target, step);
        }
	
	}

	public void setTarget(Vector3 target)
    {
		t_target = target;
    }

	void explode()
    {
		if (CollisionExplosion != null)
        {
			GameObject explosion = (GameObject)Instantiate(CollisionExplosion, transform.position, transform.rotation);
			Destroy(gameObject);
			Destroy(explosion, 1f);
        }
    }
}
