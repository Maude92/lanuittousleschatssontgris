using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {
    public Transform character;
    public Transform HBImage;
    public Transform HBText;
    public float maxHealth;
    public float currentHealth;
    public float health;

	public int NbVieRestant;

	[SerializeField]
	private Color fullColor;

	[SerializeField]
	private Color lowColor;

	public Image Vie1;
	public Image Vie2;
	public Image Vie3;
	public Image Vie4;
	public Image Vie5;
	public Image Vie6;
	public Image Vie7;
	public Image Vie8;
	public Image Vie9;

	// Use this for initialization
	void Start () {
        HBImage = gameObject.transform.GetChild(0).GetChild(0);
        HBText = gameObject.GetComponentInChildren<Text>().transform;
        HBImage.GetComponent<Image>().fillAmount = 1;
		HBImage.GetComponent<Image> ().color = fullColor;
        currentHealth = maxHealth;

		NbVieRestant = 9;
	}
	
    public void Damage(float damageAmount)
    {
        health = (currentHealth - damageAmount) / maxHealth;
        currentHealth -= damageAmount;
        currentHealth = Mathf.Round(currentHealth);
        HBImage.GetComponent<Image>().fillAmount = health;
		HBImage.GetComponent<Image> ().color = Color.Lerp (lowColor, fullColor, HBImage.GetComponent<Image>().fillAmount);
        HBText.GetComponent<Text>().text = currentHealth.ToString();
        if (health <= 0)
        {
            HBText.GetComponent<Text>().text = "0";
			NbVieRestant--;
			if (NbVieRestant > 0) {
				currentHealth = 100;
				health = 100;
				HBImage.GetComponent<Image>().fillAmount = health;
				HBImage.GetComponent<Image> ().color = Color.Lerp (lowColor, fullColor, HBImage.GetComponent<Image>().fillAmount);
				HBText.GetComponent<Text>().text = currentHealth.ToString();
			}

            //GameObject.DestroyObject(character.gameObject);
			//SceneManager.LoadScene ("SceneTest");
        }
    }

	void Update () {
//S'il reste 9 Vie :
		if (NbVieRestant == 9) {
			Vie1.enabled = true;
			Vie2.enabled = true;
			Vie3.enabled = true;
			Vie4.enabled = true;
			Vie5.enabled = true;
			Vie6.enabled = true;
			Vie7.enabled = true;
			Vie8.enabled = true;
			Vie9.enabled = true;
		}
	
//S'il reste 8 Vie :
		if (NbVieRestant == 8) {
			Vie1.enabled = true;
			Vie2.enabled = true;
			Vie3.enabled = true;
			Vie4.enabled = true;
			Vie5.enabled = true;
			Vie6.enabled = true;
			Vie7.enabled = true;
			Vie8.enabled = true;
			Vie9.enabled = false;
		}

//S'il reste 7 Vie :
		if (NbVieRestant == 7) {
			Vie1.enabled = true;
			Vie2.enabled = true;
			Vie3.enabled = true;
			Vie4.enabled = true;
			Vie5.enabled = true;
			Vie6.enabled = true;
			Vie7.enabled = true;
			Vie8.enabled = false;
			Vie9.enabled = false;
		}

//S'il reste 6 Vie :
		if (NbVieRestant == 6) {
			Vie1.enabled = true;
			Vie2.enabled = true;
			Vie3.enabled = true;
			Vie4.enabled = true;
			Vie5.enabled = true;
			Vie6.enabled = true;
			Vie7.enabled = false;
			Vie8.enabled = false;
			Vie9.enabled = false;
		}

//S'il reste 5 Vie :
		if (NbVieRestant == 5) {
			Vie1.enabled = true;
			Vie2.enabled = true;
			Vie3.enabled = true;
			Vie4.enabled = true;
			Vie5.enabled = true;
			Vie6.enabled = false;
			Vie7.enabled = false;
			Vie8.enabled = false;
			Vie9.enabled = false;
		}

//S'il reste 4 Vie :
		if (NbVieRestant == 4) {
			Vie1.enabled = true;
			Vie2.enabled = true;
			Vie3.enabled = true;
			Vie4.enabled = true;
			Vie5.enabled = false;
			Vie6.enabled = false;
			Vie7.enabled = false;
			Vie8.enabled = false;
			Vie9.enabled = false;
		}

//S'il reste 3 Vie :
		if (NbVieRestant == 3) {
			Vie1.enabled = true;
			Vie2.enabled = true;
			Vie3.enabled = true;
			Vie4.enabled = false;
			Vie5.enabled = false;
			Vie6.enabled = false;
			Vie7.enabled = false;
			Vie8.enabled = false;
			Vie9.enabled = false;
		}

//S'il reste 2 Vie :
		if (NbVieRestant == 2) {
			Vie1.enabled = true;
			Vie2.enabled = true;
			Vie3.enabled = false;
			Vie4.enabled = false;
			Vie5.enabled = false;
			Vie6.enabled = false;
			Vie7.enabled = false;
			Vie8.enabled = false;
			Vie9.enabled = false;
		}

//S'il reste 1 Vie :
		if (NbVieRestant == 1) {
			Vie1.enabled = true;
			Vie2.enabled = false;
			Vie3.enabled = false;
			Vie4.enabled = false;
			Vie5.enabled = false;
			Vie6.enabled = false;
			Vie7.enabled = false;
			Vie8.enabled = false;
			Vie9.enabled = false;
		}

//S'il reste 0 Vie :
		if (NbVieRestant == 0) {
			Vie1.enabled = false;
			Vie2.enabled = false;
			Vie3.enabled = false;
			Vie4.enabled = false;
			Vie5.enabled = false;
			Vie6.enabled = false;
			Vie7.enabled = false;
			Vie8.enabled = false;
			Vie9.enabled = false;
			//Écran Game Over à faire
		}


	}

}
