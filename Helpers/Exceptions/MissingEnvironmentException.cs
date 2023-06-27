namespace sge.Exceptions;
public class MissingEnvironmentException : System.Exception
{
  public MissingEnvironmentException() { }
  public MissingEnvironmentException(string message) : base(message) { }
  public MissingEnvironmentException(string message, System.Exception inner) : base(message, inner) { }
  protected MissingEnvironmentException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}