using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using System.Threading;

namespace LPS_TESTC
{
    public partial class Form1 : Form
    {
        private Point mOrigin;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var host = "192.168.250.74";
            var port = 1883;
            var topic = "tags";

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(host, port)
                .Build();
                
            var mqttClient = new MqttClient(options, topic);
           Task.Run(() => mqttClient.StartAsync());
            Thread.Sleep(Timeout.Infinite);
        }
        private void Draw_Gameplan()
        {
            Controller_Visual.toGameplan cntrl = new Controller_Visual.toGameplan();
            // Reset_Ice()

            if (mOrigin.X == 0 && mOrigin.Y == 0)
            {
                mOrigin = new Point(50, 100);
            }

            int xStart = mOrigin.X;
            int yStart = mOrigin.Y;
            int yInc = 20;
            mOrigin = new Point(xStart, yStart);
            SortedDictionary<int, Visual_Element> elemsPlayer = new SortedDictionary<int, Visual_Element>();

            elemsPlayer.Add(0, mPlayer);
            cntrl.Draw_Elements_on_Image(mOrigin, elemsPlayer, ref pbIce.BackgroundImage);
            yStart += yInc;


            'Draw Drone Flightplans
                foreach (sentry In mElements)
                For Each entry In mElements

                   Dim clr As Color = entry.Key
            Dim elems As SortedDictionary(Of Integer, Visual_Element) = entry.Value

            mOrigin = New Point(xStart, yStart)
            cntrl.Draw_Elements_on_Image(mOrigin, elems, pbIce.BackgroundImage)

            If elems.Count > 0 Then yStart += yInc

        Next
            }

    }
}




//    private void button1_Click(object sender, EventArgs e)
//    {
//        var host = "mqtt.cloud.pozyxlabs.com";
//        var port = 443;
//        var topic = "5d6517e9c1235e5286a0f702";
//        var username = "5d6517e9c1235e5286a0f702";
//        var password = "295916ef-d8d0-4c57-9e6e-ee40a899986f";

//        var options = new MqttClientOptionsBuilder()
//            .WithWebSocketServer(host + ":" + port)
//            .WithTls()
//            .WithCredentials(username, password)
//            .Build();

//        var mqttClient = new MqttClient(options, topic);
//        Task.Run(() => mqttClient.StartAsync());
//        Thread.Sleep(Timeout.Infinite);
//    }

//    class MqttClient
//    {
//        private IMqttClient mqttClient;
//        private IMqttClientOptions options;
//        private string topic;

//        public MqttClient(IMqttClientOptions options, String topic)
//        {
//            this.options = options;
//            this.topic = topic;
//            this.mqttClient = new MqttFactory().CreateMqttClient();
//            this.mqttClient.UseConnectedHandler(ConnectedHandler);
//            this.mqttClient.UseApplicationMessageReceivedHandler(MessageHandler);
//            this.mqttClient.UseDisconnectedHandler(DisconnectedHandler);
//        }

//        public async void ConnectedHandler(MqttClientConnectedEventArgs e)
//        {
//            Console.WriteLine("Connected with server!");
//            await this.mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(this.topic).Build());
//            Console.WriteLine("Subscribed to topic");
//        }

//        public void DisconnectedHandler(MqttClientDisconnectedEventArgs eventArgs)
//        {
//            Console.WriteLine("Disconnected from server");
//        }

//        public void MessageHandler(MqttApplicationMessageReceivedEventArgs eventArgs)
//        {
//            Console.WriteLine(Encoding.UTF8.GetString(eventArgs.ApplicationMessage.Payload));
//        }

//        public async Task StartAsync()
//        {
//            await this.mqttClient.ConnectAsync(this.options, CancellationToken.None);
//        }
//    }
//}