using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class LogTool {
    public static bool IsInit;
    public static SObject Options;
    public static void Init()
    {
        var paths = AssetDatabase.FindAssets("t:SObject");
        try {
            //string path = "";
            //foreach (var guid in paths) {
            //    path = AssetDatabase.GUIDToAssetPath(guid);
            //    if (AssetDatabase.LoadAssetAtPath<SObject>(path) == null) continue;
            //    Options = AssetDatabase.LoadAssetAtPath<SObject>(path);
            //}
            var guid = "9fa48f51ff07d8c45833c96502a5040c";
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Options = AssetDatabase.LoadAssetAtPath<SObject>(path);
            IsInit = true;
            NLog(tag: "default", msg: "�Ѽ���Ĭ������: " + path);
        }
        catch (Exception) {
            IsInit = true;
            NLog(tag: "default", msg: "�Ҳ����κ�����, ���ֶ�����.");
        }

        Options.Reload = () => { Init(); };
    }
    public static void NLog(object msg = default) => NLog("", msg);
    public static void NLog(string tag, object msg)
    {
        //
        if (!IsInit) Init();

        tag = string.IsNullOrEmpty(tag) ? "default" : tag;

        if (msg == default || !DisPlayLog(tag))
            return;

        var log = ""
            + "[" + tag + "] "
            + msg
            ;
        Debug.Log(log);
    }
    public static bool DisPlayLog(string tag)
    {
        var exist = Options.logdatas.ContainsKey(tag);
        if (!exist && Options.showInterceptMsg) NLog($"{tag} �ѱ�����.");
        return exist;
    }
}
