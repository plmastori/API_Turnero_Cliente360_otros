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
        //++ADD - 1. Interfaz de información de Turnos
        public List<sp_api_TURNO_CLIENTE_Result> Get(int dni)
        {
            using(TURNEROEntities te = new TURNEROEntities())
            {
                var t = te.sp_api_TURNO_CLIENTE(dni);
                return t.ToList();
            }
        }
        //--ADD - 1. Interfaz de información de Turnos

        //++ADD - 3. Interfaz de nuevo cliente / actualizar cliente
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
        //++ADD - 4. Interfaz de envío de SMS
        public List<sp_api_CLIENTE_ENVIO_SMS_Result> Get(int dni, int mensaje)
        {
            using (TURNEROEntities te = new TURNEROEntities())
            {
                var t = te.sp_api_CLIENTE_ENVIO_SMS(dni, mensaje);
                Put(dni);
                return t.ToList();

               
            }
                       
        }
        public void Put(int dni)
        {
            using (TURNEROEntities te = new TURNEROEntities())
            {
                var e = te.CLIENTE_ENVIO_SMS.Find(dni);
                e.Estado = "Enviado";
                te.SaveChanges();
            }

        }
        //--ADD - 4. Interfaz de envío de SMS

        //++ADD - 5. Interfaz de confirmación de envío de SMS


        //--ADD - 5. Interfaz de confirmación de envío de SMS

    }


}
