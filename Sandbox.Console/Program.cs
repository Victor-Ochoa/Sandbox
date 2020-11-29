using Grpc.Core;
using Grpc.Net.Client;
using Sandbox.Protos;
using System;

var option = new GrpcChannelOptions()
{
    Credentials = ChannelCredentials.Insecure
};
using (var channel = GrpcChannel.ForAddress("http://localhost:9120/",option))
{
    var client = new OlaMundo.OlaMundoClient(channel);

    var reply = await client.SaudacaoAsync(new OlaRequest { Name = "Victor" });

    System.Console.WriteLine(reply.Message);
}



