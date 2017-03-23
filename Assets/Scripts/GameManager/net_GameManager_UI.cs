using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class net_GameManager_UI : MonoBehaviour {

	public Button optionsButton;
	public Button quitButton;
	public GameObject optionsMenu;
	public Button OkButton;
	public Button CancelButton;


	// Use this for initialization
	void Start () {

		SetupMenuSceneButtons ();
	}

	void QuitApp(){
		Application.Quit ();
	}

	void ShowOptionsMenu(){
			optionsMenu.SetActive (true);
	}

	void HideOptionsMenu(){
		optionsMenu.SetActive (false);
	}

	void SetupMenuSceneButtons() {	
		optionsMenu.SetActive (false);
		this.quitButton.onClick.RemoveAllListeners ();
		this.quitButton.onClick.AddListener (QuitApp);

		this.optionsButton.onClick.RemoveAllListeners ();
		this.optionsButton.onClick.AddListener (ShowOptionsMenu);

		this.OkButton.onClick.RemoveAllListeners ();
		this.OkButton.onClick.AddListener (HideOptionsMenu);

		this.CancelButton.onClick.RemoveAllListeners ();
		this.CancelButton.onClick.AddListener (HideOptionsMenu);
	}
}
