using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    //移动速度
    public float moveSpeed = 50;
    //谁发射的我
    public TankBaseObj fatherObj;
    
    //特效对象
    public GameObject effObj;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            
            //当子弹销毁时 可以创建一个 爆炸特效
            if(effObj != null)
            {
                //创建爆炸特效
                GameObject eff = Instantiate(effObj, this.transform.position, this.transform.rotation);
                //改音效的音量和开启状态
                AudioSource audioS = eff.GetComponent<AudioSource>();
                //设置大小
                audioS.volume = GameDataMgr.Instance.musicData.soundValue;
                //设置是否开启
                audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }

            
            Destroy(this.gameObject);
        }
    }
    
    //设置拥有者
    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
}
