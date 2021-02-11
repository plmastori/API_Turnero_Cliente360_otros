using API_Pato_V2.Models;
using RestSharp;
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
        public int Get(int dni, int mensaje)
        {
            using (TURNEROEntities te = new TURNEROEntities())
            {
                var t = te.sp_api_CLIENTE_ENVIO_SMS(dni, mensaje);
                var p = t.ToList();
                var Telefono = p[0].Telefono;
                var Mensaje = p[0].Mensaje;
                sendsms(Telefono, Mensaje);

                Put(dni);
                return 1;

               
            }
                       
        }

        private void sendsms(string telefono, string mensaje)
        {
            var aux = new RestClient("http://servicio.smsmasivos.com.ar");
            var request = new RestRequest("enviar_sms.asp?api=1&usuario=99248&clave=99248&TOS=" + telefono + "&texto=" + mensaje, Method.GET);
            var result = aux.Execute<string>(request).Data;

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
       [HttpGet]
       [Route("api/TurnoEstado/{dni}")]
        public List<sp_api_ESTADO_ENVIO_SMS_Result> GetEstado(int dni)
        {
            using (TURNEROEntities te = new TURNEROEntities())
            {
                var a = te.sp_api_ESTADO_ENVIO_SMS(dni);
                return a.ToList();

            }

        }
        //--ADD - 5. Interfaz de confirmación de envío de SMS

    }


}
