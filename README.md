# LiveSharp
Original hot reload solution for .NET platform. This project has mostly been superceded by a built-in hot reload in .NET 6. However, there are still many issues with the native hot reload, that's why I decided to open LiveSharp to the public

This is a fork of https://github.com/ionoy/LiveSharp and I'm not the original author of the bulk of this code!

# Demo Project

* There is a simple sample Blazor project in the `/Demos/Simple-Blazor-Server` folder. Simply set that as the startup project and run after you have started livesharp server via `dontnet run` on the command line.
* Example 1: Go to Pages/Index.razor when the app is running and modify the css and save the file. The changes should update immediately.
* Example 2: Click the increment button several times. Now, go change the amount in the IncrementCounter() method and save the file, then click the button again.

# How to generate your own SSL Certificate

* Powershell admin, run the following line:

```
New-SelfSignedCertificate -CertStoreLocation Cert:\LocalMachine\My -DnsName "localhost.livesharp.net" -FriendlyName "Localhost Livesharp SSL" -NotAfter (Get-Date).AddYears(10)
```

* Export Cert as x509 no private key .CER file to /src/livesharp.server directory
	* Win+R > certlm.msc
	* Expand Personal > Certificates
	* Right Click new certificate on the right pane and select All Tasks > Export...
	* No private key
	* Choose Base-64 encoded X.509 (.CER)
	* Save this in your code path like: `c:\code\livesharp\src\livesharp.server\localhost.livesharp.net.cer`

* I've already changed the references to point to the new certificate in this code, but you can search for localhost.livesharp.net.cer to see where those are in the codebase.

* Build Livesharp Solution in Visual Studio

* Run livesharp-server like below, then launch your project from visual studio


# How to build

* Open and build LiveSharp.Build.sln
* Close LiveSharp.Build.sln
* Open and build LiveSharp.sln

# How to run locally

* Go to `src\LiveSharp.Server` and `dotnet run`
* Open your project and paste the following lines 
```
    <ItemGroup>
        <Reference Include="{PATH_TO_LIVESHARP}\livesharp\build\livesharp.dll" />
    </ItemGroup>
    
    <Import Project="{PATH_TO_LIVESHARP}\livesharp\build\livesharp.targets" />
```    
* Replace `{PATH_TO_LIVESHARP}` with the actual path to the repo
* Run your project


# Potential Errors

* You may need to install postcss-cli tool if you get an error on startup via command line. You can do that using npm by:
```
npm install postcss postcss-cli
```


