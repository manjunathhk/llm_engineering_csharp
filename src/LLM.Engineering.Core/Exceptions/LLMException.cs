namespace LLM.Engineering.Core.Exceptions;

public class LLMException : Exception
{
    public LLMException()
    { }

    public LLMException(string message) : base(message)
    {
    }

    public LLMException(string message, Exception innerException) : base(message, innerException)
    {
    }
}