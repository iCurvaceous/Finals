using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	public int health;
	public float speed;
	
	private Animator anim;
	
	private float timeBtwAttack;
	public float startTimeBtwAttack;
	
	public Transform attackPos;
	public LayerMask whatIsEnemies;
	public float attackRange;
	public int damage;

	/*// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timeBtwAttack <= 0){
			//then you can attack
			if(Input.GetKey(KeyCode.Space)){
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisEnemies);
				for(int i = 0; i < enemiesToDamage.Length; i++) {
				enemiesToDamage[i].GetComponent<Enemy>().health -= damage;
				}
			}
			
			timeBtwAttack = startTimeBtwAttack;
		} else {
			timeBtwAttack -= Time.deltaTime;
		}
	}
	
	public void TakeDamage(int damage){
		
	}
	*/
}
