using Grpc.Net.Client;
using Sandbox.Protos;
using System;

using (var channel = GrpcChannel.ForAddress("https://localhost:5001/"))
{
    var client = new OlaMundo.OlaMundoClient(channel);

    var reply = await client.SaudacaoAsync(new OlaRequest { Name = "Victor" });

    System.Console.WriteLine(reply.Message);
}



