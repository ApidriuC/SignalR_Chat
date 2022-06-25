using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Common
{
    //Lista de Usuarios
    public class UserDetail
    {
        //ID Usuario
        public string ConnectionId { get; set; }
        //Nombre Usuario
        public string UserName { get; set; }
    }
}