﻿namespace FSMosquitoClient
{
    using Microsoft.FlightSimulator.SimConnect;
    using System;
    using System.Threading.Tasks;

    public interface IFsMqtt : IDisposable
    {
        /// <summary>
        /// Event that is raised when an MQTT Connection is successfully established.
        /// </summary>
        public event EventHandler MqttConnectionOpened;

        /// <summary>
        /// Event that is raised when an MQTT Connection is closed. Usually due to server shutdown/issues.
        /// </summary>
        public event EventHandler MqttConnectionClosed;

        /// <summary>
        /// Event that is raised when a SimConnect Topic Subscription Request is recieved.
        /// </summary>
        public event EventHandler<SimConnectTopic[]> SubscribeRequestRecieved;

        /// <summary>
        /// Gets a value that indicates if the current instance is connected to MQTT
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets a value that indicates if the current instance has been disposed
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Start receiving messages from MQTT
        /// </summary>
        Task Connect();

        /// <summary>
        /// Stops receiving messages from MQTT
        /// </summary>
        Task Disconnect();

        /// <summary>
        /// Publishes the specified topic value to the MQTT broker
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task PublishTopicValue(SimConnectTopic topic, double value);
    }
}
