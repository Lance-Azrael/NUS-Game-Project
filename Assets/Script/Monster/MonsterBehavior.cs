using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBehavior : MonoBehaviour
{
    public GameObject Hero;

    public int HP;
    public int MaxHP;
    public int Attack;
    public int Defence;
    public float Speed;
    public float Critical;

    public Slider HpBarSlider;
    public int Direction;
    public bool freeze;

    public int Wood;
    public int Stone;
    public int Money;

    public int Upd;
    private Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Upd = TimeManager.MonsterUpd;
        HP = 10 + Upd;
        MaxHP = 10 + Upd;
        Attack = 5 + Upd;
        Defence = 1 + Upd;
        Speed = 1.5f;
        Critical = 0f;
        Hero = GameObject.Find("Hero");
        freeze  = false;
        Wood = 2 + Upd;
        Stone = 2 + Upd;
        Money = 50 + 10 * Upd;

        mAnimator = GetComponent<Animator>();
        mAnimator.SetTrigger("run");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0){
            Destroy(gameObject);
            Hero.GetComponent<HeroBehavior>().Wood += Wood;
            Hero.GetComponent<HeroBehavior>().Stone += Stone;
            Hero.GetComponent<HeroBehavior>().Money += Money;
        }
        FindDirection();
        if(!freeze){
           Move(); 
        }
        HpBarSlider.value = (float) HP / (MaxHP*1.0f);
        
    }

    void FindDirection(){
        float d = Hero.transform.position.x - transform.position.x;
        if (d > 0){
            Direction =  1;
        }else{
            Direction = -1;
        }
    }

    void Move(){
        Vector3 position = GetComponent<Transform>().position;
        position.x += Direction * Speed * Time.smoothDeltaTime;
        GetComponent<Transform>().position = position;
    }

    public void Freeze(){
        freeze = true;
        mAnimator.SetTrigger("stand");
    }
    public void DeFreeze(){
        freeze = false;
        mAnimator.SetTrigger("run");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Hero"){
            Freeze();
        }
    }
    
    public void isHit(int demage){

        if (demage < Defence){
            return;
        }
        HP -= (demage - Defence);
        
    }
}
