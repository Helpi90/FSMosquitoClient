﻿namespace FSMosquitoClient
{
    using System;

    /// <summary>
    /// Represents an interface to a SimConnect wrapper.
    /// </summary>
    public interface IFsSimConnect : IDisposable
    {
        /// <summary>
        /// Event that is raised when a SimConnect connection is successfully established.
        /// </summary>
        public event EventHandler SimConnectOpened;

        /// <summary>
        /// Event that is raised when a SimConnect connection is closed. Usually if the game exits.
        /// </summary>
        public event EventHandler SimConnectClosed;

        /// <summary>
        /// Event that is raised when a previously subscribed topic value has changed.
        /// </summary>
        public event EventHandler<(SimConnectTopic, uint, object)> TopicValueChanged;

        /// <summary>
        /// Event that is raised when a SimConnect data object is received.
        /// </summary>
        public event EventHandler SimConnectDataReceived;

        /// <summary>
        /// Event that is raised when a SimConnect data object is requested.
        /// </summary>
        public event EventHandler SimConnectDataRequested;

        /// <summary>
        /// Gets a value that indicates if the current instance has been able to create a SimConnect instance
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets a value that indicates if the current instance has been disposed
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Gets a value that indicates if the SimConnect connection is open and active
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Start receiving messages from SimConnect
        /// </summary>
        /// <param name="handle"></param>
        void Connect(IntPtr handle);

        /// <summary>
        /// Stops receiving messages from SimConnect
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Sets a SimConnect Datum value on the specified object id with the indicated value
        /// </summary>
        /// <param name="datumName"></param>
        /// <param name="objectId"></param>
        /// <param name="value"></param>
        void Set(string datumName, uint? objectId, object value);

        /// <summary>
        /// Subscribes to a SimConnect Datum Topic
        /// </summary>
        /// <param name="topic"></param>
        void Subscribe(SimConnectTopic topic);

        /// <summary>
        /// Instruct the FsSimConnect instance to signal SimConnect to recieve a message.
        /// </summary>
        void SignalReceiveSimConnectMessage();
    }
}