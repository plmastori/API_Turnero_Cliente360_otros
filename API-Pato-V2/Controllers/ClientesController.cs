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
    public class ClientesController : ApiController
    {
        //++ADD - 1. Interfaz de información del Cliente
        public List<sp_api_VISTA_360_CLIENTE_Result> Get(string dni)
        {
            using (BI_PRODEntities te = new BI_PRODEntities())
            {
                var t = te.sp_api_VISTA_360_CLIENTE(dni);
                return t.ToList();
            }
        }

    }
}