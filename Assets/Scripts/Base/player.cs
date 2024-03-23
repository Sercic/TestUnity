using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private CharacterController cc;
    private float Horizontal;
    public float Normalspeed;

    public Transform PosTrans;
    public Vector2 Offset;

    // Start is called before the first frame update
    void Start()
    {
        cc =GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.Instance.InTalk) { CCMove(); }
        

    }

    private void CCMove()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        cc.Move(new Vector3(0.01f, 0, 0) * Horizontal * Normalspeed);

        //实现摄像头转向
        if (Horizontal > 0)
        {
            PosTrans.localPosition = new Vector3(Offset.x, Offset.y, 0);
        }
        else if (Horizontal < 0)
        {
            PosTrans.localPosition = new Vector3(-Offset.x, Offset.y, 0);
        }
    }


}
