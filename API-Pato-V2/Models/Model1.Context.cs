﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_Pato_V2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TURNEROEntities : DbContext
    {
        public TURNEROEntities()
            : base("name=TURNEROEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CLIENTE_ENVIO_SMS> CLIENTE_ENVIO_SMS { get; set; }
    
        public virtual ObjectResult<sp_api_TURNO_CLIENTE_Result> sp_api_TURNO_CLIENTE(Nullable<int> varDNI)
        {
            var varDNIParameter = varDNI.HasValue ?
                new ObjectParameter("varDNI", varDNI) :
                new ObjectParameter("varDNI", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_api_TURNO_CLIENTE_Result>("sp_api_TURNO_CLIENTE", varDNIParameter);
        }
    
        public virtual int sp_api_NUEVO_CLIENTE_SMS(Nullable<int> varDNI, string varTelefono)
        {
            var varDNIParameter = varDNI.HasValue ?
                new ObjectParameter("varDNI", varDNI) :
                new ObjectParameter("varDNI", typeof(int));
    
            var varTelefonoParameter = varTelefono != null ?
                new ObjectParameter("varTelefono", varTelefono) :
                new ObjectParameter("varTelefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_api_NUEVO_CLIENTE_SMS", varDNIParameter, varTelefonoParameter);
        }
    
        public virtual ObjectResult<sp_api_CLIENTE_ENVIO_SMS_Result> sp_api_CLIENTE_ENVIO_SMS(Nullable<int> varDNI, Nullable<int> varMensaje)
        {
            var varDNIParameter = varDNI.HasValue ?
                new ObjectParameter("varDNI", varDNI) :
                new ObjectParameter("varDNI", typeof(int));
    
            var varMensajeParameter = varMensaje.HasValue ?
                new ObjectParameter("varMensaje", varMensaje) :
                new ObjectParameter("varMensaje", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_api_CLIENTE_ENVIO_SMS_Result>("sp_api_CLIENTE_ENVIO_SMS", varDNIParameter, varMensajeParameter);
        }
    
        public virtual ObjectResult<sp_api_ESTADO_ENVIO_SMS_Result> sp_api_ESTADO_ENVIO_SMS(Nullable<int> varDNI)
        {
            var varDNIParameter = varDNI.HasValue ?
                new ObjectParameter("varDNI", varDNI) :
                new ObjectParameter("varDNI", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_api_ESTADO_ENVIO_SMS_Result>("sp_api_ESTADO_ENVIO_SMS", varDNIParameter);
        }
    }
}
