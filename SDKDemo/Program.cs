using System;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace ProjectSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Authenticating...");
            var azure = Authenticate();
            Console.WriteLine( "Authenticated\n Now creating your Virtual Machine... ");
            var windowsVM = azure.VirtualMachines.Define("qa-dev-vm")
    .WithRegion(Region.USEast)
    .WithNewResourceGroup("qa-dev-vm-rg")
    .WithNewPrimaryNetwork("10.0.0.0/28")
    .WithPrimaryPrivateIPAddressDynamic()
    .WithNewPrimaryPublicIPAddress("qa-dev-ip")
    .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
    .WithAdminUsername("farzanaakter")
    .WithAdminPassword("p@ssw0rd123")
    .WithSize(VirtualMachineSizeTypes.StandardD3V2)
    .Create();
Console.WriteLine("Done creating.");
        }

         static IAzure Authenticate()
{
    var credentials = SdkContext.AzureCredentialsFactory
        .FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

    var azure = Azure
        .Configure()
        .Authenticate(credentials)
        .WithDefaultSubscription();
    return azure;
}
    }

   
}
