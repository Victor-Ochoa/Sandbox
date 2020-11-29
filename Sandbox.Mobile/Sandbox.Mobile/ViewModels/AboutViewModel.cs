using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Sandbox.Protos;
using System;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Sandbox.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string _textGrpc;
        public string TextGrpc
        {
            get { return _textGrpc; }
            set { SetProperty(ref _textGrpc, value); }
        }

        public AboutViewModel()
        {
            try
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

                Title = "About";
                OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

                var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
                var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
                {
                    HttpClient = new HttpClient(handler)
                });


                var client = new OlaMundo.OlaMundoClient(channel);

                var reply = client.SaudacaoAsync(new OlaRequest { Name = "Victor" }).ResponseAsync.Result;

                TextGrpc = reply.Message;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ICommand OpenWebCommand { get; }
    }
}