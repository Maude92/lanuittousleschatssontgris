using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {

	private AudioManager audioManager;

	PauseMenu pausemenu;
	public GameObject player;

	//public GameObject controlesUI;

	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention, le AudioManager n'a pas été trouvé dans la scène.");}

		pausemenu = player.GetComponent<PauseMenu> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Quit() {
		print ("Bye bye!");
		Application.Quit ();
	}

	public void MainMenuFromTuto() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
	}

	public void MainMenuFromLevel1(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 2);
	}

	public void playClip(){
		audioManager.PlaySound ("Clic");
	}

	public void Return(){
		pausemenu.modePause = !pausemenu.modePause;
	}

	public void Controles(){
		print ("Les contrôles affichent!");
	}
}
