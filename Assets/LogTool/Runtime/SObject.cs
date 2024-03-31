using GoldSprite.MyDict;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SObject : ScriptableObject
{
    public Action Reload;
    [Tooltip("�Ƿ���ʾ��������־")] public bool showInterceptMsg = true;
    public MyDict<string, List<string>> logdatas;


    [ContextMenu("�ؼ���")]
    public void InitLogData()
    {
        Reload?.Invoke();
    }
}
