using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    Player pp;
    int Reward;
    private void Start()
    {
        pp = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
       // print(Reward);
        if (other.gameObject.tag == "Player")
        {
            //gameObject.SetActive(false);
            //Reward+= 100;
            //pp.CountNum(Reward);
            //print("Rew" + Reward);

        }
    }
}
