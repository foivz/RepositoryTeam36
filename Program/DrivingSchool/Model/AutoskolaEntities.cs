using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Objects.DataClasses;

namespace Model
{
    public partial class AutoskolaEntities : DbContext
    {

        public virtual int CheckUserLogin(string userName, string pass, ObjectParameter roleName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));

            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CheckUserLogin", userNameParameter, passParameter, roleName);
        }
    }
}
