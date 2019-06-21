# xui
Open source interface for Synapse X

## Setting up
In order to get this UI working, you need to do a few things:
1) Remove the refrence to 'sxlib' and add your it to your own path. See https://github.com/LoukaMB/SynapseX/wiki/SxLib-API for instructions on how to do this.
2) You either must put the output exe in your Synapse `bin` folder or set the `SxLib.InitializeWPF` call in `SplashScreen.xaml.cs` to your own directory instead of the path combo it uses by default.