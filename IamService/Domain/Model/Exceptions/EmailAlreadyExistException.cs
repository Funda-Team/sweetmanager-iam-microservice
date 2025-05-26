namespace IamService.Domain.Model.Exceptions
{
    public class EmailAlreadyExistException() : Exception("The given email already exist in the system.");
}