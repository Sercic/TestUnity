using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public SpriteRenderer SprTip;
    [SerializeField]
    protected int ID;
    public bool CanTalk;
    public bool CanPack;

    public DiaLogue dia;

    public Collider2D Collider;

    private void Start()
    {
        HideTip();
        Collider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        ShowTip();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        HideTip();
        Player.Instance.TalkOver();
    }

    private void ShowTip()
    {
        SprTip.enabled = true;
    }
    private void HideTip()
    {
        SprTip.enabled = false;
    }

    protected abstract void Talk();

    protected abstract void IntoPackage();
}
