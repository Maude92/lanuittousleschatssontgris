using UnityEngine;
using System.Collections;


public class FallDamage : MonoBehaviour {
    public Transform healthbar;
    public float startYPos;
    public float endYPos;
    public float damageThreshold = 10;
    public bool damageMe = false;
    public bool firstCall = true;
	public GameObject Mist;

	CubeGrounded cubegrounded;

	void Start () {
		cubegrounded = GetComponent <CubeGrounded> ();
	}


	// Update is called once per frame
	void Update () {
		if (cubegrounded.isGrounded == false)
        {
            if (Mist.transform.position.y > startYPos)
            {
                firstCall = true;
            }
            if (firstCall)
            {
                startYPos = gameObject.transform.position.y;
                firstCall = false;
                damageMe = true;
            }
        }
		if (cubegrounded.isGrounded == true)
        {
            endYPos = Mist.transform.position.y;
            if (startYPos - endYPos > damageThreshold)
            {
                if (damageMe)
                {
                    //healthbar.GetComponent<HealthBar>().Damage(startYPos - endYPos - damageThreshold);
					healthbar.GetComponent<HealthBar>().Damage(startYPos - endYPos);
                    damageMe = false;
                    firstCall = true;
                }                
            }
        }
	}
}
