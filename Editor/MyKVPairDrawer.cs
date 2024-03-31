using GoldSprite.MyDict;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

// �Զ��������
[CustomPropertyDrawer(typeof(MyKVPair<,>))]
public class MyKVPairDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // ����ÿ��Ԫ�صı���
        SerializedProperty keyProperty = property.FindPropertyRelative("Key");
        SerializedProperty valProperty = property.FindPropertyRelative("Value");

        //�����key
        EditorGUI.BeginChangeCheck();

        position.height = EditorGUIUtility.singleLineHeight;

        var keyWidth = position.width / 6f;
        var marginRight = 15f;
        var keyRect = new Rect(position.x, position.y, keyWidth, position.height);
        var valRect = new Rect(position.x + keyWidth + marginRight, position.y, position.width - keyWidth - marginRight, position.height);
        keyProperty.stringValue = EditorGUI.DelayedTextField(keyRect, "", keyProperty.stringValue);

        EditorGUI.PropertyField(valRect, valProperty, /*new GUIContent(valProperty.type)*/GUIContent.none, true);

        if (EditorGUI.EndChangeCheck()) {
            EditorUtility.SetDirty(property.serializedObject.targetObject);
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // ��ȡ�ֶ� "Value" �ĸ߶�
        SerializedProperty valProperty = property.FindPropertyRelative("Value");
        float valueHeight = EditorGUI.GetPropertyHeight(valProperty, true);

        // �����ֶ� "Value" �߶ȼ���Ĭ�ϼ��
        return valueHeight + EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight * 0;
    }
}

// �Զ��������
[CustomPropertyDrawer(typeof(MyDict<,>))]
public class MyDictDrawer : PropertyDrawer {
    private float height;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var pairsProp = property.FindPropertyRelative("pairs");
        EditorGUI.PropertyField (position, pairsProp, new GUIContent(label.text+" - Pairs"));
        //var instance = fieldInfo.GetValue(property.serializedObject.targetObject);
        //var reType = fieldInfo.ReflectedType;
        //var method = reType.GetMethod("CheckFix");
        //method.Invoke(instance, new object[] { });
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var pairsProp = property.FindPropertyRelative("pairs");
        return EditorGUI.GetPropertyHeight(pairsProp, label) + EditorGUIUtility.standardVerticalSpacing;
    }
}
