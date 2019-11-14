using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;
using System.Windows;
using System.Threading;
using System.Windows.Threading;

namespace _5eDiscordBot.Modules.Public
{
	public class BotModule : ModuleBase
	{
        public DispatcherSynchronizationContext UISync { get; private set; }

        [Command("ping", RunMode = RunMode.Async)]

		public async Task SendPong()
		{
			await Context.Channel.SendMessageAsync($"{Context.User.Mention}, Pong!");
		}

		[Command("roll", RunMode = RunMode.Async)]
		public async Task RollDice()
		{
			Random rand = new Random();
			await Context.Channel.SendMessageAsync($"{Context.User.Mention}, " + rand.Next(1, 20));
		}
        [Command("init", RunMode = RunMode.Async)]
        public async Task AddIntiative(int modifier)
        {
            int result = 0;
            Random rand = new Random();
            result = rand.Next(1, 20) + modifier;
            await Context.Channel.SendMessageAsync($"{Context.User.Mention}, rolled " + result + "for intiative.");
        }
    }

}
