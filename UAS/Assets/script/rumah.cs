using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rumah : MonoBehaviour
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
            KomponenGerak.koin++;
            Destroy(KomponenGerak.gameObject);
        }
    }
}

