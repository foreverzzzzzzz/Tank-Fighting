using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance { get => instance; }

    //音效数据对象
    public MusicData musicData;
    

    private GameDataMgr()
    {
        //可以去初始化 游戏数据
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        //如果第一次进入游戏 没有音效数据 那么所有的数据要不是false 要不是0
        if( !musicData.notFirst )
        {
            musicData.notFirst = true;
            musicData.isOpenBK = true;
            musicData.isOpenSound = true;
            musicData.bkValue = 1;
            musicData.soundValue = 1;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
        }
    }
    
    //开启或者关闭背景音乐
    public void OpenOrCloseBKMusic(bool isOpen)
    {
        musicData.isOpenBK = isOpen;
        

        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    //开启或者关闭音效
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    //改变背景音乐大小
    public void ChangeBKValue(float value)
    {
        musicData.bkValue = value;
        

        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    //改变背景音乐大小
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        //存储改变后的数据
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }


}
