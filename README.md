# dotnetGrpcPoc


# For creation of gRPC service - 

Start Visual Studio 2022 and select New Project.  
In the Create a new project dialog, search for gRPC. Select **ASP.NET Core gRPC Service** and select Next.  
In the Configure your new project dialog, enter **GrpcService** for Project name.   
Select Next.  
In the Additional information dialog, select **.NET 8.0** and then select Create.  





# For creation of gRPC client, in a .NET Console App -

The Visual Studio 2022 project requires the following NuGet packages:

* Grpc.Net.Client, which contains the .NET client.
* Google.Protobuf, which contains protobuf message APIs for C#.
* Grpc.Tools, which contain C# tooling support for protobuf files. The tooling package isn't required at runtime, so the dependency is marked with PrivateAssets="All".


Open a second instance of Visual Studio and select New Project.  
In the Create a new project dialog, select Console App, and select Next.  
In the Project name text box, enter **dotnetGrpcClient** and select Next.  
In the Additional information dialog, select **.NET 8.0** and then select Create.  



References:

https://learn.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-9.0&tabs=visual-studio

