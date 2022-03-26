using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LoadSence : MonoBehaviour
{
    private SpriteRenderer E;
    public SenceName senceName;
    public enum SenceName { Hall, Level1, 顶楼三角杂货间, 二楼阳台 , 格瑞实验室 ,华森特房间 };
    public int entrance;
    private void Start()
    {
        E = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    public void load()
    {
        SenceLoadManager.instance.LoadSence(senceName.ToString(), PlayerManager.instance.PlayerCreatVector[senceName.ToString()][entrance]) ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        E.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Destroy(this);
            load();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        E.enabled = false;
    }

}

#if UNITY_EDITOR
[CustomEditor(typeof(LoadSence))]
public class LoadSenceEidtor:Editor
{
    public override void OnInspectorGUI()
    {
        LoadSence script = target as LoadSence;
        script.senceName = (LoadSence.SenceName)EditorGUILayout.EnumPopup("SenceName:",
               script.senceName);
        script.entrance = EditorGUILayout.IntField("entrance", script.entrance);
    }
}

#endif


