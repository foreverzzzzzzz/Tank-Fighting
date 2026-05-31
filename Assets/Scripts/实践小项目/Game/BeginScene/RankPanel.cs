using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    //关联public的 控件对象

    public CustomGUIButton btnClose;

    //因为控件较多 拖的话 工作量太大了 我们直接偷懒 通过代码找
    private List<CustomGUILabel> labName = new List<CustomGUILabel>();
    private List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();

    void Start()
    {
        for (int i = 1; i < 4; i++)
        {
            labName.Add(transform.Find("Name/Name" + i).GetComponent<CustomGUILabel>());
            labScore.Add(transform.Find("Score/Score" + i).GetComponent<CustomGUILabel>());
            labTime.Add(transform.Find("Time/Time" + i).GetComponent<CustomGUILabel>());
        }

        btnClose.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };
        
        
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }

    public void UpdatePanelInfo()
    {
        //处理根据排行榜数据 更新面板
        //获取 GameDataMgr中的排行榜列表 用于在这里更新
        //得数据
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        //根据列表更新面板数据
        for (int i = 0; i < list.Count; i++)
        {
            //名字
            labName[i].content.text = list[i].name;
            //分数
            labScore[i].content.text = list[i].score.ToString();
            //时间 存储的时间单位是s
            //把秒数 转换成 时  分 秒
            int time = (int)list[i].time;
            labTime[i].content.text = "";
            //得到 几个小时
            // 8432s  60*60 = 3600
            //8432 / 3600 ≈ 2时
            if ( time / 3600 > 0 )
            {
                labTime[i].content.text += time / 3600 + "时";
            }
            //8432-7200 余 1232s
            // 1232s / 60 ≈ 20分  
            if ( time % 3600 / 60 > 0 || labTime[i].content.text != "")
            {
                labTime[i].content.text += time % 3600 / 60 + "分";
            }
            //1232s-1200 余 32秒
            labTime[i].content.text += time % 60 + "秒";
        }

    }
}
