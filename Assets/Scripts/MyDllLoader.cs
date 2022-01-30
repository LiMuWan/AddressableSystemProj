using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MyDllLoader : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        //Note:TextAsset不仅可用于加载文本数据，也可用于加载二进制数据
        //记载二进制数据（dll&pdb）到内存
        TextAsset dll = await Addressables.LoadAssetAsync<TextAsset>("HelloDll.dll").Task;
        TextAsset pdb = await Addressables.LoadAssetAsync<TextAsset>("HelloDLL.pdb").Task;

        //载入到mono 虚拟机内存
        var ass = Assembly.Load(dll.bytes, pdb.bytes);

        foreach (var t in ass.GetTypes())
        {
            Debug.LogWarning(t.Name);
        }

        Type type = ass.GetType("HelloDLL");
        //第一个参数是调用者，因为是静态函数，所以调用者写null
        //第二个参数是SayHello的参数，因为无参数，所以写null
        type.GetMethod("SayHello").Invoke(null, null);

        Addressables.Release<TextAsset>(dll);
        Addressables.Release<TextAsset>(pdb);
    }
}
