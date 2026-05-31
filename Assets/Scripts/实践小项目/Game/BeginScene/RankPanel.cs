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
    
    public void UpdatePanelInfo(){}
}
