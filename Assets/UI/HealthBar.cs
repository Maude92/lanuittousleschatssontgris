using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Transform character;
    public Transform HBImage;
    public Transform HBText;
    public float maxHealth;
    public float currentHealth;
    public float health;

	// Use this for initialization
	void Start () {
        HBImage = gameObject.transform.GetChild(0).GetChild(0);
        HBText = gameObject.GetComponentInChildren<Text>().transform;
        HBImage.GetComponent<Image>().fillAmount = 1;
        currentHealth = maxHealth;
	}
	
    public void Damage(float damageAmount)
    {
        health = (currentHealth - damageAmount) / maxHealth;
        currentHealth -= damageAmount;
        currentHealth = Mathf.Round(currentHealth);
        HBImage.GetComponent<Image>().fillAmount = health;
        HBText.GetComponent<Text>().text = currentHealth.ToString();
        if (health <= 0)
        {
            HBText.GetComponent<Text>().text = "0";
            GameObject.DestroyObject(character.gameObject);
        }
    }

}
