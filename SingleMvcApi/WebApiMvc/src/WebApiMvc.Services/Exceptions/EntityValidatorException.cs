using System.Runtime.Serialization;

namespace WebApiMvc.Services.Exceptions;

[Serializable]
public class EntityValidatorException : Exception
{
    public EntityValidatorException()
    {
    }

    public EntityValidatorException(string? message) : base(message)
    {
    }

    public EntityValidatorException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityValidatorException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}