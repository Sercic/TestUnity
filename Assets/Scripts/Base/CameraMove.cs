using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 父�饂�卞強重云
/// </summary>
public class CameraMove : MonoBehaviour
{
    private Camera m_Camera;
    public Transform TargetOrigin;
    private Vector3 TargetPosition;

    public Vector2 Offset;

    public float CameraMoveSpeed;
    private int Horizontal;

    public float CameraSizeNormal;
    public float CameraSizeinRun;
    public float CameraChangeSpeed;

    private bool isRun;
    private void Start()
    {
        m_Camera = GetComponent<Camera>();
        Horizontal = 1;
        isRun = false;
    }
    // Update is called once per frame
    void Update()
    {
        TargetPosition = new Vector3(TargetOrigin.position.x, TargetOrigin.position.y, this.transform.position.z);
        TargetPosition += new Vector3(Offset.x* Horizontal, Offset.y, 0);
        this.transform.position = Vector3.Slerp(this.transform.position, TargetPosition, CameraMoveSpeed * Time.deltaTime);

        var tmp_CameraSize = isRun? CameraSizeinRun : CameraSizeNormal;
        print(tmp_CameraSize);
        m_Camera.orthographicSize = Mathf.Lerp(m_Camera.orthographicSize, tmp_CameraSize, Time.deltaTime * CameraChangeSpeed);
    }
    public void ChangeHor(bool IsRight)
    {
        Horizontal = IsRight ? 1 : -1;
    }
    public void ChangeRun(bool isRun)
    {
        this.isRun = isRun;
    }
}
