using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class CopyDLLTool : MonoBehaviour
{
    public const string src = "Library/ScriptAssemblies";
    // 拷贝目标
    public const string dest = "Assets/Resources_moved/MyDlls";
    //要拷贝的文件列表
    public static string[] files = new string[] { "HelloDLL.dll", "HelloDLL.pdb" };

    [MenuItem("Tools/Do Copy DLL")]
    public static void DoCopyDlls()
    {
        if(!Directory.Exists(dest))
        {
            Directory.CreateDirectory(dest);
        }

        foreach (var f in files)
        {
            //源文件逐个拷贝到目标位置，并改名加上.bytes后缀（只有.bytes后缀的文件会被认为是
            //二进制数据，dll无法被打包）
            Debug.Log($"{ Path.Combine(src, f)}=> { Path.Combine(dest, f + ".bytes")}");
            File.Copy(Path.Combine(src, f), Path.Combine(dest, f + ".bytes"), true);
        }

        AssetDatabase.Refresh();
    }
}
