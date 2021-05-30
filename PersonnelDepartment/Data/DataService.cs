using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelDepartment.Data
{
    public class DataService : BaseContext
    {
        static BaseContext context;

        public DataService() : base()
        {

        }

        public static BaseContext GetContext()
        {
            if (context == null)
                context = new BaseContext();

            return context;
        }
    }
}
