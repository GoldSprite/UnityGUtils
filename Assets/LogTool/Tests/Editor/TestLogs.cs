using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLogs
{
    [Test]
    public void TestLog()
    {
        LogTool.NLog(msg:"���");
        Debug.Log("��ͨ��.");
        LogTool.NLog("kk", "���");
    }
}
