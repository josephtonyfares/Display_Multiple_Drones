using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LPS_TESTC
{
    class MqttClient
    {
        private IMqttClient mqttClient;
        private IMqttClientOptions options;
        private string topic;

        public MqttClient(IMqttClientOptions options, String topic)
        {
            this.options = options;
            this.topic = topic;
            this.mqttClient = new MqttFactory().CreateMqttClient();
            this.mqttClient.UseConnectedHandler(ConnectedHandler);
            this.mqttClient.UseApplicationMessageReceivedHandler(MessageHandler);
            this.mqttClient.UseDisconnectedHandler(DisconnectedHandler);
        }

        public async void ConnectedHandler(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("Connected with server!");
            await this.mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(this.topic).Build());
            Console.WriteLine("Subscribed to topic");
        }

        public void DisconnectedHandler(MqttClientDisconnectedEventArgs eventArgs)
        {
            Console.WriteLine("Disconnected from server");
        }

        public void MessageHandler(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            Console.WriteLine(Encoding.UTF8.GetString(eventArgs.ApplicationMessage.Payload));

            Position pos = new Position();
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(pos);

            string result = Encoding.UTF8.GetString(eventArgs.ApplicationMessage.Payload);
            List<Position> pos1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Position>>(result);
        }

        public async Task StartAsync()
        {
            await this.mqttClient.ConnectAsync(this.options, CancellationToken.None);
        }
    }
}
    

