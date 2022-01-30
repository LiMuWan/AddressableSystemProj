using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestAddressable : MonoBehaviour
{

    private void Start()
    {
        StartAsync();
    }
    // Start is called before the first frame update
    async Task StartAsync()
    {
        //UISystemProfilerApi.BeginSample(UISystemProfilerApi.SampleType.Layout);
        GameObject unit = await Addressables.InstantiateAsync("Cube", null, true).Task;
        //UISystemProfilerApi.EndSample(UISystemProfilerApi.SampleType.Layout);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
