using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PasswordManager
{
   public class Account
    {
        public string description;
        public string userId;
        public string loginUrl;
        public string accountNum;
        public string psValue;
        public ushort strengthNum;
        public string strengthText;
        public string lastReset;

        public Account()
        {
            this.description = "";
            this.userId = "";
            this.loginUrl = "";
            this.accountNum = "";
            this.psValue = "";
            this.strengthNum = 0;
            this.strengthText = "";
            this.lastReset = "";

        }

    }
}
