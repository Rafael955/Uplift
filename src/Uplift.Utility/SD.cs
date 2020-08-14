using System;
using System.Collections.Generic;
using System.Text;

namespace Uplift.Utility
{
    public static class SD
    {
        // Utilizaremos a variável SessionCart ao invés de poluir o código com uma magic string "Cart" o que seria uma má prática. 
        public const string SessionCart = "Carrinho";
        public const string StatusSubmitted = "Enviado";
        public const string StatusApproved = "Aprovado";
        public const string StatusRejected = "Rejeitado";

        public const string Admin = "Administrador";
        public const string Manager = "Gerente";
    }
}
