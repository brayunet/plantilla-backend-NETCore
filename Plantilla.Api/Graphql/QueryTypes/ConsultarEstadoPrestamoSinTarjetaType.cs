using HotChocolate.Types;
using plantilla.Core.DbQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plantilla.Api.Graphql.QueryTypes
{
    public class ConsultarEstadoplantillainTarjetaType : ObjectType<ConsultarEstadoplantillainTarjeta>
    {

        /// <summary>
        /// Definición de los campos disponibles para la interacción a través del endpoint.
        /// cada campo puede tener una descripción que sirve para autodocumentar el endpoint
        /// y que se puede visualizar desde graphiql.
        /// Los campos pueden ser tipos y estos sirven para navegar por las relaciones establecidas
        /// en la base de datos.
        /// </summary>
        protected override void Configure(IObjectTypeDescriptor<ConsultarEstadoplantillainTarjeta> descriptor)
        {

            descriptor.BindFields(BindingBehavior.Explicit);

            // descripcion se muestra en el entry point del servicio
            descriptor.Description("");

            // cada Field representa un campo disponible y se puede colocar
            // una descripción
            descriptor.Field(x => x.nombre).Type<NonNullType<StringType>>().Description("Nombre del estado del prestamo."); // Directive(new AuthorizeDirective(new[] { "MdlIdLectura" }));
            


        }
    }
}
