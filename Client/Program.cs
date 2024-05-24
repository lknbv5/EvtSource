using EvtSource;
using Newtonsoft.Json;
using System.Text;

//var url = "http://localhost:5260/api/AI/GetMessage"; // 替换为你的SSE服务地址(Get)
var url = "http://10.8.2.251:3001/v1/chat/completions"; // 替换为你的SSE服务地址(Post)

var data = @"{ 
      ""model"":""qwen-long"",
      ""messages"": [ 
        { ""role"": ""system"", ""content"": ""用中文回答用户的问题"" },
        { ""role"": ""user"", ""content"": ""介绍一下你自己"" }
      ], 
      ""temperature"": 0.7, 
      ""stream"": true
    }";
var content = new StringContent(data,Encoding.UTF8,"application/json");
var evt = new EventSourceReader(new Uri(url), content,("Authorization", "Bearer sk-Z2egX6DGBQ6BcRN19fBf460d192045869d6b1c60867d4e2b")).Start();
evt.MessageReceived += (object sender, EventSourceMessageEventArgs e) => Console.WriteLine($"{e.Event} : {e.Message}");
//evt.Disconnected += async (object sender, DisconnectEventArgs e) =>
//{
//    Console.WriteLine($"Retry: {e.ReconnectDelay} - Error: {e.Exception}");
//    await Task.Delay(e.ReconnectDelay);
//    if (!evt.IsDisposed)
//    {
//        evt.Start(); // Reconnect to the same URL
//    }
//};

//Task.Run(() =>
//{
//    Task.Delay(2000).GetAwaiter().GetResult();
//    evt.Dispose();
//});

Console.ReadKey();