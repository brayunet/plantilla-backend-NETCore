
using Common.Utils.CustomTypes;

using HotChocolate.Types;
using HotChocolate.Types.Relay;

using System;

//using plantilla.Api.Graphql.InputTypes;
using plantilla.Api.Graphql.QueryTypes;
using plantilla.Core.ViewModels;


namespace plantilla.Api.Graphql.Queries
{
    /// <summary>
    /// Operaciones de consultas
    /// </summary>
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Name("Consultas");
            descriptor.Description("Conjunto de elementos acerca de los cuales se puede obtener informaciòn");


            descriptor.Field(x => x.GetOpcionesDeFinanciacion(default, default, default, default))
                .Type<ListType<OpcionDeFinanciacionType>>()
                .Argument("importe", x => x.Type<NonNullType<StringType>>())
                .Argument("sueldo", x => x.Type<NonNullType<StringType>>())
                .Argument("totalDeDias", x => x.Type<NonNullType<FloatType>>())
                .Argument("cedula", x => x.Type<NonNullType<IntType>>())
                .Description("Mostrar detalles de el procedimiento almacenadado para opiciones de finaciación");

            descriptor.Field(x => x.GetConsultarEstadoplantillainTarjetas(default))
                .Type<ListType<OpcionDeFinanciacionType>>()
                .Argument("idplantilla", x => x.Type<NonNullType<StringType>>())
                .Description("Mostrar detalles de el procedimiento almacenadado para opiciones de finaciación");

        }
    }

}
