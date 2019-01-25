using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public ItemData data;
    public Button btn;
    public Test test;

    private void Start()
    {
        btn.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        Debug.Log("点击" + this.gameObject.name);
        if (Input.GetKey(KeyCode.Q))
        {
            test.Datas.Remove(data);
            data.IsRemove = true;
            test.Resh();
        }
    }
    public void Disable()
    {
        data = null;
        Destroy(this.gameObject);
    }
}
