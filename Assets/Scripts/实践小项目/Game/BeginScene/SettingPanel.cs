using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : BasePanel<SettingPanel>
{
    //1声明成员变量 关联控件
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;

    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;

    public CustomGUIButton btnClose;

    private void Start()
    {
        //2监听对应的事件 处理逻辑
        //处理音乐的变化
        sliderMusic.changeValue += (value) => {};
        //处理音效的变化
        sliderSound.changeValue += (value) => {};

        //处理音乐开关
        togMusic.changeValue += (value) => {};
        //处理音效开关
        togSound.changeValue += (value) => {};

        btnClose.clickEvent += () =>
        {
            //隐藏自己
            HideMe();
            //让开始面板重新显示出来
            BeginPanel.Instance.ShowMe();
        };
        
        HideMe();
    }
}
