using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector3 Distance;
  
    // array for storing if the 3 mouse buttons are dragging
    bool[] isDragActive;
    // for remembering if a button was down in previous frame
    bool[] downInPreviousFrame;
    Rigidbody RigiPlayer;
    public int Speed,Forward;
    [SerializeField]
    GameObject Onion, chess, sausage, pork, sucered, tomato;
    int Number=0;
    public Text txtnumber;
    float target ;
    float Reward;


    void Start()
    {
        isDragActive = new bool[] { false, false, false };
        downInPreviousFrame = new bool[] { false, false, false };
        RigiPlayer = GetComponent<Rigidbody>();
      
    }
    private void FixedUpdate()
    {
        GetInput();
        if (Input.GetMouseButton(0))
        {
            RigiPlayer.velocity = new Vector3(RigiPlayer.velocity.x, RigiPlayer.velocity.y, Forward * Time.deltaTime);

        }
    }
    void GetInput()
    {
        for (int i = 0; i < isDragActive.Length; i++)
        {
            if (Input.GetMouseButton(i))
            {
                if (downInPreviousFrame[i])
                {
                    if (isDragActive[i])
                    {
                        OnDragging(i);
                    }
                    else
                    {
                        isDragActive[i] = true;
                        OnDraggingStart(i);
                    }
                }
                downInPreviousFrame[i] = true;
            }
            else
            {
                if (isDragActive[i])
                {
                    isDragActive[i] = false;
                    OnDraggingEnd(i);
                }
                downInPreviousFrame[i] = false;
            }
        }
    }

    public virtual void OnDraggingStart(int mouseButton)
    {
        Distance = Input.mousePosition;
    }

    public virtual void OnDragging(int mouseButton)
    {
        if (Input.mousePosition.x > Distance.x)
        {
            RigiPlayer.velocity = new Vector3(Speed * Time.deltaTime, RigiPlayer.velocity.y,RigiPlayer.velocity.z);

        }
        if (Input.mousePosition.x < Distance.x)
        {
            RigiPlayer.velocity = new Vector3(Speed * -Time.deltaTime , RigiPlayer.velocity.y, RigiPlayer.velocity.z);
        }
     
    }

    public virtual void OnDraggingEnd(int mouseButton)
    {
        Distance = Input.mousePosition;
        RigiPlayer.velocity = Vector3.zero;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Left")
        {
            sucered.SetActive(true);
            Number += 100;
            StartCoroutine(CounterNumber(Number));
        }
        if (other.gameObject.tag == "Left2")
        {
            pork.SetActive(true);
            Number += 400;
            StartCoroutine(CounterNumber(Number));
        }
        if (other.gameObject.tag == "Left3")
        {
            chess.SetActive(true);
            Number += 600;
            StartCoroutine(CounterNumber(Number));
        }
        if (other.gameObject.tag == "Right")
        {
            Onion.SetActive(true);
            Number += 50;
            StartCoroutine(CounterNumber(Number));
        }
        if (other.gameObject.tag == "Right2")
        {
            tomato.SetActive(true);
            Number += 500;
            StartCoroutine(CounterNumber(Number));
        }
        if (other.gameObject.tag == "Right3")
        {
            sausage.SetActive(true);
            Number += 550;
            StartCoroutine(CounterNumber(Number));
        }
        if (other.gameObject.tag == "Coin")
        {
            Number += 10;
           StartCoroutine (CounterNumber(Number));
            other.gameObject.SetActive(false);
          
            
        }

    }
    //public void CountNum(int numb)
    //{
    //    StartCoroutine(CounterNumber(numb));
    //}
    IEnumerator CounterNumber(float number)
    {
      
        float temp=0;
        float cc=0;
        temp = number;
        cc = temp / 25;
         
        for (int i = 0; target < number; i++)
        {
            target += cc;
            yield return new WaitForSeconds(.09f);
            txtnumber.text =Mathf.Round(target).ToString();
          
        }
    }



}
