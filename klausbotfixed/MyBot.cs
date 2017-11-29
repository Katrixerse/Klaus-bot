using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordbot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;


        Random rand;

        string[] ballres;
        string[] freshestroast;

        public User Reason { get; private set; }

        //string reason;


        public MyBot()
        {

            var discord = new DiscordClient();


            rand = new Random();

            ballres = new string[]
           {
                "It is certain",
                "It is decidedly so",
                "Without a doubt",
                "Yes definitely",
                "You may rely on it",
                "As I see it, yes",
                "Most likely",
                "Outlook good",
                "Yes",
                "Signs point to yes",
                "Reply hazy try again",
                "Ask again later",
                "Better not tell you now",
                "Cannot predict now",
                "Concentrate and ask again",
                "Don't count on it",
                "My reply is no",
                "My sources say no",
                "Outlook not so good",
                "Very doubtful"
           };

            freshestroast = new string[]
{
                "When you're getting roasted in the group chat, but you text lol and act like its all good ",
                "Were you born on the highway? That is where most accidents happen.",
                "I was going to give you a nasty look... but I see you already have one.",
                "Remember when I asked for your opinion? Me neither.",
                "Everyone’s entitled to act stupid once in awhile, but you really abuse the privilege.",
                "I'm trying to see things from your point of view, but I can't get my head that far up my ass.",
                "I haven't seen a fatty like you run that fast since twinkies went on sale for the first time.",
                "Two wrongs don't make a right, take your parents as an example.",
                "Just looking at you, I now understand why some animals eat their young offspring.",
                "Does time actually fly when you're having sex, or was it just one minute after all?",
                "You should go do that tomorrow. Oh wait, nevermind, you've made enough mistakes already for today.",
                "This is why you dont have nice things",
                "My teacher told me to erase mistakes, i'm going to need a bigger eraser.",
                "You're IQ's lower than your dick size.",
                "Are you always such an idiot, or do you just show off when I’m around?",
                "There are some remarkably dumb people in this world. Thanks for helping me understand that.",
                "I could eat a bowl of alphabet soup and shit out a smarter statement than whatever you just said.",
                "You’re about as useful as a screen door on a submarine.",
                "You always bring me so much joy—as soon as you leave the room.",
                "Stupidity’s not a crime, so feel free to go.",
                "If laughter is the best medicine, your face must be curing the world.",
                "The only way you'll ever get laid is if you crawl up a chicken's ass and wait.",
                "It looks like your face caught fire and someone tried to put it out with a hammer.",
                "Scientists say the universe is made up of neutrons, protons and electrons. They forgot to mention morons like you.",
                "Why is it acceptable for you to be an idiot but not for me to point it out?",
                "You're so fat you could sell shade.",
                "Your family tree must be a cactus because everyone on it is a prick.",
                "You'll never be the man your mother is.",
                "Just because you have an ass doesn't mean you need to act like one.",
                "Which sexual position produces the ugliest children? Ask your mother she knows.",
                "If I had a face like yours I'd sue my parents.",
                "The zoo called. They're wondering how you got out of your cage?",
                "Hey, you have something on your chin... no, the 3rd one down.",
                "Aww, it's so cute when you try to talk about things you don't understand.",
                "You are proof that evolution can go in reverse.",
                "Brains aren't everything. In your case they're nothing.",
                "You're so ugly when you look in the mirror, your reflection looks away.",
                "When you were born, the doctor came out to the waiting room and said to your dad, I'm very sorry. We did everything we could. But he pulled through.",
                "I'm sorry I didn't get that - I don't speak idiot.",
                "It's better to let someone think you're stupid than open your mouth and prove it.",
                "Were you born this stupid or did you take lessons?",
                "You're such a beautiful, intelligent, wonderful person. Oh I'm sorry, I thought we were having a lying competition.",
                "Don't you get tired of putting make up on two faces every morning?",
                "Hey, I'm straighter than the pole your mom dances on.",
                "If ugliness were measured in bricks, you would be the Great Wall of China.",
                "I thought I said goodbye to you this morning when I flushed the toilet",
                "If you're trying to improve the world, you should start with yourself. Nothing needs more help than you do",
                "Zombies are looking for brains. Don't worry. You're safe.",
                "spreading rumors? At least you found a hobby spreading something other than your legs.",
                "i would tell you to eat trash but that’s cannibalism",
                "If you spoke your mind, you would be speechless",
                "I can fix my ugliness with plastic surgery but you on the other hand will stay stupid forever",
                "Acting like a dick won't make yours any bigger",
                "If I wanted to hear from an asshole, I would have farted",
                "Roses are red. Violets are blue. God made us beautiful. What the hell happened to you?",
                "You remind me of a penny, two faced and worthless!",
                "I've met some pricks in my time but you my friend, are the f*cking cactus",
                "I'd slap you, but that would be animal abuse",
                "If you're gonna be a smartass, first you have to be smart. Otherwise you're just an ass. ",
                "I know I’m talking like an idiot. I have to, other wise you wouldn't understand me.",
                "You're so dumb, your brain cell died of loneliness",
                "You shouldn't let your mind wander..its way to small to be out on its own",
                "I don't know what makes you so dumb, but its working",
                "You should put the diaper on your mouth, that's where the craps comin' out.",
                "You would be much more likable if it wasn’t for that hole in your mouth that stupid stuff comes out of. ",
                "Could you go away please, I'm allergic to douchebags",
                "If you had any intelligence to question I would have questioned it already.",
                "I wish I had a lower I.Q,  maybe then I could enjoy your company.",
                "I would answer you back but life is too short, just like your d*ck",
                "Mirrors don't lie. Lucky for you, they can't laugh either.",
                "I was right there are no humans in this channel"
           };

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            RegisterPurgeCommand();
            RegisterHelloCommand();
            RegisterByeCommand();
            RegisterHelpCommand();
            RegisterKickCommand();
            RegisterTestCommand();
            RegisterRoastCommand();
            RegisterCheckJoinCommand();
            RegisterBanCommand();
            RegisterInfoCommand();
            RegisterUsercountCommand();
            RegisterUserinfoCommand();
            Register8ballCommand();
            RegisterChangelogCommand();
            RegisterbanlistCommand();
            RegisterKillCommand();
            RegisterServerinfoCommand();
            RegisterSelfCommand();



            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("Yourtoken", TokenType.Bot);
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("Bot has come online");
                string gameName = "!help for cmds";
                Game g = new Game(gameName, GameType.Default, "https://discordapp.com");
                discord.SetGame(g);
            });
        }



        private void RegisterHelpCommand()
        {
            commands.CreateCommand("help")
                .Do(async (e) =>
                {
                    await e.User.SendMessage("```Member CMDS: !hello - Bot responds with Hello [username] \n" +
                        "!bye - Bot responds with bye [username] \n" +
                        "!report - reports previous message \n" +
                        "!roast - roasts a user | !rules - will give a link to the rules \n" +
                        "!joined [username] - tells you when [username] joined the server \n" +
                        "!botinfo - displays bot info \n" +
                        "!8ball - Gives a random 8ball anser \n" +
                        "!purge [n] - removes [n] of messages \n" +
                        "!kick [username] - Kicks user from the discord \n" +
                        "!warn [username] - warns a user \n" +
                        "!ban [username] - bans [username]  from the server \n" +
                        "!serverinfo - Bot responds with server info (ex. Who owns it, How many members, etc) \n" +
                        "!changelog - Shows changes in the latest update \n" +
                        "!usercount - Bot will respond with how many users are in the server \n" +
                        "!help - Bot will pm you the list of cmds \n" +
                        "!checkself - Displays info of self```");
                });
        }

        private void RegisterUsercountCommand()
        {
            commands.CreateCommand("usercount")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Number of users on the server: " + e.Server.UserCount);

                });
        }

        private void RegisterHelloCommand()
        {
            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hello " + e.User.Name);

                });
        }

        private void RegisterInfoCommand()
        {
            commands.CreateCommand("botinfo")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Bot created by: Doppler#3837");
                    await e.Channel.SendMessage("Bot version is: v1.4");
                    await e.Channel.SendMessage("Bot software is running: v0.9.6 Discord.net");
                    await e.Channel.SendMessage("Uptime: Work in progress");
                });
        }

        private void RegisterChangelogCommand()
        {
            commands.CreateCommand("changelog")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Update version v1.4");
                    await e.Channel.SendMessage("!8ball - gives you a random 8ball answer");
                    await e.Channel.SendMessage("!changelog - displays the chnagelog for the newest update");
                    await e.Channel.SendMessage("Added 15 new roast responses to the roast cmd");
                });
        }

        private void RegisterServerinfoCommand()
        {
            commands.CreateCommand("serverinfo")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Server owner: " + e.Server.Owner);
                    await e.Channel.SendMessage("Server name: " + e.Server.Name);
                    await e.Channel.SendMessage("Number of roles: " + e.Server.RoleCount);
                    await e.Channel.SendMessage("This server has " + e.Server.UserCount + " users");
                });
        }

        private void Register8ballCommand()
        {
            commands.CreateCommand("8ball")
                .Parameter("User", ParameterType.Unparsed)
                .Do(async (e) =>
                {
                    //Reason = e.Server.FindUsers(e.GetArg("Reason"));
                    int ballIndex = rand.Next(ballres.Length);
                    string ballresponse = ballres[ballIndex];
                    await e.Channel.SendMessage(e.User.Name + " " + ballresponse);
                });
        } 

        private void RegisterByeCommand()
        {
            commands.CreateCommand("bye")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Bye " + e.User.Name);

                });
        }

        private void RegisterSelfCommand()
        {
            commands.CreateCommand("checkself")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Username: \n" + e.User.Name +
                    "Nickname: \n" + e.User.Nickname +
                    "Muted: \n" + e.User.IsServerMuted +
                    "User ID: \n" + e.User.Id + 
                    "Joined at: \n" + e.User.JoinedAt);

                });
        }

        private void RegisterbanlistCommand()
        {
            commands.CreateCommand("kys")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("If I wanted to kill myself I’d climb your ego and jump to your IQ.");
                });
        }

        private void RegisterKillCommand()
        {
            commands.CreateCommand("kill")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("I do not approve of this");
                });
        }

        private void RegisterKickCommand()
        {
            commands.CreateCommand("kick")
                 .Description("Kick a user from the Server.")
                 .Parameter("User", ParameterType.Required)
                .Do(async (e) =>
                {
                    try
                    {
                        if (e.User.ServerPermissions.KickMembers)
                        {
                            User user = null;
                            try
                            {
                                // try to find the user
                                user = e.Server.FindUsers(e.GetArg("User")).First();
                            }
                            catch (InvalidOperationException)
                            {
                                await e.Channel.SendMessage($"Couldn't kick user {e.GetArg("User")} (not found).");
                                return;
                            }
                            // double safety check
                            if (user == null) await e.Channel.SendMessage($"Couldn't kick user {e.GetArg("User")} (not found).");
                            await user.Kick();
                            await e.Channel.SendMessage($"{user.Name} was kicked from the server!");
                        }
                        else
                        {
                            await e.Channel.SendMessage($"{e.User.Name} you don't have the permission to kick.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // needs a better error handling haven't changed it since i tested it xD
                        await e.Channel.SendMessage(ex.Message);
                    }
                });
        }

        private void RegisterBanCommand()
        {
            commands.CreateCommand("ban")
               .Description("ban a user from the Server.")
                .Parameter("User", ParameterType.Required)
                .Do(async (e) =>
                {
                    try
                    {
                        if (e.User.ServerPermissions.BanMembers)
                        {
                            User user = null;
                            try
                            {
                                // try to find the user
                                user = e.Server.FindUsers(e.GetArg("User")).First();
                            }
                            catch (InvalidOperationException)
                            {
                                await e.Channel.SendMessage($"Couldn't ban user {e.GetArg("User")} (not found).");
                                return;
                            }
                            // double safety check
                            if (user == null) await e.Channel.SendMessage($"Couldn't ban user {e.GetArg("User")} (not found).");
                            await e.Server.Ban(user);
                            await e.Channel.SendMessage($"{user.Name} was banned from the server!");
                        }
                        else
                        {
                            await e.Channel.SendMessage($"{e.User.Name} you don't have the permission to ban.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // needs a better error handling haven't changed it since i tested it xD
                        await e.Channel.SendMessage(ex.Message);
                    }
                });
        }

/* private void RegisterUnBanCommand()
        {
            commands.CreateCommand("modlog")
               .Description("unbans a user from the Server.")
                .Do(async (e) =>
                {
                    if (e.User.ServerPermissions.BanMembers)
                    {
                        try
                        {
                            // double safety check
                            //if (user == null) await e.Channel.SendMessage($"Couldn't ban user {e.GetArg("User")} (not found).");
                            await e.Server.CreateChannel("mod-log", ChannelType.Text);
                            await e.Channel.SendMessage(e.User.Name + " mod-log channel has been created!");
                        }
                        { 
                        catch
                        }
                    else
                    {
                        await e.Channel.SendMessage($"{e.User.Name} you don't have the permission to create a modlog channel.");
                    }
                    
                    catch (Exception ex)
                    {
                        // needs a better error handling haven't changed it since i tested it xD
                        await e.Channel.SendMessage(ex.Message);
                    }
                });
        } */

        private void RegistermodlogCommand()
        {
            commands.CreateCommand("modlog")
                .Do(async (e) =>
                {
                    await e.Server.CreateChannel("mod-log", ChannelType.Text);
                    await e.Channel.SendMessage(e.User.Name + " mod-log channel has been created!");

                });
        }

        private void RegisterPurgeCommand()
        {
            commands.CreateCommand("purge")
                .Parameter("purgeAmount", ParameterType.Required)
                .Do(async (e) =>
                {
                    if (e.User.ServerPermissions.ManageMessages)
                    {
                        try
                        {
                            int amnt = Convert.ToInt32(e.GetArg("purgeAmount"));
                            Message[] messagesToDelete;
                            if (amnt < 100)
                            {
                                messagesToDelete = await e.Channel.DownloadMessages(amnt);
                                await e.Channel.DeleteMessages(messagesToDelete);
                                await e.Channel.SendMessage(e.GetArg("purgeAmount") + " messages deleted.");
                            }
                            else
                            {
                                await e.Channel.SendMessage("The maximum amount is 99.");
                            }
                        }

                        catch (Exception ex)
                        {
                            // needs a better error handling haven't changed it since i tested it xD
                            await e.Channel.SendMessage(ex.Message);
                        }

                    }
                });
        }

        private void RegisterTestCommand()
        {
            commands.CreateCommand("warn")
                .Parameter("User", ParameterType.Required)
                .Do(async (e) =>

                    {

                        try
                        {
                            if (e.User.ServerPermissions.KickMembers)
                            {
                                User user = null;
                                try
                                {
                                    // try to find the user
                                    user = e.Server.FindUsers(e.GetArg("User")).First();
                                }
                                catch (InvalidOperationException)
                                {
                                    await e.Channel.SendMessage($"Error warning user {e.GetArg("User")} (not found).");
                                    return;
                                }
                                // double safety check
                                //if (user == null) await e.Channel.SendMessage($"Couldn't kick user {e.GetArg("User")} (not found).");
                                await user.SendMessage("You have recived a warning  From: " + e.User.Name);
                                //await e.Channel.SendMessage(e.GetArg("User") + " has been warned successfully!");
                            }
                            else
                            {
                                await e.Channel.SendMessage($"{e.User.Name} you don't have the permission to warn.");
                            }
                        }
                        catch (Exception ex)
                        {
                            // needs a better error handling haven't changed it since i tested it xD
                            await e.Channel.SendMessage(ex.Message);
                        }

                    });
        }

        private void RegisterUserinfoCommand()
        {
            commands.CreateCommand("userinfo")
                .Parameter("User" /*+ "Role"*/, ParameterType.Required)
                .Do(async (e) =>
                {
                    try
                    {
                        if (e.User.ServerPermissions.SendMessages)
                        {
                            //Role role = null;
                            User user = null;
                            try
                            {
                                // try to find the user
                                user = e.Server.FindUsers(e.GetArg("User")).First();
                                //role = e.Server.FindRoles(e.GetArg("Role")).First();
                            }
                            catch (InvalidOperationException)
                            {
                                await e.Channel.SendMessage($"Error getting user info {e.GetArg("User")} (not found).");
                                return;
                            }
                            // double safety check
                            await e.Channel.SendMessage("Username: " + e.GetArg("User"));
                           // await e.Channel.SendMessage("User role: " + e.GetArg("Role"));
                            //await e.Channel.SendMessage("User ID: " + e.GetArg("Role"));
                            // await e.Channel.SendMessage("User status: " + e.User.Status);
                            // await e.Channel.SendMessage("Users current game: " + e.User.CurrentGame);
                        }
                        else
                        {
                            await e.Channel.SendMessage($"{e.User.Name} you don't have the permission to warn.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // needs a better error handling haven't changed it since i tested it xD
                        await e.Channel.SendMessage(ex.Message);
                    }

                });
        }

        private void RegisterRoastCommand()
        {
            commands.CreateCommand("roast")
                .Parameter("User", ParameterType.Required)
                .Do(async (e) =>
                {
                    try
                    {
                        if (e.User.ServerPermissions.SendMessages)
                        {
                            User user = null;
                            try
                            {
                                // try to find the user
                                user = e.Server.FindUsers(e.GetArg("User")).First();
                            }
                            catch (InvalidOperationException)
                            {
                                await e.Channel.SendMessage($"Error finding roast good enough for {e.GetArg("User")} (not found).");
                                return;
                            }
                            // double safety check
                            int randomroastIndex = rand.Next(freshestroast.Length);
                            string roasttopost = freshestroast[randomroastIndex];
                            await e.Channel.SendMessage(e.GetArg("User") + roasttopost);
                        }
                        else
                        {
                            await e.Channel.SendMessage($"{e.User.Name} you don't have the permission to roast.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // needs a better error handling haven't changed it since i tested it xD
                        await e.Channel.SendMessage(ex.Message);
                    }
                });
        }

        private void RegisterCheckJoinCommand()
        {
            commands.CreateCommand("joined")
                .Parameter("User", ParameterType.Required)
                .Do(async (e) =>
                {
                    try
                    {
                        if (e.User.ServerPermissions.SendMessages)
                        {
                            User user = null;
                            try
                            {
                                // try to find the user
                                user = e.Server.FindUsers(e.GetArg("User")).First();
                            }
                            catch (InvalidOperationException)
                            {
                                await e.Channel.SendMessage($"Error Checking last online for {e.GetArg("User")}.");
                                return;
                            }
                            // double safety check
                            if (user == null) await e.Channel.SendMessage($"Couldn't check user {e.GetArg("User")} (not found).");
                            await e.Channel.SendMessage(e.GetArg("User") + " Joined server at " + e.User.JoinedAt);
                        }
                        else
                        {
                            await e.Channel.SendMessage($"{e.User.Name} you don't have the permission to use this command .");
                        }
                    }
                    catch (Exception ex)
                    {
                        // needs a better error handling haven't changed it since i tested it xD
                        await e.Channel.SendMessage(ex.Message);
                    }
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

