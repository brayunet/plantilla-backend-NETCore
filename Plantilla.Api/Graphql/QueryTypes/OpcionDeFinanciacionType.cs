using Common.Utils.CustomTypes;

using HotChocolate.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using plantilla.Core.Models;
using plantilla.Core.DbQueries;

namespace plantilla.Api.Graphql.QueryTypes
{
    public class OpcionDeFinanciacionType : ObjectType<OpcionDeFinanciacion>
    {


        /// <summary>
        /// Definición de los campos disponibles para la interacción a través del endpoint.
        /// cada campo puede tener una descripción que sirve para autodocumentar el endpoint
        /// y que se puede visualizar desde graphiql.
        /// Los campos pueden ser tipos y estos sirven para navegar por las relaciones establecidas
        /// en la base de datos.
        /// </summary>
        protected override void Configure(IObjectTypeDescriptor<OpcionDeFinanciacion> descriptor)
        {

            descriptor.BindFields(BindingBehavior.Explicit);

            // descripcion se muestra en el entry point del servicio
            descriptor.Description("");

            // cada Field representa un campo disponible y se puede colocar
            // una descripción
            descriptor.Field(x => x.IMPORTE).Type<NonNullType<StringType>>().Description("Importe del prestamo."); // Directive(new AuthorizeDirective(new[] { "MdlIdLectura" }));
            descriptor.Field(x => x.CUOTAS).Type<StringType>().Description("Cuotas del prestamo."); // Directive(new AuthorizeDirective(new[] { "MdlDescripcionLectura" }));
            descriptor.Field(x => x.IMPORTE_CUOTA).Type<StringType>().Description("Importa de cuotas para el prestamo."); // Directive(new AuthorizeDirective(new[] { "MdlDescripcionLectura" }));
            descriptor.Field(x => x.IMPORTE_TOTAL).Type<StringType>().Description("Importe total del prestamo"); // Directive(new AuthorizeDirective(new[] { "MdlFechaCreacionLectura" }));
            descriptor.Field(x => x.TEA).Type<StringType>().Description("Tea del prestamo."); // Directive(new AuthorizeDirective(new[] { "MdlFechaCreacionLectura" }));
            descriptor.Field(x => x.MORA).Type<StringType>().Description("Mora  del prestamo."); // Directive(new AuthorizeDirective(new[] { "MdlFechaCreacionLectura" }));
            descriptor.Field(x => x.DIAS).Type<StringType>().Description("dias."); // Directive(new AuthorizeDirective(new[] { "MdlFechaCreacionLectura" }));
            descriptor.Field(x => x.GASTOREAL).Type<StringType>().Description("Gasto real del prestamo ."); // Directive(new AuthorizeDirective(new[] { "MdlFechaCreacionLectura" }));
            descriptor.Field(x => x.PRIMA).Type<StringType>().Description("Prima  del prestamo."); // Directive(new AuthorizeDirective(new[] { "MdlFechaCreacionLectura" }));
            descriptor.Field(x => x.SEGURO).Type<StringType>().Description("Seguro."); // Directive(new AuthorizeDirective(new[] { "MdlFechaCreacionLectura" }));
            

        }

    }
}
