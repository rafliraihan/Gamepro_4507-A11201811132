using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gerak : MonoBehaviour
{
    // Start is called before the first frame update
    Text infonyawa,infokoin;

    public int kecepatan,kekuatanLompat;
    public bool balik;
    public int pindah;


    Rigidbody2D lompat;
    public bool tanah;
    public LayerMask targetlayer;
    public Transform deteksitanah;
    public float jangkauan;

    Animator anim;

    public int nyawa;
    public int koin;

    Vector2 mulai;
    public bool ulang;

    public bool tombolkiri,tombolkanan,tombollompat;
    public GameObject menang,kalah;

    void Start()
    {
        infonyawa = GameObject.Find("UInyawa").GetComponent<Text>();
        infokoin = GameObject.Find("UIkoin").GetComponent<Text>();
        lompat = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        mulai = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        infonyawa.text = "Nyawa : " + nyawa.ToString();
        infokoin.text = "Score : " + koin.ToString();

        if(ulang == true)
        {
            transform.position = mulai;
            ulang = false;
        }

        if(nyawa <=0){
            Destroy(gameObject);
            kalah.SetActive(true);
        } else if(koin>=14){
            menang.SetActive(true);
        }

        if(tanah == true){
            anim.SetBool("lompat",false);
        }else{
            anim.SetBool("lompat",true);
        }
        tanah = Physics2D.OverlapCircle (deteksitanah.position, jangkauan, targetlayer);
        if (Input.GetKey (KeyCode.D) || (tombolkanan == true)){
            anim.SetBool("lari", true);
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah=1;
        }else if (Input.GetKey (KeyCode.A) || (tombolkiri == true)){
            anim.SetBool("lari", true);
            transform.Translate(Vector2.left * kecepatan * Time.deltaTime);
            pindah=-1;
        }else{
            anim.SetBool("lari",false);
        }
        if ( tanah == true && ((Input.GetKey (KeyCode.W)) || (tombollompat == true))){
            lompat.AddForce(new Vector2(0,kekuatanLompat));
        }
        if (pindah > 0 && !balik){
            balikbadan();
        }else if(pindah < 0 && balik){
            balikbadan();
        }
    }
    void balikbadan(){
        balik = !balik;
        Vector3 karakter = transform.localScale;
        karakter.x *= -1;
        transform.localScale = karakter;
    }
    public void tekankiri(){
        tombolkiri = true;
    }
    public void lepaskiri(){
        tombolkiri = false;
    }

    public void tekankanan(){
        tombolkanan = true;
    }
    public void lepaskanan(){
        tombolkanan = false;
    }
     public void tekanlompat(){
        tombollompat=true;
    }
    public void lepaslompat(){
        tombollompat = false;
    }
}
