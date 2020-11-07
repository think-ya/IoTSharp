﻿using CoAP;
using CoAP.Server;
using DotNetCore.CAP.Dashboard.NodeDiscovery;
using EFCore.Sharding;
using MaiKeBing.CAP;
using MaiKeBing.HostedService.ZeroMQ;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace IoTSharp
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TelemetryStorage
    {
        SingleTable,
        Sharding,
        Taos,
        InfluxDB,
        InfluxDBV1
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventBusStore
    {
        PostgreSql,
        MongoDB,
        InMemory,
        LiteDB
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventBusMQ
    {
        RabbitMQ,
        Kafka,
        InMemory,
        ZeroMQ
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CachingUseIn
    {
        InMemory,
        Redis,
        LiteDB,
        SQlite
    }
    public class AppSettings
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public int JwtExpireHours { get; set; }
        /// <summary>
        /// Broker settings
        /// </summary>
        public MqttBrokerSetting MqttBroker { get; set; } = new MqttBrokerSetting();
        /// <summary>
        /// mqtt client settings
        /// </summary>
        public MqttClientSetting MqttClient { get; set; } = new MqttClientSetting() { MqttBroker = "built-in", UserName = Guid.NewGuid().ToString(), Password = Guid.NewGuid().ToString(), Port = 1883 };
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public CoapConfig CoapServer { get; set; } = new CoapConfig();

        public ModBusServerSetting ModBusServer { get; set; } = new ModBusServerSetting();

        public TelemetryStorage TelemetryStorage { get; set; } = TelemetryStorage.SingleTable;

        public ShardingSetting Sharding { get; set; } = new ShardingSetting();
        public  EventBusStore EventBusStore { get; set; } = EventBusStore.InMemory;
        public   EventBusMQ EventBusMQ { get; set; } = EventBusMQ.InMemory;
        public int ConsumerThreadCount { get; set; } = Environment.ProcessorCount;
        public int DbContextPoolSize { get; set; } = 128;
        public CachingUseIn CachingUseIn { get; set; } = CachingUseIn.InMemory;
        public  string CachingUseRedisHosts { get; set; }
        public DiscoveryOptions Discovery { get; set; } = null;
        public ZMQOption ZMQOption { get; set; } = null;

        
    }
  
    public class ShardingSetting
    {
        public DatabaseType DatabaseType { get; set; } = DatabaseType.PostgreSql;
        public ExpandByDateMode ExpandByDateMode { get; set; } = ExpandByDateMode.PerMonth;
    }
    public class ModBusServerSetting
    {
        public int Port { get; set; } = 502;
        public int TimeOut { get; set; } = 120000;
    }
    public class MqttClientSetting
    {
        /// <summary>
        /// built-in or IP、HostName
        /// </summary>
        public string MqttBroker { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
    public class MqttBrokerSetting
    {
        public int Port { get; set; } = 1883;
        public int TlsPort { get; set; } = 8883;
        public bool EnableTls { get; set; } = false;
        public string Certificate { get; set; }
        public SslProtocols SslProtocol { get; set; } = SslProtocols.None;
        public bool PersistRetainedMessages { get; set; }
    }
}
