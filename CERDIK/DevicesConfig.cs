//Runtime Config

using CERDIK;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

public class DevicesConfig
{
    public DevicesAddConfig config;
    public const string filepath = @"DevicesAddConfig.json";
    public DevicesConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch (Exception)
        {
            SetDefault();
            WriteNewConfigFile();
        }
    }
    private DevicesAddConfig ReadConfigFile()
    {
        string configJsonData = File.ReadAllText(filepath);
        config = JsonSerializer.Deserialize<DevicesAddConfig>(configJsonData);
        return config;
    }

    private void SetDefault()
    {
        config = new DevicesAddConfig("[Nama] ", "[Os] ", "Merek");
    }
    private void WriteNewConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(filepath, jsonString);
    }

}

