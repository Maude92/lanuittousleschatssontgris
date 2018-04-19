using UnityEngine;
using System.Collections;

public class Fracture : MonoBehaviour {
	public Transform parts;
    private Transform breakable = null;

    private void OnCollisionEnter(Collision collision)
    {

        Vector3 velocity = transform.GetComponent<Rigidbody>().velocity;
        
        if (velocity.magnitude < 2.0f) return;
        if (breakable) return;
        
        breakable = (Transform)Instantiate(parts, transform.position, transform.rotation); 
        breakable.localScale = transform.localScale;

        foreach (Transform part in breakable)
        {
            part.gameObject.GetComponent<Renderer>().materials[1].CopyPropertiesFromMaterial(gameObject.GetComponent<Renderer>().material);
            if (!part.gameObject.GetComponent<Rigidbody>())
            {
                part.gameObject.AddComponent<Rigidbody>();
                part.gameObject.GetComponent<Rigidbody>().velocity = velocity;
            }
            if (!part.gameObject.GetComponent<MeshCollider>())
            {
                part.gameObject.AddComponent<MeshCollider>();
                part.gameObject.GetComponent<MeshCollider>().convex = true;
            }

            float time = Random.Range(5f, 30f);
            Destroy(part.gameObject, time);
        }

        Destroy(breakable.gameObject, 30f);
        Destroy(gameObject);
    }
}
