using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    public List<ItemData> Datas = new List<ItemData>();//数据
    public int datasCount;
    public List<Item> Items = new List<Item>();//元素

    /// <summary>
    /// 一组有多少个元素
    /// </summary>
    public int GroupItemNum;
    /// <summary>
    /// 总组数
    /// </summary>
    public int GroupNumSum;
    /// <summary>
    /// 当前位于的组
    /// </summary>
    public int currGroupIndex;
    /// <summary>
    /// 滑条实例化了几组
    /// </summary>
    public int ItemGroupIndex=-1;

    public int DataLength;
    /// <summary>
    /// 所有数据全部生成完成
    /// </summary>
    public bool isCreateOver;

    //界面元素
    public GameObject ItemObj;
    public RectTransform ItemParent;
    public ScrollRect scrollRect;
    public float itemHeight;
    public float ViewHeight;
    void Start () {

        for (int i = 0; i < datasCount; i++)
        {
            ItemData data = new ItemData();
            data.id = i;
            Datas.Add(data);
        }
        currGroupIndex = 0;
        DataLength = Datas.Count;
        scrollRect.onValueChanged.AddListener(OnValueChange);
        itemHeight = ItemObj.GetComponent<RectTransform>().sizeDelta.y+8;
        scrollRect.content.sizeDelta = new Vector2(0, itemHeight * Datas.Count);
        ViewHeight = scrollRect.GetComponent<RectTransform>().rect.height;
        Resh();
    }

    void OnValueChange(Vector2 value)
    {
        Resh();
    }
    public void Resh()
    {
        //实施改变视窗大小
        scrollRect.content.sizeDelta = new Vector2(0, itemHeight * Datas.Count);
        //计算当前屏幕在滑块区域的像素坐标
        float DownPos = ItemParent.anchoredPosition3D.y + ViewHeight;
        //计算应该应该实例化的元素个数
        int ItemNum = DownPos.StepToInt(itemHeight) + 2;
        //不能大于数据大小
        if (ItemNum > Datas.Count - 1)
            ItemNum = Datas.Count - 1;

        CreateItem(ItemNum);

        CheckItem();
    }
    /// <summary>
    /// 检查元素
    /// </summary>
    void CheckItem()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].data.IsRemove)
            {
                Debug.Log("删除元素"+ Items[i].data.id);
                Item temp = Items[i];
                Items.Remove(temp);
                temp.Disable();
            }
        }
    }

    /// <summary>
    /// 根据最大元素索引创建Item
    /// </summary>
    /// <param name="lastIndex"></param>
    void CreateItem(int lastIndex)
    {
        if (Items.Count > lastIndex)
            return;

        for (int i = Items.Count; i <= lastIndex; i++)
        {

            GameObject obj = Instantiate(ItemObj, ItemParent.transform, false);
            obj.SetActive(true);
            Item item = obj.GetComponent<Item>();
            item.data = Datas[i];
            Items.Add(item);
            obj.name = Datas[i].id.ToString();
            obj.GetComponentInChildren<Text>().text = Datas[i].id.ToString();
        }
    }

    
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ItemData date = new ItemData();
            date.id = Datas.Count;
            Datas.Add(date);
            Resh();
        }
      
        
    }
}
