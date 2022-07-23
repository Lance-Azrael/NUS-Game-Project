using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class BossBehavior : MonoBehaviour
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

    private Animator mAnimator;

    public static bool isWin;

    Vector3 StartPoint;
    // Start is called before the first frame update
    void Start()
    {
        HP = 300;
        MaxHP = 300;
        Attack = 40;
        Defence = 20;
        Speed = 2.0f;
        Critical = 0f;
        HpBarSlider.value = 1.0f;
        Hero = GameObject.Find("Hero");
        freeze  = false;
        isWin = false;
        StartPoint = transform.position;
        mAnimator = GetComponent<Animator>();
        //mAnimator.SetBool("Grounded",true);
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0){
            isWin = true;
            Destroy(gameObject);
            GameObject.Find("Canvas").transform.Find("WinPanel").gameObject.SetActive(true);
            //Hero.GetComponent<HeroBehavior>().Money += 50000;
            //mAnimator.SetTrigger("Death");
            
        }
        FindDirection();
        if(!freeze){
            //mAnimator.SetTrigger("Walk");
            Move(); 
        }
        else{
            //mAnimator.SetTrigger("Attack");
        }
        HpBarSlider.value = (float) HP / (MaxHP * 1.0f);
        if (Hero.GetComponent<HeroBehavior>().death){
            HP = MaxHP;
            transform.position = StartPoint;
            DeFreeze();
        }
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
    }
    public void DeFreeze(){
        freeze = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Hero"){
            Freeze();
        }
    }
    
    public void isHit(int demage){
        HP -= (int)Math.Round((double)demage * (1f - (double)Defence / ((double)Defence + 40f)));
    }
}