using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProj
{
    [Serializable]
   public class UserInfo
    {
        private string userName = string.Empty;

        public string UserName
       {
           get { return userName; }
           set { userName = value; }
       }

       private string pwd = string.Empty;

       public string Pwd
       {
           get{return pwd ;}
           set{pwd =value ;}
       }
    
   }
}
