using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace PlaytSDK.Scripts.Api.Unity
{
    public static class UnityWebRequestExtension
    {
        public static TaskAwaiter<UnityWebRequest.Result> GetAwaiter(this UnityWebRequestAsyncOperation reqOp)
        {
            TaskCompletionSource<UnityWebRequest.Result> tsc = new();
            reqOp.completed += asyncOp => tsc.TrySetResult(reqOp.webRequest.result);

            if (reqOp.isDone)
            {
                tsc.TrySetResult(reqOp.webRequest.result);
            }

            return tsc.Task.GetAwaiter();
        }

        public static void SetDefaultHeaders(this UnityWebRequest request, ApiConfig config)
        {
            request.SetRequestHeader("X-Api-Key", config.ApiKey);
            request.SetRequestHeader("Accept", "application/json");
            request.SetRequestHeader("Content-Type", "application/json");
            request.uploadHandler.contentType = "application/json";
        }
    }
}