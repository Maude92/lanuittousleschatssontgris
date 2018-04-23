using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private AudioManager audioManager;

	public GameObject mainUI;
	public GameObject creditsUI;
	public GameObject infosUI;

	public GameObject learnMoreUI;
	public GameObject controlesUI;

	public GameObject nextFleche;
	public GameObject backFleche;
	public GameObject info1;
	public GameObject info2;
	public GameObject info3;
	public GameObject info4;

	public int panneauInfo;

	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention, le AudioManager n'a pas été trouvé dans la scène.");}

		panneauInfo = 1;
	}

	void Update (){
		if (panneauInfo < 1) {
			panneauInfo = 1;
		}

		if (panneauInfo > 4) {
			panneauInfo = 4;
		}


		if (panneauInfo == 1) {
			nextFleche.SetActive (true);
			backFleche.SetActive (false);
			info1.SetActive (true);
			info2.SetActive (false);
			info3.SetActive (false);
			info4.SetActive (false);
		}

		if (panneauInfo == 2) {
			nextFleche.SetActive (true);
			backFleche.SetActive (true);
			info1.SetActive (false);
			info2.SetActive (true);
			info3.SetActive (false);
			info4.SetActive (false);
		}

		if (panneauInfo == 3) {
			nextFleche.SetActive (true);
			backFleche.SetActive (true);
			info1.SetActive (false);
			info2.SetActive (false);
			info3.SetActive (true);
			info4.SetActive (false);
		}

		if (panneauInfo == 4) {
			nextFleche.SetActive (false);
			backFleche.SetActive (true);
			info1.SetActive (false);
			info2.SetActive (false);
			info3.SetActive (false);
			info4.SetActive (true);
		}

	}

	// POUR QUITTER
	public void Quit() {
		print ("Bye bye!");
		Application.Quit ();
	}

	// POUR COMMENCER UNE PARTIE
	public void PlayTheGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	// POUR VOIR LES CRÉDITS
	public void Credits(){
		mainUI.SetActive (false);
		creditsUI.SetActive (true);
	}

	// POUR SORTIR DES CRÉDITS
	public void MainMenuFromCredits(){
		creditsUI.SetActive (false);
		mainUI.SetActive (true);
	}

	// POUR PLUS D'INFOS
	public void MoreInfos(){
		mainUI.SetActive (false);
		infosUI.SetActive (true);
	}

	// POUR SORTIR DES INFOS
	public void MainMenuFromInfos(){
		infosUI.SetActive (false);
		mainUI.SetActive (true);
	}

	// POUR FAIRE DU BRUIT
	public void playClip(){
		audioManager.PlaySound ("Clic");
	}

	// POUR PLUS D'INFOS
	public void LearnMore(){
		controlesUI.SetActive (false);
		learnMoreUI.SetActive (true);
		panneauInfo = 1;
	}

	// POUR VOIR LES PANNEAUX D'INFOS
	public void NextInfos(){
		panneauInfo++;
	}

	public void BackInfos(){
		panneauInfo--;
	}

	// POUR LES CONTRÔLES
	public void LesControles(){
		learnMoreUI.SetActive (false);
		controlesUI.SetActive (true);
	}
		
}
