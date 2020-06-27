using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Target{
        player,
        enemy
    }
public class MakeDamage : MonoBehaviour
{
    public Target target;
    public int damage = 20;
    private bool canDoDamage = true;
    public float damageCooldown = 1f;
    
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Player" && target == Target.player){
            Player player = other.gameObject.GetComponent<Player>();
            if(canDoDamage){
                player.TakeDamage(damage);
                canDoDamage = false;
                StartCoroutine(Cooldown(damageCooldown));
            }
        }
        if(other.gameObject.tag == "Enemy" && target == Target.enemy){
            Player player = other.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
            if(this.gameObject.tag == "Bullet"){
                this.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player" && target == Target.player){
            Player player = other.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
            if(this.gameObject.tag == "Bullet"){
                this.gameObject.SetActive(false);
            }
        }
        if(other.gameObject.tag == "Enemy" && target == Target.enemy){
            Player player = other.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
            if(this.gameObject.tag == "Bullet"){
                this.gameObject.SetActive(false);
            }
        }
    }
    IEnumerator Cooldown (float damageCooldown){
        yield return new WaitForSeconds(damageCooldown);
        canDoDamage = true;
    }
}
