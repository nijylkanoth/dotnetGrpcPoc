using Grpc.Net.Client;
using GrpcClient;

using var channel = GrpcChannel.ForAddress("https://localhost:7090");
//var client = new Greeter.GreeterClient(channel);
//var reply = await client.SayHelloAsync(new HelloRequest { Name = "Hello World here ..." });

var tempClient = new Temperature.TemperatureClient(channel);
var tempReply = await tempClient.GetTemperatureAsync(new TemperatureRequest() { Unit= UnitOfTemperature.Kelvin, ConvertTo = UnitOfTemperature.Celsius, Value= 300f });


Console.WriteLine($"Reply from GRPC server: {tempReply.Reply}");
Console.WriteLine("Press any key to exit ...");
Console.ReadKey();


