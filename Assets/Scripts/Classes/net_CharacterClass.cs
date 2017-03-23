//using UnityEngine;
//using System.Collections;
//using UnityEngine.Networking;
//
//// Need to set all methods that have to be overritten (ALL) by the special player class to "virtual". Set the
//// correspondending methods in the inherited class to override!!!
//
//// see http://wowwiki.wikia.com/wiki/Attributes
//
//public abstract class net_CharacterClass : NetworkBehaviour {
//
//	//Basic Character Class. Defining Stats and Spells here
//	//Fields have to be synced across the network
//
//	//Handle the specific spells here
//
//	/*a lot of variables!! */
//	string characterClassName = "net_characterClass";
//
//	//Game Stats
//	[SyncVar (hook = "OnCurLvLChanged")] private int curlevel = 1;
//	[SyncVar] private int maxlevel = 20;
//
//	//Basic Stats
//	[SyncVar (hook = "OnHealthChanged")] private int health;
//	[SyncVar (hook = "OnManaChanged")] private int mana;
//	[SyncVar (hook = "OnRageChanged")] private int rage;
//	[SyncVar (hook = "OnEnergyChanged")] private int energy;
//
//	private string secondResource;
//
//	//Basic Attributes
//	[SyncVar (hook = "OnStaminaChanged")] private int stamina;
//	int strength;
//	int intellect;
//	int agility;
//	int spirit;
//
//	//Advanced Attributes
//	//General / Melee
//	int damage;
//
//	//Spell only
//	int spellpower;
//	int spellhaste;
//	int penetration;	//dmg modifier -> reducing armor
//	int manaregen;		//mana regen in noncombatstate modifier 
//	int combatregen;	//mana regen in combatstate modifier
//	
//	[SyncVar (hook = "OnAttackPowerChanged")] private int attackpower;	//dmg modifier
//	int speed;			//attackspeed with melee weapon -> hardcoded in weapon
//	int haste;			//attackspeed modifier
//	int hitchance;		//dmg modifier
//	int critchance;		//dmg modifier
//	int expertise;		//dmg modifier
//	int mastery;		//dmg modifier
//
//	//Defense
//	int armor;			//dmgTaken modifier
//	int dodge;			//dmgTaken modifier
//	int parry;			//dmgTaken modifier
//	int block;			//dmgTaken modifier
//
//	//Resistances
//
//	//Reducing Damage Taken by specific SpellClass
//	//arcane
//	//nature
//	//fire
//	//frost
//	//shadow
//
//
//	[Client]
//	public virtual void Spell1(GameObject target){
//		if (target != null) {
//			CmdCastSpell (target, 0);
//			Debug.Log ("Spell1 DEFAULT");
//		}
//	}
//
//	[Client]
//	public virtual void Spell2(){
//	}
//
//	[Client]
//	public virtual void Spell3(){
//	}
//
//	//--LEVEL STUFF
//
//	public int CurLevel{
//		get{ return this.curlevel;}
//		set{ this.curlevel = value;}
//	}
//
//	public virtual void LevelUp(){
//		this.curlevel += 1;
//	}
//
//	//--SETTER AND GETTER
//	public virtual string CharacterClassName{
//		get{ return characterClassName;}
//		set{ characterClassName = value;}
//	}
//
//	//Basic Stats
//	public int Health{
//		get{ return health;}
//		set{ this.health = value;}
//	}
//
//	public int Mana{
//		get{ return mana;}
//		set{ this.mana = value;}
//	}
//
//	public int Rage{
//		get{ return rage;}
//		set{ this.rage = value;}
//	}
//
//	public int Energy{
//		get{ return energy;}
//		set{ this.energy = value;}
//	}
//
//	public string SecondResource{
//		get{ return this.secondResource;}
//		set{ this.secondResource = value;}
//	}
//
//	public int Damage{
//		get{ return damage;}
//		set{ this.damage = value;}
//	}
//	
//	//Basic Attributes
//	public int Strength{
//		get{ return strength;}
//		set{ this.strength = value;}
//	}
//	
//	public int Intellect{
//		get{ return intellect;}
//		set{ this.intellect = value;}
//	}
//	
//	public int Agility{
//		get{ return agility;}
//		set{ this.agility = value;}
//	}
//	
//	public int Spirit{
//		get{ return spirit;}
//		set{ this.spirit = value;}
//	}
//
//	public int AttackPower {
//		get{ return this.attackpower;}
//		set{ this.attackpower = value;}
//	}
//
//	public int Stamina{
//		get{ return this.stamina;}
//		set{ this.stamina = value;}
//	}
//
//	//--NETWORK ATTRIBUTE SYNCING
//	//Syncing stats only on change! -> lots of code, lots of performance
//
//	void OnCurLvLChanged(int curlvl) {
//		this.curlevel = curlvl;
//	}
//	
//	void OnHealthChanged(int hlth) {
//		this.health = hlth;
//	}
//
//	void OnManaChanged(int mna) {
//		this.mana = mna;
//	}
//
//	void OnRageChanged(int rge) {
//		this.rage = rge;
//	}
//
//	void OnEnergyChanged(int enrgy) {
//		this.energy = enrgy;
//	}
//
//	void OnAttackPowerChanged(int attkpwr) {
//		this.attackpower = attkpwr;
//	}
//
//	void OnStaminaChanged(int stam) {
//		this.stamina = stam;
//	}
//
//	//--NETWORK SYNCING
//	//Call this after everytime u did direct damage
//	[Command]
//	public void CmdCastSpell(GameObject target, GameObject spell) {
//		if (target.transform.tag == "Player") {
//			string uIdentity = target.transform.name;
//			GameObject go = GameObject.Find(uIdentity);
////			go.GetComponent<net_PlayerController>().DoDamage(amount);
//		}
//		//Apply Damage to Minion
//		if (target.transform.tag == "Minion") {
//			string uIdentity = target.transform.name;
//			GameObject go = GameObject.Find(uIdentity);
//			go.GetComponent<net_MinionController>().DoDamage(amount);
//		}
//	}
//}
