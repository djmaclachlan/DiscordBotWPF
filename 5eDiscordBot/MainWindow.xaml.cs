using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Discord;
using Discord.WebSocket;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiscordBotApplication;
using System.Threading;

namespace _5eDiscordBot
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        public string guild, channel;
		DiscordSocketClient Client;
		CommandHandler Handler;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
		private async void btnConnect_Click(object sender, RoutedEventArgs e)
		{
			Handler = new CommandHandler();
			Client = new DiscordSocketClient(new DiscordSocketConfig()
			{
				LogLevel = LogSeverity.Verbose,
				//WebSocketProvider = Discord.Net.Providers.WS4Net.WS4NetProvider.Instance
				//Pretty sure this was just to make it run on win 7, we'll decide what to do with it later
			});

			await Handler.Install(Client);
			Client.Log += Client_Log;
			try
			{
				await Client.LoginAsync(TokenType.Bot, btnTokenID.Text);
				await Client.StartAsync();
			}
			catch (Exception ex)
			{
				MessageBox.Show("There was an error connecting to that token, please verify and try again.");
				Console.WriteLine(ex);
				return;
			}
		}
        public void InitiativeUpdate(string user, int initiative)
        {
        }
		private Task Client_Log(LogMessage arg)
		{
			Dispatcher.Invoke((Action)delegate
			{
				tbOutput.Text += arg + "\n";
			});
			return null;
		}



        public MainWindow()
		{
			InitializeComponent();
		}
	}
}
