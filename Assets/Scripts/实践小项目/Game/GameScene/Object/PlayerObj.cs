using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj  : TankBaseObj

{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1.ws键 控制 前进后退
        //知识点 
        //1.Transform位移
        //2.Input 轴向输入检测
        this.transform.Translate( Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime);

        //2.ad键 控制 旋转
        //知识点
        //1.Transform旋转
        //2.Input 轴向输入检测
        this.transform.Rotate( Input.GetAxis("Horizontal") * Vector3.up * roundSpeed * Time.deltaTime);

        //3.鼠标左右移动 控制 炮台旋转
        //1.Transform旋转
        //2.Input 鼠标轴向输入检测
        tankHead.transform.Rotate( Input.GetAxis("Mouse X") * Vector3.up * headRoundSpeed * Time.deltaTime);

        //4.开火
        //Input
        if( Input.GetMouseButtonDown(0) )
        {
            Fire();
        }
    }

    public override void Fire()
    {
        
    }
}
