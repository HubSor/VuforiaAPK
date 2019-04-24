using UnityEditor;

[CustomEditor (typeof(text))]
public class CiekawostkaIns:Editor
{
    public override void OnInspectorGUI()
    {
        text temp = (text)target;
        temp.tekstciekawostki = EditorGUILayout.TextArea("sample text: ", temp.tekstciekawostki);
            
    }
}