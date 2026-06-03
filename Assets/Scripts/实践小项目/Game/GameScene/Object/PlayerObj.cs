using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj  : TankBaseObj
{
    public WeaponObj nowWeapon;
    
    //武器父对象位置
    public Transform weaponPos;
    
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
        if (nowWeapon != null)
        {
            nowWeapon.Fire();
        }
    }
    
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //更新主面板 血条
        GamePanel.Instance.UpdateHP(this.maxHp, this.hp);
    }
    
    /// <summary>
    /// 切换武器
    /// </summary>
    /// <param name="obj"></param>
    public void ChangeWeapon(GameObject weapon)
    {
        //删除当前拥有的武器
        if(nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }

        //切换武器
        //创建出武器 设置它的父对象 并且保证缩放没什么问题
        GameObject weaponObj = Instantiate(weapon, weaponPos, false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        //设置武器拥有者
        nowWeapon.SetFather(this);
    }
}
