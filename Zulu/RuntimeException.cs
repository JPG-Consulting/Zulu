using System;
using System.Runtime.Serialization;
using Zulu.Resources;

namespace Zulu
{
    public class RuntimeException : SystemException
    {
        /// <summary>
        ///   Inicializa una nueva instancia de la clase <see cref="RuntimeException"/>.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     Este constructor inicializa la propiedad <see cref="Exception.Message"/> de la nueva 
        ///     instancia en un mensaje proporcionado por el sistema que describe el error y tiene en 
        ///     cuenta la referencia cultural del sistema actual.
        ///   </para>
        ///   <para>
        ///     Todas las clases derivadas deben proporcionar este constructor predeterminado.
        ///   </para>
        /// </remarks>
        public RuntimeException() 
            : base(CommonResources.RuntimeException_Generic)
        { }

        /// <summary>
        ///   Inicializa una nueva instancia de la clase <see cref="RuntimeException"/> con el 
        ///   mensaje de error especificado.
        /// </summary>
        /// <param name="message">
        ///   Mensaje que describe el error.
        /// </param>
        /// <remarks>
        ///   <para>
        ///     Este constructor inicializa la propiedad <see cref="Exception.Message"/> de la 
        ///     nueva instancia utilizando el parámetro <paramref name="message"/>. Si el parámetro 
        ///     <paramref name="message"/>es <c>null</c>, esto equivale a llamar al constructor
        ///     <see cref="RuntimeException.RuntimeException"/>.
        ///   </para>
        /// </remarks>
        public RuntimeException(String message) 
            : base(message)
        { }

        /// <summary>
        ///   Inicializa una nueva instancia de la clase <see cref="RuntimeException"/> con el mensaje 
        ///   de error especificado y una referencia a la excepción interna que representa la causa de 
        ///   esta excepción.
        /// </summary>
        /// <param name="message">
        ///   Mensaje de error que explica el motivo de la excepción.
        /// </param>
        /// <param name="innerException">
        ///   La excepción que es la causa de la excepción actual o una referencia nula (<c>Nothing</c> 
        ///   en Visual Basic) si no se especifica ninguna excepción interna.
        /// </param>
        /// <remarks>
        ///   <para>
        ///     Una excepción que se produce como consecuencia directa de una excepción anterior debe 
        ///     incluir una referencia a esta última en la propiedad <see cref="Exception.InnerException"/>. 
        ///     La propiedad <see cref="Exception.InnerException"/> devuelve el mismo valor pasado al 
        ///     constructor, o una referencia nula (<c>Nothing</c> en Visual Basic) si la propiedad 
        ///     <see cref="Exception.InnerException"/> no proporciona el valor de la excepción interna 
        ///     al constructor.
        ///   </para>
        /// </remarks>
        public RuntimeException(String message, Exception innerException) 
            : base(message, innerException)
        { }

        /// <summary>
        ///   Inicializa una nueva instancia de la clase <see cref="RuntimeException"/> con datos 
        ///   serializados.
        /// </summary>
        /// <param name="info">
        ///   <see cref="SerializationInfo"/> que contiene los datos serializados del objeto que 
        ///   hacen referencia a la excepción que se va a producir.
        /// </param>
        /// <param name="context">
        ///   <see cref="StreamingContext"/> que contiene información contextual sobre el origen 
        ///   o el destino.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   <para>
        ///     <paramref name="info"/> es <c>null</c>.
        ///   </para>
        /// </exception>
        /// <exception cref="SerializationException">
        ///   <para>
        ///     El nombre de clase es <c>null</c> o <see cref="System.Exception.HResult"/> es cero (0).
        ///   </para>
        /// </exception>
        /// <remarks>
        ///   <para>
        ///     Durante la deserialización se llama a este constructor para reconstituir el objeto de 
        ///     excepción transmitido en una secuencia.
        ///   </para>
        /// </remarks>
        protected RuntimeException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        { }
    }
}
