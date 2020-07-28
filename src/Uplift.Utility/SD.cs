using System;
using System.Collections.Generic;
using System.Text;

namespace Uplift.Utility
{
    public static class SD
    {
        // Utilizaremos a variável SessionCart ao invés de poluir o código com uma magic string "Cart" o que seria uma má prática. 
        public const string SessionCart = "Cart";
        public const string StatusSubmitted = "Submitted";
        public const string StatusApproved = "Approved";
        public const string StatusRejected = "Rejected";

        public const string Admin = "Admin";
        public const string Manager = "Manager";
    }
}
