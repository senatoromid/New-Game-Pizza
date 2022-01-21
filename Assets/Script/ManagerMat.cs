using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMat : MonoBehaviour
{
    Renderer _RendererPlayer;

    public GameObject Player;

    public Texture2D txtPlayerNew;
    Color32 _color = new Color32(0, 233, 60, 255);

    // Start is called before the first frame update
    void Start()
    {
        _RendererPlayer = Player.GetComponent<Renderer>();

        //change texture
        _RendererPlayer.material.SetColor("_Color", _color);
        _RendererPlayer.material.SetTexture("_MainTex", txtPlayerNew);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
