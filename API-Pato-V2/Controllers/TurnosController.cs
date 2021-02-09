using API_Pato_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Pato_V2.Controllers
{
    public class TurnosController : ApiController
    {
        // GET: api/Turnos/5
        public List<sp_api_TURNO_CLIENTE_Result> Get(int dni)
        {
            using(TURNEROEntities te = new TURNEROEntities())
            {
                var t = te.sp_api_TURNO_CLIENTE(dni);
                return t.ToList();
            }
        }

        public int Post([FromBody] TurnoRequest value)
        {
            using (TURNEROEntities te = new TURNEROEntities())
            {
                var p = te.sp_api_NUEVO_CLIENTE_SMS(value.DNI, value.Telefono);
                if (p == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
                
            }

        }

        public List<sp_api_CLIENTE_ENVIO_SMS_Result> Get(int dni, int mensaje)
        {
            using (TURNEROEntities te = new TURNEROEntities())
            {
                var t = te.sp_api_CLIENTE_ENVIO_SMS(dni, mensaje);
                return t.ToList();
            }
        }



    }


}
