using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPNodeManual_NETConsole
{
    /// <summary>
    /// Контейнер для сообщений.
    /// </summary>
    class Message
    {
        /// <summary>
        /// Основные данные сообщения.
        /// </summary>
        private String data;

        public Message(String data)
        {
            this.data = data;
        }

        /// <summary>
        /// Возвращает готовое сообщение для отправки.
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return data;
        }
    }
}
