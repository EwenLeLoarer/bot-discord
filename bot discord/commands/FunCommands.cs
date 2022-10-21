using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;

namespace bot_discord.commands
{
    public class FunCommands 
    {
        [Command("ping")]
        [Description("show the ping")]

        public async Task Ping(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            // let's make the message a bit more colourful
            var emoji = DiscordEmoji.FromName(ctx.Client, ":ping_pong:");

            // respond with ping
            await ctx.RespondAsync($"{emoji} Pong! Ping: {ctx.Client.Ping}ms");
        }

        [Command("show_Detail")]
        [Description("show the stats of an user: all, username, image, nbdays, mean_score, watching, completed, on_hold, dropped, plan_to_watch or episodes_watched")]
        public async Task showUser(CommandContext ctx,string name, string option)
        {
            await ctx.TriggerTypingAsync();
            string url = "https://api.jikan.moe/v3/user/" + name;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string MyContent = await content.ReadAsStringAsync();
                        
                        dynamic MyContentJson = JsonConvert.DeserializeObject<dynamic>(MyContent);

                        switch(option)
                        {
                            case "all":
                                await ctx.Channel.SendMessageAsync("username: " + MyContentJson["username"].ToString() + "\n"
                           + "image:" + MyContentJson["image_url"].ToString());
                                await ctx.Channel.SendMessageAsync("number of days: " + MyContentJson["anime_stats"]["days_watched"].ToString() + "\n" +
                                     "mean score: " + MyContentJson["anime_stats"]["mean_score"].ToString());
                                await ctx.Channel.SendMessageAsync("anime watching: " + MyContentJson["anime_stats"]["watching"].ToString() + "\n" +
                                    "anime completed: " + MyContentJson["anime_stats"]["completed"].ToString());
                                await ctx.Channel.SendMessageAsync("anime on_hold: " + MyContentJson["anime_stats"]["on_hold"].ToString() + "\n" +
                                    "anime dropped: " + MyContentJson["anime_stats"]["dropped"].ToString());
                                await ctx.Channel.SendMessageAsync("anime plan_to_watch: " + MyContentJson["anime_stats"]["plan_to_watch"].ToString() + "\n" +
                                    "episode watch: " + MyContentJson["anime_stats"]["episodes_watched"].ToString());
                                break;
                            case "username":
                                await ctx.Channel.SendMessageAsync("username: " + MyContentJson["username"].ToString());
                                break;
                            case "image":
                                await ctx.Channel.SendMessageAsync("image: " + MyContentJson["image_url"].ToString());
                                break;
                            case "nbdays":
                                await ctx.Channel.SendMessageAsync("nombres de jours: " + MyContentJson["anime_stats"]["days_watched"].ToString());
                                break;
                            case "mean_score":
                                await ctx.Channel.SendMessageAsync("moyenne des scores: " + MyContentJson["anime_stats"]["mean_score"].ToString());
                                break;
                            case "watching":
                                await ctx.Channel.SendMessageAsync("nombres d'animes en cours: " + MyContentJson["anime_stats"]["watching"].ToString());
                                break;
                            case "completed":
                                await ctx.Channel.SendMessageAsync("nombres d'animes terminer: " + MyContentJson["anime_stats"]["completed"].ToString());
                                break;
                            case "on_hold":
                                await ctx.Channel.SendMessageAsync("nombres d'anime en suspend: " + MyContentJson["anime_stats"]["on_hold"].ToString());
                                break;
                            case "dropped":
                                await ctx.Channel.SendMessageAsync("nombres d'anime aretter: " + MyContentJson["anime_stats"]["dropped"].ToString());
                                break;
                            case "plan_to_watch":
                                await ctx.Channel.SendMessageAsync("nombres d'anime a voir: " + MyContentJson["anime_stats"]["plan_to_watch"].ToString());
                                break;
                            case "episodes_watched":
                                await ctx.Channel.SendMessageAsync("nombres d'episode vus: " + MyContentJson["anime_stats"]["episodes_watched"].ToString());
                                break;
                                
                        }

                       
                    }
                }
            }   
        }
        
        
        

    }
    
    
}

