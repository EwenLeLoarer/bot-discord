using bot_discord.commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot_discord
{
    public class Bot
    { 
        public DiscordClient Client { get; private set; }

        public InteractivityModule Interactivity { get; private set; }

        public CommandsNextModule Commands { get; private set; }
        public async Task RunAsync()
        {
            var json = String.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);



            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };
            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            Client.UseInteractivity(new InteractivityConfiguration
                {
                
                });
            var CommandeConfig = new CommandsNextConfiguration
            {
                StringPrefix =configJson.prefix,
                EnableDms = false,
                EnableMentionPrefix = true,
                EnableDefaultHelp = true,
                
            };

            Commands = Client.UseCommandsNext(CommandeConfig);

            Commands.RegisterCommands<FunCommands>();
            Commands.RegisterCommands<RoleCommands>();


            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
