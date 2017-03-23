//using UnityEngine;
//using System.Collections;
//using UnityEngine.Networking;
//using UnityEngine.UI;
//
//public class net_PlayerUI : NetworkBehaviour {
//
//	//GUI
//	private Image PlayerHP;
//	private Text PlayerHPText;
//	private Image PlayerMana;
//	private Image TargetHP;
//	private Text TargetNameText;
//	private Text TargetHPText;
//	private Image TargetHPBackground;
//	private Image TargetMana;
//
//	private net_CharacterClass playerClass;
//
//	public override void OnStartLocalPlayer () {
//		//get GUI Components
//		PlayerHP = GameObject.Find("PlayerHP").GetComponent<Image> ();
//		PlayerHPText = GameObject.Find("PlayerHPText").GetComponent<Text> ();
//		PlayerMana = GameObject.Find ("PlayerMana").GetComponent<Image> ();
//		TargetHP = GameObject.Find("TargetHP").GetComponent<Image> ();
//		TargetHPBackground = GameObject.Find("TargetHPBackground").GetComponent<Image> ();
//		TargetNameText = GameObject.Find("TargetNameText").GetComponent<Text> ();
//		TargetHPText = GameObject.Find ("TargetHPText").GetComponent<Text> ();
//		TargetMana = GameObject.Find ("TargetMana").GetComponent<Image> ();
//
//		//get Target from InputManager
//		inputManager = GetComponent<net_PlayerInputManager> ();
//		//get characterspecific stuff from characterClass
//		playerClass = GetComponent<net_CharacterClass> ();
//	}
//
//	// Update is called once per frame
//	void Update () 
//	{
//		ShowTarget();
//	}
//
//	
//	void ShowTarget () {
//		if (isLocalPlayer) {
//			//Show TargetHPBar
//			if (inputManager.getTargetName () != "null") {
//				TargetHP.gameObject.SetActive (true);
//				TargetHPBackground.gameObject.SetActive(true);
//				if (inputManager.getTarget ().tag == "Minion") {
//					//if Minion get the MinionController to get the Life
//					TargetNameText.text = inputManager.getTargetName ();
//					TargetHP.color = new Color32(255,0,0,255);
//					TargetHP.fillAmount = inputManager.getTarget ().GetComponent<net_MinionController> ().Health / 100f;
//					TargetHPText.text = " " + inputManager.getTarget ().GetComponent<net_MinionController> ().Health + "/100";
//					TargetMana.fillAmount = 0f;
//				} else {
//					//always get the right character script from net_CharacterClass due to inheritance
//					//if its no minion it is a Player
//					if(inputManager.getTarget().GetComponent<net_CharacterClass>().CharacterClassName == "Warrior"){
//						//set TargetColor
//						TargetHP.color = new Color32(215,145,0,210);
//						//set RageColor
//						TargetMana.color = new Color32(255,0,0,255);
//					} else if(inputManager.getTarget().GetComponent<net_CharacterClass>().CharacterClassName == "Mage"){
//					
//						//TODO - Declare all class HP and Mana Color here!
//
//					} //and so on!!
//					TargetNameText.text = inputManager.getTarget().name;
//					TargetHP.fillAmount = inputManager.getTarget().GetComponent<net_CharacterClass>().Health / 100f;
//					TargetHPText.text = " " + inputManager.getTarget().GetComponent<net_CharacterClass>().Health + "/100";
//					TargetMana.fillAmount = inputManager.getTarget().GetComponent<net_CharacterClass>().Rage / 100f;
//				}
//
//			} else {
//				//if the TargetName is "null"
//				TargetHP.gameObject.SetActive (false);
//				TargetHPBackground.gameObject.SetActive(false);
//			}
//			//Show PlayerHPBar and get the color
//			if(GetComponent<net_CharacterClass>().CharacterClassName == "Warrior"){
//				PlayerHP.color = new Color32(215,145,0,210);
//				PlayerMana.color = new Color32(255,0,0,255);
//			} else if(GetComponent<net_CharacterClass>().CharacterClassName == "Mage"){
//			
//				// TODO - Declare all Player HP and Mana Colors
//
//			} //and so on!!
//
//			PlayerHP.fillAmount = playerClass.Health / 100f;
//			PlayerHPText.text = " " + playerClass.Health + "/100";
//			PlayerMana.fillAmount = playerClass.Rage / 100f;
//		}
//	}
//}
