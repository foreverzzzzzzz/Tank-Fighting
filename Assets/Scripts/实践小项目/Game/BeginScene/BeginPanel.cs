using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    //首先声明公共的成员变量 来关联各个控件
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;

    // Start is called before the first frame update
    void Start()
    {
        

        //监听一次按钮点击过后要做什么
        btnBegin.clickEvent += () =>
        {
            //切换场景
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.clickEvent += () =>
        {
            
        };
        btnQuit.clickEvent += () =>
        {
            //退出游戏
            Application.Quit();
        };
        btnRank.clickEvent += () =>
        {
            
        };
    }

}
