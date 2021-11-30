using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Clase que contiene datos sobre Telegram, usuarios, etc.
    /// </summary>
    public class TelegramBot
    {

        private const string TELEBRAM_BOT_TOKEN = "2107844171:AAHeOLIKHhWp4sPgpDPPUMlEZTeRm5EY7Rc";
        private static TelegramBot instance;
        private ITelegramBotClient bot;

        private TelegramBot()
        {
            this.bot = new TelegramBotClient(TELEBRAM_BOT_TOKEN);
        }

        /// <summary>
        /// Obtiene el cliente de Telegam.
        /// </summary>
        /// <value>client.</value>
        public ITelegramBotClient Client
        {
            get
            {
                return this.bot;
            }
        }

        private User BotInfo
        {
            get
            {
                return this.Client.GetMeAsync().Result;
            }
        }

        /// <summary>
        /// Obtiene el id.
        /// </summary>
        /// <value>id.</value>
        public int BotId
        {
            get
            {
                return this.BotInfo.Id;
            }
        }

        /// <summary>
        /// Obtiene el nombre del bot.
        /// </summary>
        /// <value>Nombre.</value>
        public string BotName
        {
            get
            {
                return this.BotInfo.FirstName;
            }
        }

        /// <summary>
        /// Obtiene una instancia de TelegramBot.
        /// </summary>
        /// <value>instancia.</value>
        public static TelegramBot Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TelegramBot();
                }
                return instance;
            }
        }
    }
}