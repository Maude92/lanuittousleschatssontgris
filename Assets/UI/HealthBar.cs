using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class HealthBar : MonoBehaviour {
   
	private AudioManager audioManager;
	public AudioSource LowVieSound;

	public Transform character;
    public Transform HBImage;
    //public Transform HBText;
    public float maxHealth;
    public float currentHealth;
    public float health;
	public float healtGain;

	public int NbVieRestant;

	[SerializeField]
	private Color fullColor;

	[SerializeField]
	private Color lowColor;

//	public Image Vie1;
//	public Image Vie2;
//	public Image Vie3;
//	public Image Vie4;
//	public Image Vie5;
//	public Image Vie6;
//	public Image Vie7;
//	public Image Vie8;
//	public Image Vie9;

	public Image Circle;
	public CanvasGroup UIvie;
	public CanvasGroup RedDamage;

	public GameObject SoinCroix;

	Animator anim;
	public GameObject mistObj;

	//Pour Vibration
	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	//Pour écran perte de vie
	public GameObject EcranDePerteDeVie;
	public CanvasGroup LostALifeScreen;
	AnimatedText AnimatedTextCode;

	// Pour le fade to black qui chie
	public GameObject fadeToBlack;


	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention le AudioManager n'est pas détecter dans cette scène");
		}

		HBImage = gameObject.transform.GetChild(0).GetChild(0);
       //Texte
		//HBText = gameObject.GetComponentInChildren<Text>().transform;
        HBImage.GetComponent<Image>().fillAmount = 1;
		HBImage.GetComponent<Image> ().color = fullColor;
        currentHealth = maxHealth;

		anim = mistObj.GetComponent <Animator> ();

		LostALifeScreen.alpha = 0;
		AnimatedTextCode = EcranDePerteDeVie.GetComponent <AnimatedText> ();

	//Circle
		//Circle.color = HBImage.GetComponent<Image> ().color;
		Circle.fillAmount = 1;

		//NbVieRestant = 9;
		NbVieRestant = Staticlife.numberoflives;
		CheckingLife ();
		UIvie.alpha = 0;
		RedDamage.alpha = 0;

		SoinCroix.SetActive (false);

		//LowVieSound.enabled = false;

	


	}
	
    public void Damage(float damageAmount)
    {

//		//Vibration
		GamePad.SetVibration (playerIndex, 5, 5);
		GamePad.SetVibration (playerIndex, 0, 0);
		StartCoroutine (VibreLaManette());

		UIvie.alpha = 1;
		RedDamage.alpha = 1;

		anim.SetBool ("Miaw", true);
		audioManager.PlaySound ("Mist_Damage");
		health = (currentHealth - damageAmount) / maxHealth;
        currentHealth -= damageAmount;
        currentHealth = Mathf.Round(currentHealth);
        HBImage.GetComponent<Image>().fillAmount = health;
		HBImage.GetComponent<Image> ().color = Color.Lerp (lowColor, fullColor, HBImage.GetComponent<Image>().fillAmount);

		//Circle.color = HBImage.GetComponent<Image> ().color;

        
	//Texte
		//HBText.GetComponent<Text>().text = currentHealth.ToString();
        if (health <= 0.01)
        {
			fadeToBlack.SetActive (false);
           //Texte
			//HBText.GetComponent<Text>().text = "0";
			NbVieRestant--;
			CheckingLife ();
			StartCoroutine ("FadeInBlackScreen");
			AnimatedTextCode.StartLeShit ();
			if (NbVieRestant > 0) {
				//Fade to black
				//Load au dernier checkpoint
				currentHealth = maxHealth;			
				health = 100;					
			 	HBImage.GetComponent<Image>().fillAmount = health;
				HBImage.GetComponent<Image> ().color = Color.Lerp (lowColor, fullColor, HBImage.GetComponent<Image>().fillAmount);

				//Circle.color = HBImage.GetComponent<Image> ().color;

			//Texte
				//HBText.GetComponent<Text>().text = currentHealth.ToString();
			}

            //GameObject.DestroyObject(character.gameObject);
			//SceneManager.LoadScene ("SceneTest");
        }

		if (health > 0.01) {
			fadeToBlack.SetActive (true);
		}
			

//		if (currentHealth <= 25) {
//			LowVieSound.enabled = true;
//			LowVieSound.Play ();
//		}


    }

	public void LifeGain (float gainAmount){

		UIvie.alpha = 1;
		StartCoroutine("Soin");
		//audioManager.PlaySound ("Mist_Eating");
		currentHealth = (currentHealth + gainAmount);
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		healtGain = (currentHealth) / maxHealth;
		currentHealth = Mathf.Round(currentHealth);
		HBImage.GetComponent<Image>().fillAmount = healtGain;
		HBImage.GetComponent<Image> ().color = Color.Lerp (lowColor, fullColor, HBImage.GetComponent<Image>().fillAmount);

		//Circle.color = HBImage.GetComponent<Image> ().color;

	//Texte
		//HBText.GetComponent<Text>().text = currentHealth.ToString();

		if (currentHealth > 9) {
			LowVieSound.Stop ();
			LowVieSound.enabled = false;
		}
	}

	public void CheckingLife (){
		//Les Vies
		//S'il reste 9 Vie :
		if (NbVieRestant == 9) {
			//			Vie1.enabled = true;
			//			Vie2.enabled = true;
			//			Vie3.enabled = true;
			//			Vie4.enabled = true;
			//			Vie5.enabled = true;
			//			Vie6.enabled = true;
			//			Vie7.enabled = true;
			//			Vie8.enabled = true;
			//			Vie9.enabled = true;
		}

		//S'il reste 8 Vie :
		if (NbVieRestant == 8) {
			//			Vie1.enabled = true;
			//			Vie2.enabled = true;
			//			Vie3.enabled = true;
			//			Vie4.enabled = true;
			//			Vie5.enabled = true;
			//			Vie6.enabled = true;
			//			Vie7.enabled = true;
			//			Vie8.enabled = true;
			//			Vie9.enabled = false;

			Circle.fillAmount = 0.89f;
		}

		//S'il reste 7 Vie :
		if (NbVieRestant == 7) {
			//			Vie1.enabled = true;
			//			Vie2.enabled = true;
			//			Vie3.enabled = true;
			//			Vie4.enabled = true;
			//			Vie5.enabled = true;
			//			Vie6.enabled = true;
			//			Vie7.enabled = true;
			//			Vie8.enabled = false;
			//			Vie9.enabled = false;

			Circle.fillAmount = 0.78f;
		}

		//S'il reste 6 Vie :
		if (NbVieRestant == 6) {
			//			Vie1.enabled = true;
			//			Vie2.enabled = true;
			//			Vie3.enabled = true;
			//			Vie4.enabled = true;
			//			Vie5.enabled = true;
			//			Vie6.enabled = true;
			//			Vie7.enabled = false;
			//			Vie8.enabled = false;
			//			Vie9.enabled = false;

			Circle.fillAmount = 0.67f;
		}

		//S'il reste 5 Vie :
		if (NbVieRestant == 5) {
			//			Vie1.enabled = true;
			//			Vie2.enabled = true;
			//			Vie3.enabled = true;
			//			Vie4.enabled = true;
			//			Vie5.enabled = true;
			//			Vie6.enabled = false;
			//			Vie7.enabled = false;
			//			Vie8.enabled = false;
			//			Vie9.enabled = false;

			Circle.fillAmount = 0.56f;
		}

		//S'il reste 4 Vie :
		if (NbVieRestant == 4) {
			//			Vie1.enabled = true;
			//			Vie2.enabled = true;
			//			Vie3.enabled = true;
			//			Vie4.enabled = true;
			//			Vie5.enabled = false;
			//			Vie6.enabled = false;
			//			Vie7.enabled = false;
			//			Vie8.enabled = false;
			//			Vie9.enabled = false;

			Circle.fillAmount = 0.45f;
		}

		//S'il reste 3 Vie :
		if (NbVieRestant == 3) {
			//			Vie1.enabled = true;
			//			Vie2.enabled = true;
			//			Vie3.enabled = true;
			//			Vie4.enabled = false;
			//			Vie5.enabled = false;
			//			Vie6.enabled = false;
			//			Vie7.enabled = false;
			//			Vie8.enabled = false;
			//			Vie9.enabled = false;

			Circle.fillAmount = 0.34f;
		}

		//S'il reste 2 Vie :
		if (NbVieRestant == 2) {
			//			Vie1.enabled = true;
			//			Vie2.enabled = true;
			//			Vie3.enabled = false;
			//			Vie4.enabled = false;
			//			Vie5.enabled = false;
			//			Vie6.enabled = false;
			//			Vie7.enabled = false;
			//			Vie8.enabled = false;
			//			Vie9.enabled = false;
			//
			Circle.fillAmount = 0.23f;
		}

		//S'il reste 1 Vie :
		if (NbVieRestant == 1) {
			//			Vie1.enabled = true;
			//			Vie2.enabled = false;
			//			Vie3.enabled = false;
			//			Vie4.enabled = false;
			//			Vie5.enabled = false;
			//			Vie6.enabled = false;
			//			Vie7.enabled = false;
			//			Vie8.enabled = false;
			//			Vie9.enabled = false;

			Circle.fillAmount = 0.12f;
		}

		//S'il reste 0 Vie :
		if (NbVieRestant == 0) {
			//			Vie1.enabled = false;
			//			Vie2.enabled = false;
			//			Vie3.enabled = false;
			//			Vie4.enabled = false;
			//			Vie5.enabled = false;
			//			Vie6.enabled = false;
			//			Vie7.enabled = false;
			//			Vie8.enabled = false;
			//			Vie9.enabled = false;

			Circle.fillAmount = 0;

			//Écran Game Over à faire
		}

	}

	void Update () {

		StartCoroutine("FadeOut");
		StartCoroutine("FadeOutRed");



		if (currentHealth <= 9 && !LowVieSound.isPlaying) {
			LowVieSound.enabled = true;
			LowVieSound.Play ();
		}

		if (currentHealth > 9) {
			LowVieSound.Stop ();
			LowVieSound.enabled = false;
		}
			

	}

	IEnumerator FadeOut() {
		//yield return new WaitForSeconds (5f);

		float time = 1f;

//		while(UIvie.alpha > 0)
//		{
//			yield return new WaitForSeconds (5f);
//			UIvie.alpha -= Time.deltaTime / time;
//			yield return null;
//		}

		if (UIvie.alpha > 0) {
			yield return new WaitForSeconds (5f);
			UIvie.alpha -= Time.deltaTime / time;
			if (UIvie.alpha < 0) {
				UIvie.alpha = 0;
			}
		}
	}

	IEnumerator FadeOutRed() {
		//yield return new WaitForSeconds (5f);

		float time2 = 1f;

		if (RedDamage.alpha > 0) {
			GamePad.SetVibration (playerIndex, 1, 1);
			yield return new WaitForSeconds (0.05f);
			GamePad.SetVibration (playerIndex, 0, 0);
			RedDamage.alpha -= Time.deltaTime / time2;
			if (RedDamage.alpha < 0) {
				RedDamage.alpha = 0;
			}
		}
	}

	IEnumerator FadeInBlackScreen() {
		//yield return new WaitForSeconds (5f);

		float time = 0.4f;

		while (LostALifeScreen.alpha < 1) {
			yield return new WaitForSeconds (0.01f);
			LostALifeScreen.alpha += Time.deltaTime * time;
			if (LostALifeScreen.alpha > 1) {
				LostALifeScreen.alpha = 1;
			}
		}
	}

	IEnumerator Soin(){
		SoinCroix.SetActive (true);
		yield return new WaitForSeconds (2.1f);
		SoinCroix.SetActive(false);
	}


	IEnumerator VibreLaManette(){
		GamePad.SetVibration (playerIndex, 1, 1);
		yield return new WaitForSeconds (0.1f);
		GamePad.SetVibration (playerIndex, 0, 0);
	}

}
