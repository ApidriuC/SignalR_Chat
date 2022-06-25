using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRChat.Common;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        #region Data Members
        //Lista de Usuarios Conectados
        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        //Lista de Mensajes Enviados
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        #endregion

        #region Methods

        //Conexión de Usuarios
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            //Un contador que me asigna los ID's al usuario nuevo sin que se repitan
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                //Añade al usuario al ID generado en la lista de Usuarios
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName });

                //Conecta ese nuevo usuario al Chat
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                //Envio a todos, excepto al usuario nuevo
                Clients.AllExcept(id).onNewUserConnected(id, userName);

            }

        }
        //Envio de Mensajes
        public void SendMessageToAll(string userName, string message)
        {
            //Llama a la funcion que me almacena los mensajes en el Cache 
            AddMessageinCache(userName, message);

            //Envia el mensaje a todos los usuarios del chat
            Clients.All.messageReceived(userName, message);
        }


        //Desconexión de Usuarios
        public override System.Threading.Tasks.Task OnDisconnected()
        {
            //Me recorre los Usuarios y verifica la conexión de ellos
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            //Si la conexión es null, quiere decir que cerró la ventana
            if (item != null)
            {
                //Me remueve el usuario
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }
            //Retorno de la función
            return base.OnDisconnected();
        }


        #endregion

        #region
        //Funcion para almacenar mensajes en el cache
        private void AddMessageinCache(string userName, string message)
        {
            //A la lista añadimos el mensaje que envió el usuario
            CurrentMessage.Add(new MessageDetail { UserName = userName, Message = message });
            //Al cargar la pagina el historial va a contener los ultimos mensajes, ese valor se declara acá
            if (CurrentMessage.Count > 5)
                CurrentMessage.RemoveAt(0);
        }
        #endregion
    }

}