using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuh : MonoBehaviour
{
    gerak KomponenGerak;
    // Start is called before the first frame update
    void Start()
    {
        KomponenGerak = GameObject.Find("player").GetComponent<gerak>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player"){
            KomponenGerak.nyawa--;
            KomponenGerak.ulang = true;
        }
    }
}
