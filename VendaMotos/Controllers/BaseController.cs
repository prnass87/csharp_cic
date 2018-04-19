using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public abstract class BaseController
    {
        private static Contexto ctx;

        public static Contexto Ctx
        {
            get
            {
                if (ctx == null)
                    ctx = new Contexto();

                return ctx;
            }

        }

    }
}
